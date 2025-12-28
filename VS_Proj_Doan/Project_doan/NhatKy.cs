using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;


namespace Project_doan
{
    public partial class NhatKy : UserControl
    {
        private FirebaseAuthService firebase = new FirebaseAuthService();
        private string _currentDocumentId = null;
        public event Action BackToListRequested;
        public NhatKy(FirebaseAuthService firebaseService) : this()
        {
            this.firebase = firebaseService;
        }
        public NhatKy()
        {
            InitializeComponent();
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            _currentDocumentId = null;
            dtpDate.Value = DateTime.Now;
            tb_title.Clear();
            rtb_content.Clear();
            tb_title.Focus();
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UserSession.Username))
            {
                MessageBox.Show("Vui lòng đăng nhập lại để lưu dữ liệu.", "Lỗi Xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrWhiteSpace(tb_title.Text))
            {
                MessageBox.Show("Vui lòng nhập Tiêu đề!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tb_title.Focus();
                return;
            }

            try
            {
                var entry = new Diary
                {
                    Title = tb_title.Text,
                    Date = dtpDate.Value.ToString("yyyy-MM-dd"),
                    ContentRtf = rtb_content.Text
                };
                string newDocumentId = await firebase.SaveDiaryEntryAsync(_currentDocumentId, entry);

                if (string.IsNullOrEmpty(_currentDocumentId))
                {
                    _currentDocumentId = newDocumentId;
                    MessageBox.Show("Tạo nhật ký mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cập nhật nhật ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (InvalidOperationException ex) 
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu trữ Firestore: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            BackToListRequested?.Invoke();
        }

        public async void LoadEntryFromFirestore(string documentId)
        {
            if (string.IsNullOrEmpty(UserSession.Username)) return;

            try
            {
                Diary entry = await firebase.LoadDiaryEntryAsync(documentId);

                if (entry != null)
                {
                    _currentDocumentId = documentId;
                    tb_title.Text = entry.Title;
                    rtb_content.Text = entry.ContentRtf;
                    dtpDate.Value = DateTime.Parse(entry.Date);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bài viết từ Firestore: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void PrepareForNewEntry()
        {
            _currentDocumentId = null;
            dtpDate.Value = DateTime.Now;
            tb_title.Clear();
            rtb_content.Clear();
            tb_title.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }
    }
}
