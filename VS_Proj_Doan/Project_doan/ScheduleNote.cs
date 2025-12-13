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
                tb_note.Text = content;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_save.Enabled = false;
                btn_save.Text = "Đang lưu...";

                string content = tb_note.Text.Trim();
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
                btn_save.Enabled = true;
                btn_save.Text = "Lưu";
            }
        }

        
    }
}
