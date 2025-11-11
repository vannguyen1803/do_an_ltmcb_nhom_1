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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_signup_Click(object sender, EventArgs e)
        {
            Signup signup = new Signup();
            signup.Owner = this;
            signup.Show();
        }

        private void btn_forget_pass_Click(object sender, EventArgs e)
        {
            forget_pass pass_reset = new forget_pass();
            pass_reset.Owner = this;
            pass_reset.Show();
        }
    }
}
