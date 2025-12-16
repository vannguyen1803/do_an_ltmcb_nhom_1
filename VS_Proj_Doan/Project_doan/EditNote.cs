using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class EditNote : Form
    {
        private string noteId;
        private bool isNewNote;
        FirebaseAuthService firebase = new FirebaseAuthService();

        public EditNote()
        {
            InitializeComponent();
            isNewNote = true;
            this.Text = "Add New Note";

            if (button3 != null)
                button3.Visible = false;
        }

        public EditNote(string id, string content)
        {
            InitializeComponent();
            noteId = id;
            isNewNote = false;
            this.Text = "Edit Note";

            richTextBox1.Text = content;
            if (button3 != null)
                button3.Visible = true;
        }

        private void EditNote_Load(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
        }

        private async void button2_Click(object sender, EventArgs e)
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
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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

        private void button1_Click(object sender, EventArgs e)
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

            this.DialogResult = DialogResult.Cancel;
            this.Close();
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
                        this.DialogResult = DialogResult.OK;
                        this.Close();
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