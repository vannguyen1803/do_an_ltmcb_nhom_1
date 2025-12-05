using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Edit_user e_u = new Edit_user();
            e_u.FormClosed += (s, args) => LoadUserInfo();
            e_u.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NoteForm note = new NoteForm();
            note.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Schedule_1 f = new Schedule_1();
            f.Show();
            this.Hide();
        }
    }
}
