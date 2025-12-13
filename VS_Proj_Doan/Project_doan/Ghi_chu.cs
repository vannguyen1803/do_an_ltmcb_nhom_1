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
    public partial class Ghi_chu : UserControl
    {
        FirebaseAuthService firebase = new FirebaseAuthService();
        public Ghi_chu()
        {
            InitializeComponent();
        }

        private async void Ghi_chu_Load(object sender, EventArgs e)
        {
            await LoadAllNotes();
                    
        }
        private async Task LoadAllNotes()
        {
            try
            {
                var notes = await firebase.GetAllNotesAsync();
                flowLayoutPanel1.Controls.Clear();

                foreach (var note in notes)
                {
                    string noteId = note["Id"].ToString();
                    string content = note["Content"].ToString();

                    Panel card = CreateNotePanel(content, noteId, false);
                    flowLayoutPanel1.Controls.Add(card);
                }

                Panel addPanel = CreateAddNewPanel();
                flowLayoutPanel1.Controls.Add(addPanel);
            }
            catch (Exception ex) {
                MessageBox.Show("Lỗi load note: " + ex.Message);
            }

            
        }
        private Panel CreateNotePanel(string content, string noteId, bool isNew)
        {
            Panel card = new Panel
            {
                Width = 200,
                Height = 140,
                BackColor = Color.LightSkyBlue,
                Padding = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = noteId // Lưu ID vào Tag
            };

            Label lbl = new Label
            {
                AutoSize = false,
                Width = 180,
                Height = 120,
                Text = content,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black,
                Cursor = Cursors.Hand
            };

            card.Controls.Add(lbl);

            card.Click += NotePanel_Click;
            lbl.Click += NotePanel_Click;
            card.MouseEnter += (s, e) => card.BackColor = Color.SkyBlue;
            card.MouseLeave += (s, e) => card.BackColor = Color.LightSkyBlue;

            return card;
        }

        private Panel CreateAddNewPanel()
        {
            Panel addPanel = new Panel
            {
                Width = 200,
                Height = 140,
                BackColor = Color.LightGray,
                Padding = new Padding(10),
                Cursor = Cursors.Hand,
                Tag = "ADD_NEW"
            };

            Label lblPlus = new Label
            {
                Text = "+",
                Font = new Font("Segoe UI", 48, FontStyle.Bold),
                ForeColor = Color.Gray,
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            addPanel.Controls.Add(lblPlus);
            

            lblPlus.Location = new Point(
                (addPanel.Width - lblPlus.Width) / 2,
                (addPanel.Height - lblPlus.Height) / 2
            );

            Label lblText = new Label
            {
                Text = "Add Note",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = true,
                Cursor = Cursors.Hand
            };
            addPanel.Controls.Add(lblText);

            lblText.Location = new Point(
                (addPanel.Width - lblText.Width) / 2,
                addPanel.Height - 20
            );

            

            addPanel.Click += AddNewPanel_Click;
            lblPlus.Click += AddNewPanel_Click;
            lblText.Click += AddNewPanel_Click;

            addPanel.MouseEnter += (s, e) => addPanel.BackColor = Color.Silver;
            addPanel.MouseLeave += (s, e) => addPanel.BackColor = Color.LightGray;

            return addPanel;
        }
        private void NotePanel_Click(object sender, EventArgs e)
        {
            Control ctrl = sender as Control;
            Panel panel = ctrl as Panel ?? ctrl.Parent as Panel;

            if (panel == null || panel.Tag == null)
                return;

            string noteId = panel.Tag.ToString();

            Label lbl = panel.Controls.OfType<Label>().FirstOrDefault();
            string currentContent = lbl?.Text ?? "";

            EditNote editForm = new EditNote(noteId, currentContent);

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadAllNotes();
            }
        }

        private async void AddNewPanel_Click(object sender, EventArgs e)
        {
            EditNote editForm = new EditNote();

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                await LoadAllNotes();
            }
        }

        
    }
}
