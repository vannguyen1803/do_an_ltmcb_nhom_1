using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Home : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        private Calendar calendar;
        private Account acc;
        private Ghi_chu note;
        private Pomodoro pom;
        private thongke_pomodoro tk_pom;

        public Home()
        {
            InitializeComponent();
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            try
            {
                pn_content.Controls.Clear();
                Label lblLoading = new Label
                {
                    Text = "Đang tải dữ liệu...",
                    Font = new Font("Segoe UI", 14),
                    AutoSize = true,
                    Location = new Point(200, 200)
                };
                pn_content.Controls.Add(lblLoading);

                UserSession.ScheduleCache = await firebase.GetAllSchedulesAsync();
                UserSession.NoteCache = await firebase.GetAllNotesAsync();

                calendar = new Calendar();
                calendar.Dock = DockStyle.Fill;

                acc = new Account();
                acc.Dock = DockStyle.Fill;

                note = new Ghi_chu();
                note.Dock = DockStyle.Fill;

                pom = new Pomodoro();
                pom.Dock = DockStyle.Fill;

                tk_pom = new thongke_pomodoro();
                tk_pom.Dock = DockStyle.Fill;


                pn_content.Controls.Clear();
                pn_content.Controls.Add(calendar);
                btn_cal.FillColor = Color.FromArgb(51, 153, 255);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_cal_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_cal.FillColor = Color.FromArgb(51, 153, 255);

            pn_content.Controls.Clear();
            if (calendar != null)
            {
                pn_content.Controls.Add(calendar);
                calendar.GoToToday();
                calendar.RefreshCalendar();
            }
        }

        private void btn_acc_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_acc.FillColor = Color.FromArgb(51, 153, 255);

            pn_content.Controls.Clear();
            if (acc != null)
            {
                pn_content.Controls.Add(acc);
            }
        }

        private void btn_note_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_note.FillColor = Color.FromArgb(51, 153, 255);

            pn_content.Controls.Clear();
            if (note != null)
            {
                pn_content.Controls.Add(note);
            }
        }



        private void btn_aim_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_aim.FillColor = Color.FromArgb(51, 153, 255);

        }

        private void btn_diary_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_diary.FillColor = Color.FromArgb(51, 153, 255);

        }

        private void ResetButtonColors()
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.Transparent;
        }

        private void btn_pomo_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            pn_content.Controls.Clear();
            if (pom != null) pn_content.Controls.Add(pom);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            pn_content.Controls.Clear();
            if (tk_pom != null) pn_content.Controls.Add(tk_pom);
        }
    }
}