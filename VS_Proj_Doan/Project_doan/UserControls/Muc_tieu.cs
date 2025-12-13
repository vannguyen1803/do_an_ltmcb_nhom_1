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
    public partial class Muc_tieu : UserControl
    {
        public Muc_tieu()
        {
            InitializeComponent();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            pn_listAim.Visible = false;
            btn_add.Visible = false;
            pn_newAim.Visible = true;
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            pn_listAim.Visible = true;
            btn_add.Visible = true;
            pn_newAim.Visible = false;
        }
    }
}
