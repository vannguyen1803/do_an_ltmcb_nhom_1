using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Project_doan.Models;
using Project_doan.Services;

namespace Project_doan.UserControls
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

        public Pomodoro()
        {
            InitializeComponent();
            lb_timepomo.Text = "00:00";
            btn_pomo.Text = "Start";

            cbb_option.Items.Clear();
            cbb_option.Items.Add("25/5");
            cbb_option.Items.Add("50/10");

            timer1.Interval = 1000;
        }
        private void cbb_option_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopAndResetUiOnly();

            string select = cbb_option.SelectedItem.ToString();

            if (select == "25/5")
            {
                workTime = TimeSpan.FromMinutes(1);
                breakTime = TimeSpan.FromMinutes(1);
            }
            else
            {
                workTime = TimeSpan.FromMinutes(50);
                breakTime = TimeSpan.FromMinutes(10);
            }
            lb_timepomo.Text = workTime.ToString(@"mm\:ss");
        }
        private async void btn_pomo_Click(object sender, EventArgs e)
        {
            if (cbb_option.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thời gian", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentState == PomoState.Work || currentState == PomoState.Break)
            {

                await StopAndReset();
            }
            else
            {
                StartWork();
            }
        }
        private void StartWork()
        {     
            lb_pomo.ForeColor = Color.DeepSkyBlue;
            lb_break.ForeColor = Color.Black;
            currentState = PomoState.Work;
            currentTime = workTime;
            lb_timepomo.Text = currentTime.ToString(@"mm\:ss");

            btn_pomo.Text = "Pause";

            timer1.Start();
        }
        private void StartBreak()
        {
            lb_break.ForeColor = Color.DeepSkyBlue;
            lb_pomo.ForeColor = Color.Black;
            currentState = PomoState.Break;
            currentTime = breakTime;
            lb_timepomo.Text = currentTime.ToString(@"mm\:ss");

            timer1.Start();
        }
        private async Task StopAndReset()
        {
            timer1.Stop();
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn dừng?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            if (dialogResult == DialogResult.No)
            {
                timer1.Start();
                return;
            }

            btn_pomo.Text = "Start";

            lb_break.ForeColor = Color.Black;
            lb_pomo.ForeColor = Color.Black;

            lb_timepomo.Text = workTime.ToString(@"mm\:ss");

            PomoState oldState = currentState;
            currentState = PomoState.None;

            if (sessionCount > 0)
            {
                try
                {
                    PomoData log = new PomoData()
                    {
                        MaND = UserSession.MaND,
                        NgayThucHien = DateTime.UtcNow.Date,
                        SoPhien = sessionCount,
                        TongThoiGian = totalMinuteWork,
                        MaPomodoro = Guid.NewGuid().ToString()
                    };
                    await FirestoreService.AddPomo(log);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            sessionCount = 0;
            totalMinuteWork = 0;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            currentTime = currentTime.Subtract(TimeSpan.FromSeconds(1));

            lb_timepomo.Text = currentTime.ToString(@"mm\:ss");

            if (currentTime.TotalSeconds <= 0)
            {
                timer1.Stop();

                if (currentState == PomoState.Work)
                {
                    NotificationHelper.Show("Hết giờ làm!", $"Nghỉ ngơi {breakTime.TotalMinutes} phút nào bạn ơi.");
                    sessionCount++;
                    totalMinuteWork += (int)workTime.TotalMinutes;
                    StartBreak();
                }
                else if (currentState == PomoState.Break)
                {
                    NotificationHelper.Show("Hết giờ nghỉ!", "Quay lại làm việc thôi.");
                    StartWork();
                }
            }
            else
            {
                lb_timepomo.Text = currentTime.ToString(@"mm\:ss");
            }
        }

        private void StopAndResetUiOnly()
        {
            timer1.Stop();
            btn_pomo.Text = "Start";
            lb_break.ForeColor = Color.Black;
            lb_pomo.ForeColor = Color.Black;
            currentState = PomoState.None;
            sessionCount = 0;
            totalMinuteWork = 0;
        }
    }
}