using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Calendar : UserControl
    {
        List<Panel> daycell = new List<Panel>();
        List<Guna2CircleButton> dayButtons = new List<Guna2CircleButton>();
        private Dictionary<Guna2CircleButton, DateTime> buttonDateMap = new Dictionary<Guna2CircleButton, DateTime>();
        private Dictionary<Guna2CircleButton, Label> buttonTaskLabelMap = new Dictionary<Guna2CircleButton, Label>();

        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        

        FirebaseAuthService firebase = new FirebaseAuthService();

        public Calendar()
        {
            InitializeComponent();

            CreateDayHeader();
            buildCalendar();
            CreateMonthCalendar(month, year);
            lb_month.Text = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
            lb_year.Text = year.ToString();
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
                lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lbl.BackColor = Color.Transparent;

                weekday.Controls.Add(lbl, i, 0);
            }
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
                    cell.BackColor = Color.White;
                    cell.Margin = new Padding(1);

                    var btn = new Guna2CircleButton();
                    btn.Width = 34;
                    btn.Height = 34;
                    btn.FillColor = Color.LightGray;
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
                    lbTask.Click += Button_Click;
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
                btn.FillColor = Color.LightGray;

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
            try
            {
                string dateKey = date.ToString("yyyy-MM-dd");

                if (buttonTaskLabelMap.ContainsKey(button))
                {
                    buttonTaskLabelMap[button].Text = "";
                }
                button.FillColor = Color.LightGray;

                if (UserSession.ScheduleCache != null &&
                    UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    var events = UserSession.ScheduleCache[dateKey];

                    if (events != null && events.Count > 0 &&
                        buttonTaskLabelMap.ContainsKey(button))
                    {
                        var displayEvents = events.Take(3).ToList();

                        string preview = string.Join(
                            Environment.NewLine,
                            displayEvents.Select(e => "• " + e.Title)
                        );

                        if (events.Count > 3)
                        {
                            preview += Environment.NewLine + $"... +{events.Count - 3}";
                        }

                        buttonTaskLabelMap[button].Text = preview;

                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in LoadTaskForButton: " + ex.Message);
            }
        }

        private async void Button_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Guna2CircleButton button = null;

            if (ctrl is Guna2CircleButton)
            {
                button = ctrl as Guna2CircleButton;
            }
            else if (ctrl is Label)
            {
                foreach (var kvp in buttonTaskLabelMap)
                {
                    if (kvp.Value == ctrl)
                    {
                        button = kvp.Key;
                        break;
                    }
                }
            }

            if (button == null || !buttonDateMap.ContainsKey(button))
                return;

            DateTime selectedDate = buttonDateMap[button];

            string dateKey = selectedDate.ToString("yyyy-MM-dd");
            List<Event> events = new List<Event>();

            if (UserSession.ScheduleCache != null &&
                UserSession.ScheduleCache.ContainsKey(dateKey))
            {
                events = UserSession.ScheduleCache[dateKey];
            }


            Schedule_day noteForm = new Schedule_day(selectedDate, events);
            noteForm.OnDeleteEvent += async (evt) =>
            {
                string result = await firebase.DeleteEventAsync(evt);
                if (result != "SUCCESS")
                {
                    MessageBox.Show(result, "Delete Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            if (noteForm.ShowDialog() == DialogResult.OK)
            {
                RefreshCalendar();
            }
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

            lb_month.Text = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
            lb_year.Text = year.ToString();

            CreateMonthCalendar(month, year);
        }

        public void GoToToday()
        {
            month = DateTime.Now.Month;
            year = DateTime.Now.Year;

            lb_month.Text = CultureInfo.InvariantCulture.DateTimeFormat.GetMonthName(month);
            lb_year.Text = year.ToString();

            CreateMonthCalendar(month, year);
        }
        private void Calendar_Load(object sender, EventArgs e)
        {

        }
        private void pn_header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_nextmonth_Click(object sender, EventArgs e)
        {
            month++;
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
            if (month <= 0)
            {
                month = 12;
                year--;
            }
            ChangeMonth(month, year);
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
    }
}