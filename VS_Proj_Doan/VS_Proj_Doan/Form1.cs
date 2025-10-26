namespace VS_Proj_Doan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_tgb_Click(object sender, EventArgs e)
        {
            btn_tgb.BackColor = Color.LightSteelBlue;
            pn_tgb.Visible = true;
            pn_note.Visible = false;
            pn_aim.Visible = false;
            pn_acc.Visible = false;
            pn_clock.Visible = false;
            pn_pomo.Visible = false;
        }

        private void btn_aim_Click(object sender, EventArgs e)
        {
            btn_aim.BackColor = Color.LightSteelBlue;
            pn_tgb.Visible = false;
            pn_note.Visible = false;
            pn_aim.Visible = true;
            pn_acc.Visible = false;
            pn_clock.Visible = false;
            pn_pomo.Visible = false;

        }

        private void btn_note_Click(object sender, EventArgs e)
        {
            btn_note.BackColor = Color.LightSteelBlue;
            pn_tgb.Visible = false;
            pn_note.Visible = true;
            pn_aim.Visible = false;
            pn_acc.Visible = false;
            pn_clock.Visible = false;
            pn_pomo.Visible = false;
        }

        private void btn_clock_Click(object sender, EventArgs e)
        {
            btn_clock.BackColor = Color.LightSteelBlue;
            pn_tgb.Visible = false;
            pn_note.Visible = false;
            pn_aim.Visible = false;
            pn_acc.Visible = false;
            pn_clock.Visible = true;
            pn_pomo.Visible = false;
        }

        private void btn_pomo_Click(object sender, EventArgs e)
        {
            btn_pomo.BackColor = Color.LightSteelBlue;
            pn_tgb.Visible = false;
            pn_note.Visible = false;
            pn_aim.Visible = false;
            pn_acc.Visible = false;
            pn_clock.Visible = false;
            pn_pomo.Visible = true;
        }

        private void btn_acc_Click(object sender, EventArgs e)
        {
            btn_acc.BackColor = Color.LightSteelBlue;
            pn_tgb.Visible = false;
            pn_note.Visible = false;
            pn_aim.Visible = false;
            pn_acc.Visible = true;
            pn_clock.Visible = false;
            pn_pomo.Visible = false;
        }
    }
}
