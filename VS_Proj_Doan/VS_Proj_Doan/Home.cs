using Google.Cloud.Firestore;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VS_Proj_Doan
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

        }
        
        private void btn_tgb_Click(object sender, EventArgs e)
        {
            btn_tgb.BackColor = Color.LightSteelBlue;
            btn_acc.BackColor = Color.Transparent;
            btn_aim.BackColor = Color.Transparent;
            btn_clock.BackColor = Color.Transparent;
            btn_note.BackColor = Color.Transparent;
            btn_pomo.BackColor = Color.Transparent;
        }

        private void btn_aim_Click(object sender, EventArgs e)
        {
            btn_tgb.BackColor = Color.Transparent;
            btn_acc.BackColor = Color.Transparent;
            btn_aim.BackColor = Color.LightSteelBlue;
            btn_clock.BackColor = Color.Transparent;
            btn_note.BackColor = Color.Transparent;
            btn_pomo.BackColor = Color.Transparent;
        }

        private void btn_note_Click(object sender, EventArgs e)
        {
            btn_tgb.BackColor = Color.Transparent;
            btn_acc.BackColor = Color.Transparent;
            btn_aim.BackColor = Color.Transparent;
            btn_clock.BackColor = Color.Transparent;
            btn_note.BackColor = Color.LightSteelBlue;
            btn_pomo.BackColor = Color.Transparent;
        }

        private void btn_clock_Click(object sender, EventArgs e)
        {
            btn_tgb.BackColor = Color.Transparent;
            btn_acc.BackColor = Color.Transparent;
            btn_aim.BackColor = Color.Transparent;
            btn_clock.BackColor = Color.LightSteelBlue;
            btn_note.BackColor = Color.Transparent;
            btn_pomo.BackColor = Color.Transparent;
        }

        private void btn_pomo_Click(object sender, EventArgs e)
        {
            btn_tgb.BackColor = Color.Transparent;
            btn_acc.BackColor = Color.Transparent;
            btn_aim.BackColor = Color.Transparent;
            btn_clock.BackColor = Color.Transparent;
            btn_note.BackColor = Color.Transparent;
            btn_pomo.BackColor = Color.LightSteelBlue;
        }

        private void btn_acc_Click(object sender, EventArgs e)
        {
            btn_tgb.BackColor = Color.Transparent;
            btn_acc.BackColor = Color.LightSteelBlue;
            btn_aim.BackColor = Color.Transparent;
            btn_clock.BackColor = Color.Transparent;
            btn_note.BackColor = Color.Transparent;
            btn_pomo.BackColor = Color.Transparent;
        }
    }
}
