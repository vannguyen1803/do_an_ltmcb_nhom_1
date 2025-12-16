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
using Firebase.Auth;

namespace Project_doan
{
    public partial class NhatKy : Form
    {
        private FirestoreDb db;
        private FirebaseAuthService firebase = new FirebaseAuthService();
        private string _currentDocumentId = null;
        private string _currentUserId = null;
        public NhatKy(string userId, string projectId) : this()
        {
            _currentUserId = userId;

            try
            {
                string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                                      .Parent.Parent.FullName;
                string path = Path.Combine(projectPath, "serviceAccountKey.json");
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                db = FirestoreDb.Create(projectId);
                if (db == null)
                {
                    MessageBox.Show("Khởi tạo FirestoreDb thất bại sau khi xác thực.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi tạo Firestore: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public NhatKy()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

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
            if (db == null || string.IsNullOrEmpty(_currentUserId))
            {
                MessageBox.Show("Firestore chưa sẵn sàng. Vui lòng đăng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ContentRtf = rtb_content.Rtf
                };
                CollectionReference colRef = db.Collection("users")
                                                .Document(_currentUserId)
                                                .Collection("diaries");

                if (string.IsNullOrEmpty(_currentDocumentId))
                {
                    DocumentReference docRef = await colRef.AddAsync(entry);
                    _currentDocumentId = docRef.Id;
                    MessageBox.Show("Tạo nhật ký mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    await colRef.Document(_currentDocumentId).SetAsync(entry);
                    MessageBox.Show("Cập nhật nhật ký thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu trữ Firestore: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (db == null || string.IsNullOrEmpty(_currentUserId)) return;

            NhatKyList listForm = new NhatKyList(db, _currentUserId);
            listForm.EntrySelected += (documentId) => LoadEntryFromFirestore(documentId);
            listForm.ShowDialog();
        }

        private void tb_title_TextChanged(object sender, EventArgs e)
        {
        }

        private void rtb_content_TextChanged(object sender, EventArgs e)
        {
        }

        private async void LoadEntryFromFirestore(string documentId)
        {
            if (db == null || string.IsNullOrEmpty(_currentUserId)) return;

            try
            {
                DocumentReference docRef = db.Collection("users")
                                                .Document(_currentUserId)
                                                .Collection("diaries")
                                                .Document(documentId);

                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    Diary entry = snapshot.ConvertTo<Diary>();
                    _currentDocumentId = documentId;
                    tb_title.Text = entry.Title;
                    rtb_content.Rtf = entry.ContentRtf;
                    dtpDate.Value = DateTime.Parse(entry.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải bài viết từ Firestore: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
