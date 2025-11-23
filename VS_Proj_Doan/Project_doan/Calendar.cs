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
            buildCalendar();
            CreateMonthCalendar(month, year);
        }
        void buildCalendar()
        {
            pn_day.Controls.Clear();
            daycell.Clear();
            dayButtons.Clear();
            int width = 116;
            int height = 68;
            int margincell =0;
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++) {
                    Panel p = new Panel();
                    p.Width = width;
                    p.Height = height;
                    p.BackColor = Color.White;
                    p.BorderStyle = BorderStyle.FixedSingle;
                    p.Location = new Point(col * (width + margincell), row * (height + margincell));
                    pn_day.Controls.Add(p);
                    daycell.Add(p);

                    var btn = new Guna.UI2.WinForms.Guna2CircleButton();
                    btn.Width = 32;
                    btn.Height = 32;
                    btn.FillColor = Color.Transparent;
                    p.Controls.Add(btn);
                    dayButtons.Add(btn);
                }
                
            }
        }
        void CreateMonthCalendar(int month, int year)
        {
            DateTime firstDay = new DateTime(year, month, 1);

            // Tính Offset (số ô trống)
            // DayOfWeek.Monday là 1, DayOfWeek.Sunday là 0

            // 1. Chuyển DayOfWeek thành 1-7 (1=Mon, 7=Sun)
            // (int)firstDay.DayOfWeek cho 0=Sun, 1=Mon, ..., 6=Sat
            int offset = (int)firstDay.DayOfWeek;

            // 2. Chuyển sang 0=Mon, 6=Sun (vì lịch của bạn bắt đầu bằng MON)
            if (offset == 0) // Nếu là Sunday
            {
                offset = 7; 
            }
            else 
            {
                offset = offset - 1;
            }

            int dayCount = DateTime.DaysInMonth(year, month);

            int btnIndex = offset; // Đây là chỉ số ô bắt đầu điền ngày (0 đến 41)

            for (int day = 1; day <= dayCount; day++)
            {
                dayButtons[btnIndex].Text = day.ToString();
                dayButtons[btnIndex].Tag = new DateTime(year, month, day);
                btnIndex++;
            }
        }
    }
}
