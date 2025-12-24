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
    public partial class Signup : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public Signup()
        {
            InitializeComponent();
        }

        private async void btn_signup_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_email.Text.Trim();
                string password = tb_pass.Text.Trim();
                string user = tb_username.Text.Trim();
                string full_name = tb_fullname.Text.Trim();
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
                string result = await firebase.SignUpAsync(user, hashedPassword, email, full_name);
                if (result == "SUCCESS")
                {
                    Login login = new Login();
                    login.Show();
                    this.Close();
                }
                else MessageBox.Show($"{result}", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
