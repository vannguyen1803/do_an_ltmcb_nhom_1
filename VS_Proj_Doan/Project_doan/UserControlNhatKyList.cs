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
    public partial class UserControlNhatKyList : UserControl
    {
        private readonly FirebaseAuthService _firebase;
        public event Action<string> EntrySelected;
        public UserControlNhatKyList(FirebaseAuthService firebaseService)
        {
            InitializeComponent();
            _firebase = firebaseService;
            if (_firebase != null)
            {
                this.Load += UserControlNhatKyList_Load;
            }
        }
        public UserControlNhatKyList()
        {
            InitializeComponent();
        }
        private async void UserControlNhatKyList_Load(object sender, EventArgs e)
        {
            await LoadEntriesAsync();
        }
        private async Task LoadEntriesAsync()
        {
            if (_firebase == null)
            {
                MessageBox.Show("Dịch vụ Firebase chưa được khởi tạo đúng cách. Vui lòng kiểm tra lại Form Home.", "Lỗi Service", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(UserSession.Username)) return;

            try
            {
                var diaryData = await _firebase.GetAllDiaryEntriesAsync();
                flowLayoutPanel1.Controls.Clear(); 
                if (diaryData.Count == 0)
                {
                    flowLayoutPanel1.Controls.Add(new Label() { Text = "Không có nhật ký nào được lưu.", AutoSize = true });
                    return;
                }

                foreach (var entry in diaryData)
                {
                    string docId = entry["DocumentId"].ToString();
                    string date = entry.ContainsKey("Date") ? entry["Date"].ToString() : "N/A";
                    string title = entry.ContainsKey("Title") ? entry["Title"].ToString() : "(Không tiêu đề)";
                    string content = entry.ContainsKey("ContentRtf") ? entry["ContentRtf"].ToString() : "Không có nội dung.";
                    var item = new DiaryItem(docId, date, title, content);

                    item.Click += (sender, ev) =>
                    {
                        EntrySelected?.Invoke(item.DocumentId);
                    };
                    flowLayoutPanel1.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
