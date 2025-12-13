using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_doan
{
    public partial class Pomodoro : UserControl
    {
        private Timer timer;
        private PomodoroSession currentSession;
        private FirebaseAuthService firebase = new FirebaseAuthService();

        private int totalSeconds;      
        private int remainingSeconds;  
        private bool isStudyTime;      
        private int studyMinutes;
        private int breakMinutes;
        public Pomodoro()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick;
            remainingSeconds = 0;
            isStudyTime = false;
        }

        private void Pomodoro_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            button1.Enabled = true;
            button2.Enabled = false;

            UpdateDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                studyMinutes = 25;
                breakMinutes = 5;
            }
            else
            {
                studyMinutes = 50;
                breakMinutes = 10;
            }
            currentSession = new PomodoroSession
            {
                PhutHoc = studyMinutes,
                PhutNghi = breakMinutes,
                NgayBatDau = DateTime.Now,
                TrangThai = "Đang học"
            };
            isStudyTime = true;
            totalSeconds = studyMinutes * 60;
            remainingSeconds = totalSeconds;
            
            button1.Enabled = false;
            button2.Enabled = true;
            comboBox1.Enabled = false;

            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            remainingSeconds--;

            UpdateDisplay();

            if (remainingSeconds <= 0)
            {
                if (isStudyTime)
                {
                    timer.Stop();
                    MessageBox.Show($"Đã học xong {studyMinutes} phút!\nGiờ nghỉ {breakMinutes} phút.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    isStudyTime = false;
                    remainingSeconds = breakMinutes * 60;
                    currentSession.TrangThai = "Nghỉ";

                    timer.Start();
                }
                else
                {
                    timer.Stop();
                    FinishSession(true);
                }
            }
        }
        private void UpdateDisplay()
        {
            int minutes = remainingSeconds / 60;
            int seconds = remainingSeconds % 60;

            label1.Text = $"{minutes:D2}:{seconds:D2}";

            if (isStudyTime)
            {
                label2.Text = "Đang học";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = "Đang nghỉ";
                label2.ForeColor = Color.Orange;
            }

            if (isStudyTime)
            {
                int totalStudySeconds = studyMinutes * 60;
                progressBar1.Maximum = totalStudySeconds;
                progressBar1.Value = totalStudySeconds - remainingSeconds;
            }
            else
            {
                int totalBreakSeconds = breakMinutes * 60;
                progressBar1.Maximum = totalBreakSeconds;
                progressBar1.Value = totalBreakSeconds - remainingSeconds;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show( "Bạn có chắc muốn dừng phiên học này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                timer.Stop();
                FinishSession(false);
            }
        }
        private async void FinishSession(bool completed)
        {
            if (currentSession == null)
                return;

            currentSession.NgayKetThuc = DateTime.Now;

            if (isStudyTime)
            {
                int studiedSeconds = (studyMinutes * 60) - remainingSeconds;
                currentSession.TongPhutHocThucTe = studiedSeconds / 60;
            }
            else
            {
                currentSession.TongPhutHocThucTe = studyMinutes;
            }

            currentSession.TrangThai = completed ? "Hoàn thành" : "Hủy";

            string result = await firebase.SavePomodoroSessionAsync(currentSession);

            if (result == "SUCCESS")
            {
                MessageBox.Show(
                    $"Đã lưu phiên học!\nThời gian học: {currentSession.TongPhutHocThucTe} phút",
                    "Thành công",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                ResetUI();
            }
            else
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + result, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetUI()
        {
            timer.Stop();
            remainingSeconds = 0;
            currentSession = null;

            button1.Enabled = true;
            button2.Enabled = false;
            comboBox1.Enabled = true;

            label1.Text = "00:00";
            label2.Text = "Chưa bắt đầu";
            label2.ForeColor = Color.Gray;
            progressBar1.Value = 0;
        }

       
    }
}
