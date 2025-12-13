using Grpc.Core;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_doan.Models;
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
            lb_month.Text = month.ToString();
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

                if (UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    string content = UserSession.ScheduleCache[dateKey];

                    if (!string.IsNullOrEmpty(content) && buttonTaskLabelMap.ContainsKey(button))
                    {
                        string preview = content.Length > 20
                            ? content.Substring(0, 17) + "..."
                            : content;

                        buttonTaskLabelMap[button].Text = preview;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            ScheduleNote noteForm = new ScheduleNote(selectedDate);

            if (noteForm.ShowDialog() == DialogResult.OK)
            {
                LoadTaskForButton(button, selectedDate);
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

        private void btn_premonth_Click(object sender, EventArgs e)
        {

        }
    }
}