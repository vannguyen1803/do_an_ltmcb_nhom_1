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
    public partial class Edit_user : Form
    {
        FirestoreUserService firebase = new FirestoreUserService();
        public Edit_user()
        {
            InitializeComponent();
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Edit_user_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[]
             {
                "Vietnamese", "English",
             });
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Close();
        }
    }
}
