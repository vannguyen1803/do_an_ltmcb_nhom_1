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
    public partial class Forgot_pass : Form
    {
        FirestoreUserService firebase = new FirestoreUserService();
        public Forgot_pass()
        {
            InitializeComponent();
        }

        private async void guna2Button_Click(object sender, EventArgs e)
        {
            try
            {
                string email = guna2Button1.Text.Trim();
                string result = await firebase.ResetPasswordAsync(email);
                MessageBox.Show("Đã gửi về email khôi phục mật khẩu");
                Login login = new Login();
                login.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
