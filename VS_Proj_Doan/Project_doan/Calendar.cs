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

namespace Project_doan
{
    public partial class Calendar : UserControl
    {
        List<Panel> daycell = new List<Panel>();
        List<Guna2CircleButton> dayButtons = new List<Guna2CircleButton>();
        int month = DateTime.Now.Month;
        int year = DateTime.Now.Year;
        public Calendar()
        {
            InitializeComponent();

            CreateDayHeader();
            buildCalendar();
            CreateMonthCalendar(month, year);
            lb_month.Text=month.ToString();
            lb_year.Text=year.ToString();
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

            for (int r = 0; r < pn_day.RowCount; r++)
            {
                for (int c = 0; c < pn_day.ColumnCount; c++)
                {
                // Tạo cell panel
                Panel cell = new Panel();
                cell.Dock = DockStyle.Fill;
                cell.BackColor = Color.White;
                cell.Margin = new Padding(1);

                // Tạo nút ngày
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
                cell.Controls.Add(btn);

                daycell.Add(cell);
                dayButtons.Add(btn);

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
                btn.Visible = false; // ẩn button khi không phải ngày hợp lệ
            }

            DateTime firstDay = new DateTime(year, month, 1);

            // Tính Offset (số ô trống)
            // DayOfWeek.Monday là 1, DayOfWeek.Sunday là 0

            // 1. Chuyển DayOfWeek thành 1-7 (1=Mon, 7=Sun)
            // (int)firstDay.DayOfWeek cho 0=Sun, 1=Mon, ..., 6=Sat
            int offset = (int)firstDay.DayOfWeek; // 0..6

            // Chuyển đổi sang hệ 0=Mon → 6=Sun
            if (offset == 0)
                offset = 6;           // Chủ Nhật → cuối tuần
            else
                offset -= 1;          // Các ngày còn lại giảm 1

            int dayCount = DateTime.DaysInMonth(year, month);

            int index = offset; // vị trí button trong 42 ô

            for (int day = 1; day <= dayCount; day++)
            {
                var btn = dayButtons[index];
                btn.Text = day.ToString();
                btn.Tag = new DateTime(year, month, day);
                btn.Visible = true;

                index++;
            }
        }
    }
}
