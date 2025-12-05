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
            pn_content.Controls.Clear();
            var calendarControl = new Calendar();
            calendarControl.Dock = DockStyle.Fill;
            pn_content.Controls.Add(calendarControl);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.ShowDialog();
        }
    }
}
