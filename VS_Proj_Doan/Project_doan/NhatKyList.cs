using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
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
    public partial class NhatKyList : Form
    {
        private readonly FirebaseAuthService _firebase;
        public event Action<string> EntrySelected;
        public NhatKyList(FirebaseAuthService firebaseService)
        {
            InitializeComponent();
            _firebase = firebaseService;

            this.Load += DiaryListForm_Load;
            dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
        }
        private async void DiaryListForm_Load(object sender, EventArgs e)
        {
            await LoadEntriesAsync();
        }

        private async Task LoadEntriesAsync()
        {
            if (string.IsNullOrEmpty(UserSession.Username)) return;

            try
            {
                var diaryData = await _firebase.GetAllDiaryEntriesAsync();

                if (diaryData.Count == 0)
                {
                    MessageBox.Show("Chưa có bài nhật ký nào được lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(string));
                dt.Columns.Add("Ngày", typeof(string));
                dt.Columns.Add("Tiêu đề", typeof(string));

                foreach (var entry in diaryData)
                {
                    dt.Rows.Add(
                        entry["DocumentId"].ToString(),
                        entry.ContainsKey("Date") ? entry["Date"].ToString() : "N/A",
                        entry.ContainsKey("Title") ? entry["Title"].ToString() : "(Không tiêu đề)"
                    );
                }
                dataGridView1.DataSource = dt;
                if (dataGridView1.Columns.Contains("ID"))
                {
                    dataGridView1.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string selectedKey = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                EntrySelected?.Invoke(selectedKey);
                this.Close();
            }
        }
    }
}
