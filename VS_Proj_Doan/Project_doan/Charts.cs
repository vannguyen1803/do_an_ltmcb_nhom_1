using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;     

namespace Project_doan
{
    public partial class Charts : UserControl
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public Charts()
        {
            InitializeComponent();
            comboBox1.Items.Add("Tuần");
            comboBox1.Items.Add("Tháng");
            comboBox1.SelectedIndex = 0;

            this.Load += (s, e) => comboBox1_SelectedIndexChanged(null, null);
        }

        private async void LoadDataBDC(DateTime fromDate, DateTime toDate)
        {
            var stats = await firebase.GetPomodoroStatisticsAsync(fromDate, toDate);

            if (stats == null || stats.Count == 0)
            {
                ShowNoDataMessage(chart1BTC, true);
                chart1BTC.Series[0].Points.Clear();
                return;
            }
            ShowNoDataMessage(chart1BTC, false);

            chart1BTC.Titles.Clear();
            Title title = new Title($"Thời gian học tháng {fromDate.Month}/{fromDate.Year}");
            title.ForeColor = Color.Red;
            chart1BTC.Titles.Add(title);
            chart1BTC.Titles[0].Font = new Font("Arial", 12, FontStyle.Bold);

            chart1BTC.Series[0].Points.Clear();
            
            for(DateTime date = fromDate;date<=toDate;date = date.AddDays(1))
            {
                string datekey = date.ToString("yyyy-MM-dd");
                int minutes = stats.ContainsKey(datekey) ? stats[datekey]:0;

                chart1BTC.Series[0].Points.AddXY(date.ToString("dd"), minutes);
            }
            chart1BTC.ChartAreas[0].AxisX.Title = "Ngày";
            chart1BTC.ChartAreas[0].AxisY.Title = "Phút";
            chart1BTC.ChartAreas[0].AxisX.Interval = 1;
            chart1BTC.Series[0].ToolTip = "#VALY";
        }

        private void LoadDataBDT(List<PomodoroSession> ss)
        {
            chartBDT.Titles.Clear();

            if (ss == null || ss.Count == 0)
            {
                ShowNoDataMessage(chartBDT, true);
                chartBDT.Series[0].Points.Clear();
                return;
            }
            ShowNoDataMessage(chartBDT, false);


            Title title = new Title("Tỷ lệ hoàn thành Pomodoro");
            title.Font = new Font("Arial", 12, FontStyle.Bold);
            title.ForeColor = Color.Red;
            chartBDT.Titles.Add(title);

            int complete = ss.Count(s => s.TrangThai == "Hoàn thành");
            int cancel = ss.Count(s => s.TrangThai == "Hủy");

            chartBDT.Series[0].Points.Clear();
            if (complete > 0 || cancel > 0)
            {
                int p1Index = chartBDT.Series[0].Points.AddXY("Hoàn thành", complete);
                chartBDT.Series[0].Points[p1Index].LegendText = "Hoàn thành"; 
                chartBDT.Series[0].Points[p1Index].Color = Color.FromArgb(66, 133, 244);

                int p2Index = chartBDT.Series[0].Points.AddXY("Hủy", cancel);
                chartBDT.Series[0].Points[p2Index].LegendText = "Hủy"; 
                chartBDT.Series[0].Points[p2Index].Color = Color.FromArgb(255, 183, 77);

                chartBDT.Series[0].Label = "#PERCENT{P0}";
                chartBDT.Legends[0].Enabled = true;
            }
        }

        private async void LoadDataBDD(DateTime fromDate, DateTime toDate)
        {
            var allAim = await firebase.GetAllAimsAsync();

            var dataLine = allAim
                    .Where(a => a.status == AimStatus.HoanThanh &&
                                a.date_end.Date >= fromDate.Date &&
                                a.date_end.Date <= toDate.Date)
                    .GroupBy(a => a.date_end.Date)
                    .OrderBy(g => g.Key)
                    .ToList();

            if (dataLine.Count == 0)
            {
                ShowNoDataMessage(chartBDD, true);
                chartBDD.Series[0].Points.Clear();
                return;
            }
            ShowNoDataMessage(chartBDD, false);

            chartBDD.Titles.Clear();
            Title title = new Title("Thống kê mục tiêu");
            title.Font = new Font("Arial", 12, FontStyle.Bold);
            title.ForeColor = Color.Red;
            chartBDD.Titles.Add(title);

            chartBDD.Series[0].Points.Clear();
            chartBDD.Series[0].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            chartBDD.Series[0].BorderWidth = 3;
            chartBDD.ChartAreas[0].AxisY.Interval = 1;
            chartBDD.ChartAreas[0].AxisY.Minimum = 0;
            chartBDD.Series[0].ToolTip = "#VALY";
            chartBDD.ChartAreas[0].AxisX.Title = "Ngày";
            chartBDD.ChartAreas[0].AxisY.Title = "Hoàn thành";

            foreach (var gr in dataLine)
            {
                chartBDD.Series[0].Points.AddXY(gr.Key.ToString("dd"), gr.Count());
            }
        }

        private void ShowNoDataMessage(Chart chart, bool isEmpty)
        {
            chart.Titles.Clear();


            if (isEmpty)
            {
                Title noData = new Title();
                noData.Text = "Chưa có dữ liệu";
                noData.ForeColor = Color.Gray;
                noData.Font = new Font("Segoe UI", 10, FontStyle.Italic);

                noData.Docking = Docking.Bottom;
                noData.Alignment = ContentAlignment.MiddleLeft;

                chart.Titles.Add(noData);

                if (chart.Series.Count > 0) chart.Series[0].Enabled = false;
            }
            else
            {
                if (chart.Series.Count > 0) chart.Series[0].Enabled = true;
            }


        }
        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime toDate = DateTime.Today;
            DateTime fromDate = (comboBox1.Text == "Tuần")
                ? toDate.AddDays(-6)
                : new DateTime(toDate.Year, toDate.Month, 1);

            LoadDataBDC(fromDate, toDate);
            LoadDataBDD(fromDate, toDate);

            var ss = await firebase.GetPomoInRange(fromDate, toDate);
            LoadDataBDT(ss);
        }

        public void LoadData()
        {
            comboBox1_SelectedIndexChanged(null, null);
        }
    }
}
