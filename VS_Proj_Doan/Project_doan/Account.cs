using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Account : UserControl
    {
        public Account()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            EditUser edit = new EditUser();
            edit.FormClosed += (s, args) => LoadUserInfo();
            edit.ShowDialog();
        }
        private void LoadUserInfo()
        {
            txt_email.Text = UserSession.Email.ToString();
            txt_user.Text = UserSession.HoTen.ToString();
            txt_hoten.Text = UserSession.Username.ToString();
            txt_phone.Text = UserSession.Phone ?? "";
            txt_date.Text = UserSession.Birthday == DateTime.MinValue
                ? ""
                : UserSession.Birthday.ToString("MM/dd/yyyy");
        }

        private void Account_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
            "Bạn có chắc chắn muốn đăng xuất?",
            "Xác nhận đăng xuất",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

            if (result == DialogResult.Yes)
            {
                FirebaseAuthService firebase = new FirebaseAuthService();
                firebase.LogOut();

                Login login = new Login();
                login.Show();

                Form home = this.FindForm();
                if (home != null)
                {
                    home.Close();
                }
            }

        }
    }
}
