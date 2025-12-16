using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Forgot_pass : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public Forgot_pass()
        {
            InitializeComponent();
        }

        private async void guna2Button_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_email.Text.Trim();
                string result = await firebase.ResetPasswordAsync(email);
                MessageBox.Show("Đã gửi về email khôi phục mật khẩu");
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
