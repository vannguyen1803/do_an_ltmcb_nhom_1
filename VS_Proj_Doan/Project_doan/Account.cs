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
            txt_hoten.Text = UserSession.HoTen.ToString();
            txt_user.Text = UserSession.Username.ToString();
            txt_phone.Text = UserSession.Phone ?? "";
            txt_date.Text = UserSession.Birthday == DateTime.MinValue
                ? ""
                : UserSession.Birthday.ToString("MM/dd/yyyy");
        }

        private void Account_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }
    }
}
