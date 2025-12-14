using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Home : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        private Calendar calendar;
        private Account acc;
        private Ghi_chu note;
        public Home()
        {
            InitializeComponent();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            // Load toàn bộ dữ liệu schedule từ Firebase
            UserSession.ScheduleCache = await firebase.GetAllSchedulesAsync();
            UserSession.NoteCache = await firebase.GetAllNotesAsync();

            // Tạo Calendar
            calendar = new Calendar();
            calendar.Dock = DockStyle.Fill;
            calendar.OnRequestSchedule += async (date) =>
            {
                return await firebase.GetScheduleAsync(date);
            };
            calendar.OnDeleteEventRequested += async (ev) =>
            {
                await firebase.DeleteEventAsync(ev);
            };

            //Tạo account
            var acc = new Account();
            acc.Dock = DockStyle.Fill;

            //Tạo ghi chú
            var note = new Ghi_chu();
            note.Dock = DockStyle.Fill;
        }
        
        private void btn_cal_Click(object sender, EventArgs e)
        {
            
            btn_cal.FillColor = Color.FromArgb(51,153,255);
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.Transparent;

            pn_content.Controls.Clear();
            pn_content.Controls.Add(calendar);
            calendar.GoToToday();
            calendar.RefreshCalendar();
        }

        private void btn_acc_Click(object sender, EventArgs e)
        {
            
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.FromArgb(51, 153, 255);
            btn_pomo.FillColor = Color.Transparent;

            pn_content.Controls.Clear();
            
            pn_content.Controls.Add(acc);
        }

        private void btn_note_Click(object sender, EventArgs e)
        {
            
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.FromArgb(51, 153, 255); ;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.Transparent;

            pn_content.Controls.Clear();
            
            pn_content.Controls.Add(note);
        }

        private void btn_aim_Click(object sender, EventArgs e)
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.FromArgb(51, 153, 255);
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.Transparent;
        }

        private void btn_diary_Click(object sender, EventArgs e)
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.FromArgb(51, 153, 255);
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.Transparent;
        }

        private void btn_pomo_Click(object sender, EventArgs e)
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.FromArgb(51, 153, 255);
        }



    }
}
