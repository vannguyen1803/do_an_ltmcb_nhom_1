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
        private FirestoreDb db;
        private string userId;
        public event Action<string> EntrySelected;
        public NhatKyList(FirestoreDb firestoreDb, string currentUserId)
        {
            InitializeComponent();
            db = firestoreDb;
            userId = currentUserId;
            this.Load += DiaryListForm_Load;
            dataGridView1.CellDoubleClick += dataGridView1_CellContentClick;
        }
        private async void DiaryListForm_Load(object sender, EventArgs e)
        {
            await LoadEntriesAsync();
        }

        private async Task LoadEntriesAsync()
        {
            if (db == null || string.IsNullOrEmpty(userId)) return;

            try
            {
                QuerySnapshot snapshot = await db.Collection("users")
                                                 .Document(userId)
                                                 .Collection("diaries")
                                                 .GetSnapshotAsync();
                var displayList = new List<dynamic>();

                foreach (DocumentSnapshot document in snapshot.Documents)
                {
                    if (document.Exists)
                    {
                        Diary entry = document.ConvertTo<Diary>();

                        displayList.Add(new
                        {
                            ID = document.Id,
                            Ngày = entry.Date,
                            Tiêu_đề = entry.Title
                        });
                    }
                }

                dataGridView1.DataSource = displayList;
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
            if (e.RowIndex >= 0)
            {
                string selectedKey = dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString();
                EntrySelected?.Invoke(selectedKey);
                this.Close();
            }
        }
    }
}
