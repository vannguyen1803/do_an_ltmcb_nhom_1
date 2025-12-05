using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Schedule_1 : Form
    {
        private Dictionary<Panel, DateTime> panelDateMap = new Dictionary<Panel, DateTime>();
        private Dictionary<Panel, Label> panelTaskLabelMap = new Dictionary<Panel, Label>();
        FirestoreUserService firebase = new FirestoreUserService();

        public Schedule_1()
        {
            InitializeComponent();
        }


        private async void Schedule_1_Load(object sender, EventArgs e)
        {
            DateTime month = DateTime.Now;
            int days = DateTime.DaysInMonth(month.Year, month.Month);

            List<Panel> panels = new List<Panel>()
            {
                panel1, panel2, panel3, panel4, panel5, panel6, panel7,
                panel8, panel9, panel10, panel11, panel12, panel13, panel14,
                panel15, panel16, panel17, panel18, panel19, panel20, panel21,
                panel22, panel23, panel24, panel25, panel26, panel27, panel28,
                panel29, panel30, panel31
            };

            

            for (int i = 0; i < days; i++)
            {
                DateTime d = new DateTime(month.Year, month.Month, i + 1);
                Panel p = panels[i];


                p.Click += Panel_Click;

                await LoadTaskForPanel(p, d);
            }

        }
        private async Task LoadTaskForPanel(Panel panel, DateTime date)
        {
            try
            {
                string content = await firebase.GetScheduleAsync(date);

                if (!string.IsNullOrEmpty(content))
                {
                    if (panelTaskLabelMap.ContainsKey(panel))
                    {
                        string preview = content.Length > 50
                            ? content.Substring(0, 50) + "..."
                            : content;
                        panelTaskLabelMap[panel].Text = preview;
                        panel.BackColor = Color.LightYellow;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load task: " + ex.Message);
            }
        }

        private async void Panel_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel panel = ctrl as Panel ?? ctrl.Parent as Panel;

            if (panel == null || !panelDateMap.ContainsKey(panel))
                return;

            DateTime selectedDate = panelDateMap[panel];
            ScheduleNotes_1 noteForm = new ScheduleNotes_1(selectedDate);

            if (noteForm.ShowDialog() == DialogResult.OK)
            {
                await LoadTaskForPanel(panel, selectedDate);
            }
        }
        public async Task RefreshCalendar()
        {
            foreach (var kvp in panelDateMap)
            {
                await LoadTaskForPanel(kvp.Key, kvp.Value);
            }
        }
    }
}
