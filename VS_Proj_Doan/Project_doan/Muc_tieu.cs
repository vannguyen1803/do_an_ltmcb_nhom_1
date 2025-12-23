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
    public partial class Muc_tieu : UserControl
    {
        private FirebaseAuthService firebase;

        public Muc_tieu()
        {
            InitializeComponent();
            firebase = new FirebaseAuthService();
        }

        private void Muc_tieu_Load(object sender, EventArgs e)
        {
            LoadAimData();
        }
        private void OpenNewAim(Aim aim)
        {
            NewAim newaim = new NewAim(aim);

            newaim.OnDataSave += (s, args) =>
            {
                LoadAimData();
            };
            newaim.ShowDialog();
        }
        public async void LoadAimData()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                List<Aim> aimlist = await firebase.GetAllAimsAsync();

                if (aimlist == null || aimlist.Count == 0) return;

                aimlist = aimlist.Where(a=>a.isDeleted == false).OrderBy(x => x.status).ThenBy(x => x.date_end).ToList();

                foreach (Aim aim in aimlist)
                {
                    ItemAim item = new ItemAim();

                    item.SetData(aim);

                    item.Width = flowLayoutPanel1.ClientSize.Width;

                    item.OnDeleteCliked += async (s, args) =>
                    {
                        var dialogResult = MessageBox.Show($"Bạn có chắc muốn xóa mục tiêu: {aim.title}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string result = await firebase.DeleteAimAsync(aim.Id);
                            if (result == "SUCCESS")
                            {
                                flowLayoutPanel1.Controls.Remove(item);
                            }
                            else
                            {
                                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    item.OnCompleteCliked += async (s, args) =>
                    {
                        aim.status = AimStatus.HoanThanh;
                        
                        string result = await firebase.UpdateAimAsync(aim);
                        if (result == "SUCCESS")
                        {
                            item.SetData(aim);
                            LoadAimData();
                        }
                        else
                        {
                            MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    item.OnEditClicked += (s, aimEdit) =>
                    {
                        OpenNewAim(aimEdit);
                    };

                    flowLayoutPanel1.Controls.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            OpenNewAim(null);
        }
    }
}