using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Project_doan
{
    public partial class Home : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        private Calendar calendar;
        private Account acc;
        private Ghi_chu note;
        Aim aim;
        public Home()
        {
            InitializeComponent();
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
            if (aim != null)
            {
                KiemTraVaGuiMail(aim);
            }
        
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            // Load toàn bộ dữ liệu schedule từ Firebase
            UserSession.ScheduleCache = await firebase.GetAllSchedulesAsync();
            UserSession.NoteCache = await firebase.GetAllNotesAsync();
            await CheckAndNotifyAllAim();
        }
        private async Task CheckAndNotifyAllAim()
        {
            try
            {
                List<Aim> listAim = await firebase.GetAllAimsAsync();

                if (listAim != null && listAim.Count > 0)
                {
                    foreach (var aim in listAim)
                    {
                        KiemTraVaGuiMail(aim);

                        //Thêm delay để các bong bóng thông báo không hiện chồng chéo
                        await Task.Delay(200);
                    }
                }
            }
            catch { }
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
            pn_content.Controls.Clear();
            var AimControl = new Muc_tieu();
            AimControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(AimControl);
        }

        private void btn_diary_Click(object sender, EventArgs e)
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.FromArgb(51, 153, 255);
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.Transparent;
            pn_content.Controls.Clear();
            var diaryControl = new UserControlNhatKy(_firebaseService);
            diaryControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(diaryControl);
        }

        private void btn_pomo_Click(object sender, EventArgs e)
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.FromArgb(51, 153, 255);
            pn_content.Controls.Clear();
            var PomodoroControl = new Pomodoro();
            PomodoroControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(PomodoroControl);
        }
        private void KiemTraVaGuiMail(Aim aim)
        {
            if (aim == null) return;

            if (aim.status == AimStatus.HoanThanh) return;

            TimeSpan conLai = aim.date_end - DateTime.Now;

            int days = (int)conLai.TotalDays;

            if (days < 0) return;

            string thongbao = "";

            switch (days)
            {
                case int n when (days <= 1):
                    thongbao = "Ngày cuối cùng để hoàn thành mục tiêu!";
                    break;
                case int n when (days <= 7):
                    thongbao = "Tuần cuối cùng để hoàn thành mục tiêu!";
                    break;
                case int n when (days <= 14):
                    thongbao = "Còn 2 tuần để hoàn thành mục tiêu!";
                    break;
                case int n when (days <= 30):
                    thongbao = "Còn 1 tháng để hoàn thành mục tiêu!";
                    break;
                case int n when (days <= 60):
                    thongbao = "Còn 2 tháng để hoàn thành mục tiêu!";
                    break;
                case int n when (days <= 90):
                    thongbao = "Còn 3 tháng để hoàn thành mục tiêu!";
                    break;
                case int n when (days <= 180):
                    thongbao = "Còn 6 tháng để hoàn thành mục tiêu!";
                    break;
                case int n when (days <= 365):
                    thongbao = "Còn 1 năm để hoàn thành mục tiêu!";
                    break;
            }
            if (!string.IsNullOrEmpty(thongbao))
            {
                NotificationHelper.Show($"Mục tiêu: {aim.title}", thongbao);

                try
                {
                    GuiMailThongBao(aim, thongbao);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi gửi mail: " + ex.Message);
                }
            }
        }
        private async void GuiMailThongBao(Aim aim, string tieu_de)
        {
            string html = $@"
            <html>
            <head>
            <style>
                body {{font-family: Arial, sans-serif;background: #f4f6f9;padding: 20px;
                }}
                .card {{background: white;width: 560px;margin: auto;border-radius: 12px;padding: 25px 35px;box-shadow: 0 4px 12px rgba(0,0,0,0.12);
                }}
                .title {{
                    font-size: 24px;color: #2c3e50;font-weight: bold;margin-bottom: 10px;
                }}
                .desc {{
                    font-size: 16px;color: #555;margin-bottom: 20px;line-height: 1.5;
                }}
                .highlight {{
                    padding: 12px 18px;background: #3498db;color: white;display: inline-block;border-radius: 8px;font-size: 16px;
                }}
                .footer {{
                    margin-top:25px;font-size:13px;color:#999;text-align:center;
                }}
            </style>
            </head>
            <body>
                <div class='card'>
                    <div class='title'>{tieu_de}</div>

                    <div class='desc'>
                        <b>Mục tiêu:</b> {aim.title}<br/>
                        <b>Mô tả:</b> {aim.mota}<br/>
                        <b>Bắt đầu:</b> {aim.date_start:dd/MM/yyyy}<br/>
                        <b>Kết thúc:</b> {aim.date_end:dd/MM/yyyy}<br/>
                    </div>

                    <div class='highlight'>
                        Hãy tiếp tục cố gắng để đạt mục tiêu! 
                    </div>

                    <div class='footer'>
                        Email được gửi tự động từ hệ thống quản lý học tập.
                    </div>
                </div>
            </body>
            </html>";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("nguyenthimeow03@gmail.com");
            mail.To.Add(UserSession.Email);
            mail.Subject = tieu_de;
            mail.Body = html;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("nguyenthimeow03@gmail.com", "njec pyjt vrhp djot");
            smtp.EnableSsl = true;

            try
            {
                await smtp.SendMailAsync(mail);
            }
            catch { }
        }

        private void btn_pomo_Click(object sender, EventArgs e)
        {
            pn_content.Controls.Clear();
            var PomodoroControl = new Pomodoro();
            PomodoroControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(PomodoroControl);
        }

        private void btn_aim_Click(object sender, EventArgs e)
        {
            pn_content.Controls.Clear();
            var AimControl = new Muc_tieu();
            AimControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(AimControl);
        }

        private void btn_diary_Click(object sender, EventArgs e)
        {
            
            pn_content.Controls.Clear();

            var diaryControl = new UserControlNhatKy(firebase);
            diaryControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(diaryControl);
        }

    }
}
