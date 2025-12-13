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
    public partial class EditUser : Form
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public EditUser()
        {
            InitializeComponent();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[]
             {
                "Vietnamese", "English",
             });
            comboBox1.SelectedIndex = 0;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string phone = textBox1.Text.Trim();
                DateTime birthday = monthCalendar1.SelectionStart;
                string language = comboBox1.Text;
                string result = await firebase.UserdetailAsync(phone, birthday, language);
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
