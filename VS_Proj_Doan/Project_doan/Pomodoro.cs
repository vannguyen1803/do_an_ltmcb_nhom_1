using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Pomodoro : UserControl
    {
        public enum PomoState
        {
            None,
            Work,
            Break
        }

        private TimeSpan workTime;
        private TimeSpan breakTime;
        private TimeSpan currentTime;
        private PomoState currentState = PomoState.None;

        private int sessionCount = 0;
        private int totalMinuteWork = 0;

        private PomodoroSession currentSession;
        private FirebaseAuthService firebase = new FirebaseAuthService();
        private Timer timer1;

        private float progressAngle = 0f;

        public Pomodoro()
        {
            InitializeComponent();



            timer1 = new Timer();
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            lb_timepomo.Text = "00:00";
            btn_pomo.Text = "Start";

            cbb_option.Items.Clear();
            cbb_option.Items.Add("25/5");
            cbb_option.Items.Add("50/10");
            cbb_option.SelectedIndex = 0;

            lb_pomo.ForeColor = Color.Black;
            lb_break.ForeColor = Color.Black;

            LoadTodayStats();
        }

        private void Pomodoro_Load(object sender, EventArgs e)
        {
            cbb_option.SelectedIndex = 0;
            UpdateCircularProgress();
        }

        private void cbb_option_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = cbb_option.SelectedItem.ToString();

            if (select == "25/5")
            {
                workTime = TimeSpan.FromMinutes(25);
                breakTime = TimeSpan.FromMinutes(5);
            }
            else
            {
                workTime = TimeSpan.FromMinutes(50);
                breakTime = TimeSpan.FromMinutes(10);
            }

            if (currentState == PomoState.None)
            {
                lb_timepomo.Text = workTime.ToString(@"mm\:ss");
            }
        }

        private async void btn_pomo_Click(object sender, EventArgs e)
        {
            if (cbb_option.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thời gian", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentState == PomoState.Work || currentState == PomoState.Break)
            {
                await StopAndSave();
            }
            else
            {
                StartWork();
            }
        }

        private void StartWork()
        {
            lb_pomo.ForeColor = Color.White;
            lb_break.ForeColor = Color.Black;
            btn_pomo.Text = "Finish";
            cbb_option.Enabled = false;

            currentState = PomoState.Work;
            currentTime = workTime;
            lb_timepomo.Text = currentTime.ToString(@"mm\:ss");

            currentSession = new PomodoroSession
            {
                PhutHoc = (int)workTime.TotalMinutes,
                PhutNghi = (int)breakTime.TotalMinutes,
                NgayBatDau = DateTime.Now,
                TrangThai = "Đang học"
            };

            timer1.Start();
            UpdateCircularProgress();
        }

        private void StartBreak()
        {
            lb_break.ForeColor = Color.White;
            lb_pomo.ForeColor = Color.Black;

            currentState = PomoState.Break;
            currentTime = breakTime;
            lb_timepomo.Text = currentTime.ToString(@"mm\:ss");

            if (currentSession != null)
            {
                currentSession.TrangThai = "Nghỉ";
            }

            timer1.Start();
            UpdateCircularProgress();
        }

        private async Task StopAndSave()
        {
            timer1.Stop();

            DialogResult dialogResult = MessageBox.Show(
                "Bạn có chắc chắn muốn dừng?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (dialogResult == DialogResult.No)
            {
                timer1.Start();
                return;
            }

            if (currentSession != null)
            {
                await FinishSession(false);
            }

            ResetUI();
        }

        private async Task FinishSession(bool completed)
        {
            if (currentSession == null)
                return;
            int phutThucTe = (int)workTime.TotalMinutes;
            if (currentState == PomoState.Work)
            {
                TimeSpan studied = workTime.Subtract(currentTime);
                phutThucTe = (int)studied.TotalMinutes;
            }
            try
            {
                currentSession.NgayKetThuc = DateTime.Now;
                currentSession.TongPhutHocThucTe = phutThucTe;
                currentSession.TrangThai = completed ? "Hoàn thành" : "Hủy";

                string result = await firebase.SavePomodoroSessionAsync(currentSession);

                if (result == "SUCCESS")
                {
                    if (completed)
                    {
                        totalMinuteWork += phutThucTe;
                    }

                    MessageBox.Show(
                        $"Đã lưu phiên học!\nThời gian học: {currentSession.TongPhutHocThucTe} phút",
                        "Thành công",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    LoadTodayStats();
                }
                else
                {
                    MessageBox.Show("Lỗi lưu dữ liệu: " + result, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime = currentTime.Subtract(TimeSpan.FromSeconds(1));
            lb_timepomo.Text = currentTime.ToString(@"mm\:ss");

            UpdateCircularProgress();

            if (currentTime.TotalSeconds <= 0)
            {
                timer1.Stop();

                if (currentState == PomoState.Work)
                {
                    MessageBox.Show(
                        $"Đã học xong {workTime.TotalMinutes} phút!\nGiờ nghỉ {breakTime.TotalMinutes} phút.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    sessionCount++;
                    totalMinuteWork += (int)workTime.TotalMinutes;

                    StartBreak();
                }
                else if (currentState == PomoState.Break)
                {
                    HandleCompleteBreak();
                }
            }
        }
        private async void HandleCompleteBreak()
        {
            await FinishSession(true);
            ResetUI();
        }
        private void ResetUI()
        {
            timer1.Stop();

            btn_pomo.Text = "Start";
            lb_break.ForeColor = Color.Black;
            lb_pomo.ForeColor = Color.Black;

            lb_timepomo.Text = workTime.ToString(@"mm\:ss");

            currentState = PomoState.None;
            currentSession = null;
            cbb_option.Enabled = true;

            progressAngle = 0f;
            UpdateCircularProgress();
        }

        private void UpdateCircularProgress()
        {
            if (panel_circle != null)
            {
                if (currentState == PomoState.Work)
                {
                    float total = (float)workTime.TotalSeconds;
                    float remaining = (float)currentTime.TotalSeconds;
                    progressAngle = ((total - remaining) / total) * 360f;
                }
                else if (currentState == PomoState.Break)
                {
                    float total = (float)breakTime.TotalSeconds;
                    float remaining = (float)currentTime.TotalSeconds;
                    progressAngle = ((total - remaining) / total) * 360f;
                }
                else
                {
                    progressAngle = 0f;
                }

                panel_circle.Invalidate();
            }
        }

        private void panel_circle_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int diameter = Math.Min(panel_circle.Width, panel_circle.Height) - 20;
            int x = (panel_circle.Width - diameter) / 2;
            int y = (panel_circle.Height - diameter) / 2;

            Rectangle rect = new Rectangle(x, y, diameter, diameter);

            using (Pen penBackground = new Pen(Color.FromArgb(200, 200, 200), 8))
            {
                g.DrawEllipse(penBackground, rect);
            }

            if (progressAngle > 0)
            {
                Color progressColor = currentState == PomoState.Work
                    ? Color.FromArgb(100, 200, 100)
                    : Color.FromArgb(255, 165, 0);

                using (Pen penProgress = new Pen(progressColor, 8))
                {
                    g.DrawArc(penProgress, rect, -90, progressAngle);
                }
            }
        }

        private async void LoadTodayStats()
        {
            try
            {
                if (firebase == null)
                {
                    firebase = new FirebaseAuthService();
                }

                int totalMinutes = await firebase.GetTotalMinutesTodayAsync();


            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error loading stats: " + ex.Message);
            }
        }
    }
}