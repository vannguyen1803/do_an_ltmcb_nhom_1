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

namespace Project_doan
{
    public partial class Home : Form
    {
        Aim aim;
        private FirebaseAuthService _firebaseService;
        private NhatKy _nhatKyForm;
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            if (aim != null)
            {
                KiemTraVaGuiMail(aim);
            }
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
            TimeSpan conLai = aim.date_end - DateTime.Now;
            int days = conLai.Days;

            if (days == 30)
            {
                GuiMailThongBao(aim, "Còn 1 tháng để hoàn thành mục tiêu!");
            }
            else if (days == 7)
            {
                GuiMailThongBao(aim, "Còn 1 tuần để hoàn thành mục tiêu!");
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
            Hãy tiếp tục cố gắng để đạt mục tiêu! 💪🔥
        </div>

        <div class='footer'>
            Email được gửi tự động từ hệ thống Aim Tracker.
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
            smtp.Credentials = new NetworkCredential("yourmail@gmail.com", "app-password");
            smtp.EnableSsl = true;

            smtp.Send(mail);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (_firebaseService == null)
            {
                _firebaseService = new FirebaseAuthService();
            }
            if (_nhatKyForm == null)
            {
                _nhatKyForm = new NhatKy(_firebaseService);
                _nhatKyForm.Dock = DockStyle.Fill;
                _nhatKyForm.BackToListRequested += NhatKy_BackToListRequested;
            }
            pn_content.Controls.Clear();

            var diaryControl = new UserControlNhatKyList(_firebaseService);
            diaryControl.Dock = DockStyle.Fill;
            diaryControl.EntrySelected += (documentId) =>
            {
                _nhatKyForm.LoadEntryFromFirestore(documentId);
                pn_content.Controls.Clear();
                pn_content.Controls.Add(_nhatKyForm);
            };
            pn_content.Controls.Add(diaryControl);
        }
        private void NhatKy_BackToListRequested()
        {
            pn_content.Controls.Clear();
            var listControl = new UserControlNhatKyList(_firebaseService);
            listControl.Dock = DockStyle.Fill;
            listControl.EntrySelected += (documentId) =>
            {
                _nhatKyForm.LoadEntryFromFirestore(documentId);
                pn_content.Controls.Clear();
                pn_content.Controls.Add(_nhatKyForm);
            };

            pn_content.Controls.Add(listControl);
        }
        private void pn_content_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
