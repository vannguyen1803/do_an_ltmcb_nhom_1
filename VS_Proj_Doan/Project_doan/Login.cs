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
using Project_doan.Models;

namespace Project_doan
{
    public partial class Login : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public Login()
        {
            InitializeComponent();

        }

        private async void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_username.Text.Trim();
                string password = tb_pass.Text.Trim();
                var result = await firebase.SignInAsync(email, password);

                string mand = result.localId;

                if (!string.IsNullOrEmpty(result.idToken))
                {
                    UserSession.MaND = mand;

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void llb_signup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signup signup = new Signup();
            signup.Show();
            this.Hide();
        }

        private void llb_forgot_pass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forgot_pass f_pass = new Forgot_pass();
            f_pass.Show();
            this.Hide();
        }
    }
}
