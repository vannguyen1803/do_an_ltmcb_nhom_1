using Grpc.Core;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Project_doan
{
    public partial class Calendar : UserControl
    {
        List<Panel> daycell = new List<Panel>();
        List<Guna2CircleButton> dayButtons = new List<Guna2CircleButton>();
        private Dictionary<Guna2CircleButton, DateTime> buttonDateMap = new Dictionary<Guna2CircleButton, DateTime>();
        private Dictionary<Guna2CircleButton, Label> buttonTaskLabelMap = new Dictionary<Guna2CircleButton, Label>();
        public event Func<DateTime, Task<List<Event>>> OnRequestSchedule;
        public event Func<Event, Task> OnDeleteEventRequested;
        FirebaseAuthService firebase = new FirebaseAuthService();

        List<Aim> cacheAim = new List<Aim>();

        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        string monthName = DateTime.Now.ToString("MMMM", CultureInfo.InvariantCulture);
        public Calendar()
        {
            InitializeComponent();

            CreateDayHeader();
            buildCalendar();
            CreateMonthCalendar(month, year);
            lb_month.Text = monthName;
            lb_year.Text = year.ToString();

        }
        
        public async void LoadDataAsync()
        {
            try
            {
                cacheAim = await firebase.GetAllAimsAsync();
                CreateMonthCalendar(month, year);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải mục tiêu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CreateDayHeader()
        {
            for (int i = 0; i < 7; i++)
                weekday.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.285f));

            string[] days = { "MON", "TUE", "WED", "THU", "FRI", "SAT", "SUN" };

            for (int i = 0; i < 7; i++)
            {
                Label lbl = new Label();
                lbl.Text = days[i];
                lbl.Dock = DockStyle.Fill;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Font = new Font("Segoe UI", 11);
                lbl.BackColor = Color.Transparent;

                weekday.Controls.Add(lbl, i, 0);
            }

            this.Controls.Add(weekday);
        }

        void buildCalendar()
        {
            pn_day.Controls.Clear();
            daycell.Clear();
            dayButtons.Clear();
            buttonDateMap.Clear();
            buttonTaskLabelMap.Clear();

            for (int r = 0; r < pn_day.RowCount; r++)
            {
                for (int c = 0; c < pn_day.ColumnCount; c++)
                {
                    Panel cell = new Panel();
                    cell.Dock = DockStyle.Fill;
                    cell.BackColor = Color.FromArgb(228, 243, 255);
                    cell.Margin = new Padding(0);

                    var btn = new Guna2CircleButton();
                    btn.Width = 34;
                    btn.Height = 34;
                    btn.FillColor = Color.FromArgb(141, 201, 250);
                    btn.ForeColor = Color.Black;
                    btn.Location = new Point(2, 2);
                    btn.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                    btn.AutoSize = true;
                    btn.TextAlign = (HorizontalAlignment)ContentAlignment.MiddleCenter;
                    btn.Padding = new Padding(0);
                    btn.Margin = new Padding(0);

                    btn.Click += Button_Click;

                    cell.Controls.Add(btn);
                    Label lbTask = new Label();
                    lbTask.Location = new Point(2, 38);
                    lbTask.MaximumSize = new Size(cell.Width - 4, 0);
                    lbTask.AutoSize = true;
                    lbTask.Font = new Font("Segoe UI", 7);
                    lbTask.ForeColor = Color.DarkBlue;
                    lbTask.TextAlign = ContentAlignment.TopCenter;
                    lbTask.Click += Button_Click; // Cũng có thể click vào label
                    cell.Controls.Add(lbTask);

                    daycell.Add(cell);
                    dayButtons.Add(btn);
                    buttonTaskLabelMap[btn] = lbTask;

                    pn_day.Controls.Add(cell, c, r);
                }
            }
        }

        void CreateMonthCalendar(int month, int year)
        {
            foreach (var btn in dayButtons)
            {
                btn.Text = "";
                btn.Tag = null;
                btn.Visible = false;
                btn.FillColor = Color.FromArgb(141, 201, 250);

                if (buttonTaskLabelMap.ContainsKey(btn))
                {
                    buttonTaskLabelMap[btn].Text = "";
                }
            }

            buttonDateMap.Clear();

            DateTime firstDay = new DateTime(year, month, 1);
            int offset = (int)firstDay.DayOfWeek;
            if (offset == 0)
                offset = 6;
            else
                offset -= 1;

            int dayCount = DateTime.DaysInMonth(year, month);
            int index = offset;

            for (int day = 1; day <= dayCount; day++)
            {
                var btn = dayButtons[index];
                DateTime currentDate = new DateTime(year, month, day);

                btn.Text = day.ToString();
                btn.Tag = currentDate;
                btn.Visible = true;
                buttonDateMap[btn] = currentDate;
                LoadTaskForButton(btn, currentDate);

                index++;
            }
        }
        private void LoadTaskForButton(Guna2CircleButton button, DateTime date)
        {
            string dateKey = date.ToString("yyyy-MM-dd");

            if (!buttonTaskLabelMap.ContainsKey(button))
                return;

            var label = buttonTaskLabelMap[button];
            label.Text = "";

            if (UserSession.ScheduleCache.ContainsKey(dateKey))
            {
                var events = UserSession.ScheduleCache[dateKey];
                if (events.Count > 0)
                {
                    label.Text = string.Join(
                        Environment.NewLine,
                        events.Take(3).Select(e => "• " + e.Title)
                    );

                    if (events.Count > 3)
                        label.Text += Environment.NewLine + "...";
                }
            }
        }


        private async void Button_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Guna2CircleButton button = null;

            if (ctrl is Guna2CircleButton)
                button = (Guna2CircleButton)ctrl;
            else if (ctrl is Label)
            {
                button = buttonTaskLabelMap
                    .FirstOrDefault(x => x.Value == ctrl).Key;
            }

            if (button == null || !buttonDateMap.ContainsKey(button))
                return;

            DateTime selectedDate = buttonDateMap[button];
            string dateKey = selectedDate.ToString("yyyy-MM-dd");

            List<Event> events = new List<Event>();
            if (UserSession.ScheduleCache.ContainsKey(dateKey))
            {
                // Đã có cache → dùng luôn
                events = UserSession.ScheduleCache[dateKey];
            }
            else if (OnRequestSchedule != null)
            {
                // Chưa có → hỏi Home → Home gọi Firebase
                var taskResult = OnRequestSchedule.Invoke(selectedDate);
                events = await taskResult;

                // Cache lại (Nếu logic của Home/FirebaseService không làm điều này)
                UserSession.ScheduleCache[dateKey] = events;
            }
            events = events.OrderBy(ev => ev.Start).ToList();

            Schedule_day frm = new Schedule_day(selectedDate, events);
            // ADD
            frm.OnAddEvent += (ev) =>
            {
                
                RefreshCalendar();
            };

            // DELETE (đã có)
            frm.OnDeleteEvent += async (ev) =>
            {
                // 1. Xóa trong cache
                if (UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    UserSession.ScheduleCache[dateKey].RemoveAll(item => item.UId == ev.UId);

                    
                }
                // 2. Refresh UI
                RefreshCalendar();

                // 3. Báo cho Home xử lý Firebase
                if (OnDeleteEventRequested != null)
                    await OnDeleteEventRequested(ev);
            };

            frm.ShowDialog();
        }


        public void RefreshCalendar()
        {
            foreach (var kvp in buttonDateMap)
            {
                LoadTaskForButton(kvp.Key, kvp.Value);
            }
        }

        public void ChangeMonth(int newMonth, int newYear)
        {
            month = newMonth;
            year = newYear;

            lb_month.Text = month.ToString();
            lb_year.Text = year.ToString();

            CreateMonthCalendar(month, year);
        }

        public void GoToToday()
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;

            lb_month.Text = month.ToString();
            lb_year.Text = year.ToString();

            CreateMonthCalendar(month, year);
        }

        private void Calendar_Load(object sender, EventArgs e)
        {
            LoadDataAsync();
            lb_month.Text = month.ToString();
            lb_year.Text = year.ToString();
        }

        private void btn_nextmonth_Click(object sender, EventArgs e)
        {
            month ++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            ChangeMonth(month, year);
        }

        private void btn_premonth_Click(object sender, EventArgs e)
        {
            month--;
            if (month <= 0) {
                month = 12;
                year--;
            }
            ChangeMonth(month, year);
        }

        private void pn_day_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_xuat_Click(object sender, EventArgs e)
        {
            List<Event> eventsToExport = new List<Event>();
            string currentMonthPrefix = $"{year}-{month:D2}";

            foreach (var key in UserSession.ScheduleCache.Keys)
            {
                if (key.StartsWith(currentMonthPrefix))
                {
                    eventsToExport.AddRange(UserSession.ScheduleCache[key]);
                }
            }

            if (eventsToExport.Count == 0)
            {
                MessageBox.Show($"Không có sự kiện nào trong tháng {month}/{year} để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "iCalendar File (*.ics)|*.ics";
                saveFileDialog.Title = "Chọn nơi lưu file Lịch Tháng";
                saveFileDialog.FileName = $"Lich_thang_{month}_{year}.ics";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string outputFileName = saveFileDialog.FileName;
                    string result = XuatLich.ExportEventsToIcs(eventsToExport, outputFileName);
                    MessageBox.Show(result, "Xuất Lịch Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tùy chọn mở thư mục
                    if (MessageBox.Show("Bạn có muốn mở thư mục chứa file không?", "Hoàn tất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start("explorer.exe", Path.GetDirectoryName(outputFileName));
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Không thể mở thư mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void weekday_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}