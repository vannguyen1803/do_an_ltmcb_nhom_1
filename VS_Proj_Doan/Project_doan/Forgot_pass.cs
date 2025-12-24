using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Forgot_pass : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        private string currentEmail = "";
        private string tempOTP = "";
        private int step = 1; // 1  email, 2 OTP, 3  password mới
        public Forgot_pass()
        {
            InitializeComponent();
            ShowStep1();
        }
        private void ShowStep1()
        {
            step = 1;
            label2.Text = "Reset password";
            label5.Text = "Email";
            tb_email.Clear();
            btn_fpass.Text = "Gửi mã OTP";
        }

        private void ShowStep2()
        {
            step = 2;
            label2.Text = "Xác thực OTP";
            label5.Text = $"Mã OTP đã gửi về {currentEmail}";
            tb_email.Clear();
            tb_email.MaxLength = 6;
            btn_fpass.Text = "Xác nhận OTP";
        }
        private void ShowStep3()
        {
            step = 3;
            label2.Text = "Đổi mật khẩu mới";
            tb_email.Clear();
            tb_email.MaxLength = 100;
            btn_fpass.Text = "Đổi mật khẩu";
        }

        private async void guna2Button_Click(object sender, EventArgs e)
        {
            try
            {
                btn_fpass.Enabled = false;
                string input = tb_email.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    MessageBox.Show("Vui lòng nhập thông tin!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (step == 1)
                {
                    currentEmail = input;

                    btn_fpass.Text = "Đang gửi";
                    string result = await firebase.SendOTPAsync(currentEmail);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Mã OTP đã được gửi về email!",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ShowStep2();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btn_fpass.Text = "Gửi mã OTP";
                    }
                }
                else if (step == 2) // Xác nhận OTP
                {
                    tempOTP = input;

                    string result = firebase.VerifyOTP(currentEmail, tempOTP);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Xác thực OTP thành công!\n\nVui lòng nhập mật khẩu mới.", "Thành công", MessageBoxButtons.OK,
                           MessageBoxIcon.Information);
                        ShowStep3();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (step == 3)
                {
                    string newPassword = input;
                    if (newPassword.Length < 6)
                    {
                        MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    btn_fpass.Text = "Đang xử lý";
                    string result = await firebase.ResetPasswordAsync(currentEmail, newPassword);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!\n\nVui lòng đăng nhập lại.", "Thành công", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                        Login login = new Login();
                        login.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btn_fpass.Text = "Đổi mật khẩu";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_fpass.Enabled = true;
            } 
        }
    }
}
