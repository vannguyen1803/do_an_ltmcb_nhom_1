using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class thongke_pomodoro : UserControl
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public thongke_pomodoro()
        {
            InitializeComponent();
        }

        private void thongke_pomodoro_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today.AddDays(-6); // chon hien may ngay
            dateTimePicker2.Value = DateTime.Today;
            LoadStatistics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadStatistics();

        }
        private async void LoadStatistics()
        {
            try
            {
                DateTime fromDate = dateTimePicker1.Value.Date;
                DateTime toDate = dateTimePicker2.Value.Date;

                var stats = await firebase.GetPomodoroStatisticsAsync(fromDate, toDate);

                dataGridView1.Rows.Clear();

                int totalMinutes = 0;

                for (DateTime date = fromDate; date <= toDate; date = date.AddDays(1))
                {
                    string dateKey = date.ToString("yyyy-MM-dd");
                    int minutes = stats.ContainsKey(dateKey) ? stats[dateKey] : 0;
                    totalMinutes += minutes;

                    int hours = minutes / 60;
                    int remainMinutes = minutes % 60;

                    dataGridView1.Rows.Add(
                        date.ToString("dd/MM/yyyy"),
                        date.ToString("dddd"),
                        minutes,
                        $"{hours}h {remainMinutes}m"
                    );
                }

                lblTotal.Text = $"Tổng: {totalMinutes} phút ({totalMinutes / 60}h {totalMinutes % 60}m)";
                lblAverage.Text = $"Trung bình: {totalMinutes / ((toDate - fromDate).Days + 1)} phút/ngày";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
            LoadStatistics();
        }
    }
}
