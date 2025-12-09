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
    public partial class Note : Form
    {
        FirestoreUserService firebase = new FirestoreUserService();
        public Note()
        {
            InitializeComponent();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string content = richTextBox1.Text.Trim();
                if (string.IsNullOrEmpty(content))
                {
                    MessageBox.Show("Note trống");
                    return;
                }
                string result = await firebase.SaveNoteAsync(content);
                    
                if(result == "SUCCESS")
                {
                    MessageBox.Show("Đã lưu note");
                    richTextBox1.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NoteForm note = new NoteForm();
            note.Show();
            this.Close();
        }
    }
}
