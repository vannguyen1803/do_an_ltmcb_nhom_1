using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class EditNote1 : UserControl 
    {
        private string noteId;
        private bool isNewNote;
        FirebaseAuthService firebase = new FirebaseAuthService();
        public event EventHandler NoteChanged;

        public EditNote1()
        {
            InitializeComponent();
            isNewNote = true;
            if (button3 != null)
                button3.Visible = false;
        }

        public EditNote1(string id, string content)
        {
            InitializeComponent();
            noteId = id;
            isNewNote = false;

            richTextBox1.Text = content;
            if (button3 != null)
                button3.Visible = true;
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }

        private async void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                string content = richTextBox1.Text.Trim();

                if (string.IsNullOrEmpty(content))
                {
                    MessageBox.Show("Vui lòng nhập nội dung note!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string result;

                if (isNewNote)
                {
                    result = await firebase.SaveNoteAsync(content);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Đã tạo note mới thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NoteChanged?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    result = await firebase.UpdateNoteAsync(noteId, content);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Đã cập nhật note thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NoteChanged?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text.Trim()))
            {
                var result = MessageBox.Show(
                    "Bạn có thay đổi chưa lưu. Bạn có chắc muốn đóng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                    return;
            }

            NoteChanged?.Invoke(this, EventArgs.Empty);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (isNewNote)
                return;

            var confirmResult = MessageBox.Show(
                "Bạn có chắc chắn muốn xóa note này?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    string result = await firebase.DeleteNoteAsync(noteId);

                    if (result == "SUCCESS")
                    {
                        MessageBox.Show("Đã xóa note thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        NoteChanged?.Invoke(this, EventArgs.Empty);
                    }
                    else
                    {
                        MessageBox.Show(result, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa note: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
    }
}