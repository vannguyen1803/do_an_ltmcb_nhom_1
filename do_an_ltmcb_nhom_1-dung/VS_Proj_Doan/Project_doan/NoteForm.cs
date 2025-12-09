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
    public partial class NoteForm : Form
    {
        FirestoreUserService firebase = new FirestoreUserService();
        public NoteForm()
        {
            InitializeComponent();
        }

        private async void NoteForm_Load(object sender, EventArgs e)
        {
            var notes = await firebase.GetAllNotesAsync();

            flowLayoutPanel1.Controls.Clear();

            foreach (var note in notes)
            {
                string content = note["Content"].ToString();

                Panel card = new Panel
                {
                    Width = 200,
                    Height = 140,
                    BackColor = Color.LightSkyBlue,
                    Padding = new Padding(10)
                };

                Label lbl = new Label
                {
                    AutoSize = false,
                    Width = 180,
                    Height = 120,
                    Text = content
                };

                card.Controls.Add(lbl);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            note.Show();
            this.Hide();
        }
    }
}
