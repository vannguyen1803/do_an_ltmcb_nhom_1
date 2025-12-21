using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Home : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        private Calendar calendar;
        private Account acc;
        private Ghi_chu note;
        private NhatKy _nhatKyForm;
        private Muc_tieu muc_Tieu;
        private Charts chart;
        Aim aim;
        
        
        private Pomodoro pom;
        private thongke_pomodoro tk_pom;

        public Home()
        {
            InitializeComponent();
            
        }

        private async void Home_Load(object sender, EventArgs e)
        {
            lb_name.Text = UserSession.HoTen.ToString();
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

                muc_Tieu = new Muc_tieu();
                muc_Tieu.Dock = DockStyle.Fill;

                pom = new Pomodoro();
                pom.Dock = DockStyle.Fill;

                tk_pom = new thongke_pomodoro();
                tk_pom.Dock = DockStyle.Fill;

                chart = new Charts();
                chart.Dock = DockStyle.Fill;

                if (aim != null)
                {
                    KiemTraVaGuiMail(aim);
                }

                pn_content.Controls.Clear();
                pn_content.Controls.Add(chart);
                btn_nha.FillColor = Color.FromArgb(51, 153, 255);
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
            pn_content.Controls.Clear();
            if (muc_Tieu != null)
            {
                pn_content.Controls.Add(muc_Tieu);
            }
            
        }

        private void btn_diary_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_diary.FillColor = Color.FromArgb(51, 153, 255);
            
            if (firebase == null)
            {
                firebase = new FirebaseAuthService();
            }
            if (_nhatKyForm == null)
            {
                _nhatKyForm = new NhatKy(firebase);
                _nhatKyForm.Dock = DockStyle.Fill;
                _nhatKyForm.BackToListRequested += NhatKy_BackToListRequested;
            }
            pn_content.Controls.Clear();

            var diaryControl = new UserControlNhatKyList(firebase);
            diaryControl.Dock = DockStyle.Fill;
            diaryControl.NewEntryRequested += () =>
            {
                _nhatKyForm.PrepareForNewEntry();
                pn_content.Controls.Clear();
                pn_content.Controls.Add(_nhatKyForm);
            };
            diaryControl.EntrySelected += (documentId) =>
            {
                _nhatKyForm.LoadEntryFromFirestore(documentId);
                pn_content.Controls.Clear();
                pn_content.Controls.Add(_nhatKyForm);
            };
            pn_content.Controls.Add(diaryControl);
        }
        private void btn_pomo_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_pomo.FillColor = Color.FromArgb(51, 153, 255);
            pn_content.Controls.Clear();
            var PomodoroControl = new Pomodoro();
            PomodoroControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(PomodoroControl);
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

        private void NhatKy_BackToListRequested()
        {
            pn_content.Controls.Clear();
            var listControl = new UserControlNhatKyList(firebase);
            listControl.Dock = DockStyle.Fill;
            listControl.EntrySelected += (documentId) =>
            {
                _nhatKyForm.LoadEntryFromFirestore(documentId);
                pn_content.Controls.Clear();
                pn_content.Controls.Add(_nhatKyForm);
            };

            pn_content.Controls.Add(listControl);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            pn_content.Controls.Clear();
            if (tk_pom != null) pn_content.Controls.Add(tk_pom);
        }

        private void btn_nha_Click(object sender, EventArgs e)
        {
            ResetButtonColors();
            btn_nha.FillColor = Color.FromArgb(51, 153, 255);
            pn_content.Controls.Clear();

            if (chart != null)
            {
                pn_content.Controls.Add(chart);
                chart.LoadData();
            }
        }
    }
}