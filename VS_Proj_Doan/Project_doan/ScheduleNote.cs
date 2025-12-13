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
    public partial class ScheduleNote : Form
    {
        public ScheduleNote()
        {
            InitializeComponent();
        }
        FirebaseAuthService firebase = new FirebaseAuthService();
        DateTime selectedDate;
        public ScheduleNote(DateTime date)
        {
            InitializeComponent();
            selectedDate = date;
        }

        private async void ScheduleNotes_1_Load(object sender, EventArgs e)
        {
            try
            {
                string content = await firebase.GetScheduleAsync(selectedDate);
                richTextBox1.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                button1.Enabled = false;
                button1.Text = "Đang lưu...";

                string content = richTextBox1.Text.Trim();
                string result = await firebase.SaveScheduleAsync(selectedDate, content);

                if (result == "SUCCESS")
                {
                    MessageBox.Show("Lưu lịch trình thành công!", "Thông báo",
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
                MessageBox.Show("Lỗi lưu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                button1.Enabled = true;
                button1.Text = "Lưu";
            }
        }
    }
}
