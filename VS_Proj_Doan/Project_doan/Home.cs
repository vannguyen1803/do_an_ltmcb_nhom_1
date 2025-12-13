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
using Project_doan.Models;
using Project_doan.UserControls;
namespace Project_doan
{
    public partial class Home : Form
    {
        Aim aim;
        

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_cal_Click(object sender, EventArgs e)
        {
            pn_content.Controls.Clear();
            var calendarControl = new Calendar();
            calendarControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(calendarControl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.ShowDialog();
        }
        private void KiemTraVaGuiMail(Aim aim)
        {
            TimeSpan conlai = aim.date_end - DateTime.Now;
            int days = conlai.Days;

            switch (days)
            {
                case int n when (days <= 1):
                    GuiMailThongBao(aim, "Ngày cuối cùng để hoàn thành mục tiêu!");
                    break;
                case int n when (days <= 7):
                    GuiMailThongBao(aim, "Tuần cuối cùng để hoàn thành mục tiêu!");
                    break;
                case int n when (days <= 14):
                    GuiMailThongBao(aim, "Còn 2 tuần để hoàn thành mục tiêu!");
                    break;
                case int n when (days <= 30):
                    GuiMailThongBao(aim, "Còn 1 tháng để hoàn thành mục tiêu!");
                    break;
                case int n when (days <= 60):
                    GuiMailThongBao(aim, "Còn 2 tháng để hoàn thành mục tiêu!");
                    break;
                case int n when (days <= 90):
                    GuiMailThongBao(aim, "Còn 3 tháng để hoàn thành mục tiêu!");
                    break;
                case int n when (days <= 180):
                    GuiMailThongBao(aim, "Còn 6 tháng để hoàn thành mục tiêu!");
                    break;
                case int n when (days <= 365):
                    GuiMailThongBao(aim, "Còn 1 năm để hoàn thành mục tiêu!");
                    break;

            }
        }
        private void GuiMailThongBao(Aim aim, string tieu_de)
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
            <b>Mục tiêu:</b> {aim.ten}<br/>
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

            smtp.Send(mail);
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
    }
}
