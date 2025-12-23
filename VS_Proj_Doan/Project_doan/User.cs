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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
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
            txt_country.Text = UserSession.Language ?? "";
            txt_date.Text = UserSession.Birthday == DateTime.MinValue
                ? ""
                : UserSession.Birthday.ToString("MM/dd/yyyy");
        }
    }
}
