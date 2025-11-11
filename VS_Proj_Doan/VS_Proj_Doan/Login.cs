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
using Newtonsoft.Json.Linq;
namespace VS_Proj_Doan
{
    public partial class Login : Form

    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public Login()
        {

            InitializeComponent();
        }

        private async void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_usrname.Text.Trim();
                string password = tb_pass.Text.Trim();
                string result = await firebase.SignInAsync(email, password);
                var json = JObject.Parse(result);
                string idToken = json["idToken"]?.ToString();
                MessageBox.Show("Đăng nhập thành công");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Lỗi");
            }

        }

        private async void btn_forget_pass_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_usrname.Text.Trim();
                string result = await firebase.ResetPasswordAsync(email);
                
                MessageBox.Show("Đã gửi về email khôi phục mật khẩu");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string email = tb_usrname.Text.Trim();
                string password = tb_pass.Text.Trim();
                string result = await firebase.SignUpAsync(email, password);
                var json = JObject.Parse(result);

                string localId = json["localId"].ToString();
                MessageBox.Show("Đăng ký thành công");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi");
            }
        }
    }
}
