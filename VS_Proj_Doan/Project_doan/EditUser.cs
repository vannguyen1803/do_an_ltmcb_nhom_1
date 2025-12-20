using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class EditUser : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public EditUser()
        {
            InitializeComponent();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = textBox1.Text.Trim();
                DateTime birthday = monthCalendar1.SelectionStart;
                string language = "Vietnamese";
                string result = await firebase.UserdetailAsync(phone, birthday, language);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
