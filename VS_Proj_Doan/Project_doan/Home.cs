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
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

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
            var calendarControl = new Calendar();
            calendarControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(calendarControl);
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
            var acc = new Account();
            acc.Dock = DockStyle.Fill;
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
            var note = new Ghi_chu();
            note.Dock = DockStyle.Fill;
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
        }

        private void btn_diary_Click(object sender, EventArgs e)
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.FromArgb(51, 153, 255);
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.Transparent;
        }

        private void btn_pomo_Click(object sender, EventArgs e)
        {
            btn_cal.FillColor = Color.Transparent;
            btn_aim.FillColor = Color.Transparent;
            btn_note.FillColor = Color.Transparent;
            btn_diary.FillColor = Color.Transparent;
            btn_acc.FillColor = Color.Transparent;
            btn_pomo.FillColor = Color.FromArgb(51, 153, 255);
        }



    }
}
