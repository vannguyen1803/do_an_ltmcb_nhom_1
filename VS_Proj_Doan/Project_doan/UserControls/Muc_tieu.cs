using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_doan.UserControls;

namespace Project_doan
{
    public partial class Muc_tieu : UserControl
    {
        private FirebaseAuthService firebase;

        //biến lưu object chỉnh sửa
        private Aim currentEditAim = null;
        public Muc_tieu()
        {
            InitializeComponent();
            firebase = new FirebaseAuthService();
            pn_listAim.Visible = true;
            pn_newAim.Visible = false;
        }

        private void Muc_tieu_Load(object sender, EventArgs e)
        {
            LoadAimData();
        }

        public async void LoadAimData()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();

                List<Aim> aimlist = await firebase.GetAllAimsAsync();

                if (aimlist == null || aimlist.Count == 0) return;                    

                aimlist = aimlist.OrderBy(x => x.status).ThenBy(x => x.date_end).ToList();

                foreach (Aim aim in aimlist)
                {
                    ItemAim item = new ItemAim();

                    item.SetData(aim);

                    item.Width = flowLayoutPanel1.ClientSize.Width - 25;

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

                    item.OnEditClicked += (s, aimChinhSua) =>
                    {
                        currentEditAim = aimChinhSua;

                        tb_title.Text = aimChinhSua.title;
                        rtb_mota.Text = aimChinhSua.mota;
                        dtp_start.Value = aimChinhSua.date_start;
                        dtp_end.Value = aimChinhSua.date_end;

                        pn_listAim.Visible = false;
                        pn_newAim.Visible = true;
                        btn_add.Visible = false;
                    };
                    flowLayoutPanel1.Controls.Add(item);

                }
            }
            catch (Exception ex) {
                MessageBox.Show("Lỗi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            currentEditAim = null;
            ClearInfo();

            pn_listAim.Visible = false;
            btn_add.Visible = false;
            pn_newAim.Visible = true;

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            currentEditAim = null;
            ClearInfo();

            pn_listAim.Visible = true;
            btn_add.Visible = true;
            pn_newAim.Visible = false;
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb_title.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề mục tiêu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tb_title.Focus();
                return;
            }
            if (dtp_end.Value.Date < dtp_start.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc không được nhỏ hơn ngày bắt đầu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            btn_save.Enabled = false;

            try
            {
                string result = "";
                
                if(currentEditAim == null)
                {
                    Aim newAim = new Aim
                    {
                        title = tb_title.Text.Trim(),
                        mota = rtb_mota.Text.Trim(),
                        date_start = dtp_start.Value,
                        date_end = dtp_end.Value,
                        status = AimStatus.DangThucHien
                    };
                    result = await firebase.AddAimAsync(newAim);
                }
                else
                {
                    currentEditAim.title = tb_title.Text.Trim();
                    currentEditAim.mota = rtb_mota.Text.Trim();
                    currentEditAim.date_start = dtp_start.Value;
                    currentEditAim.date_end = dtp_end.Value;

                    result = await firebase.UpdateAimAsync(currentEditAim);
                }

                if (result == "SUCCESS")
                {
                    ClearInfo();
                    currentEditAim = null;
                    LoadAimData();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại: " + result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_save.Enabled = true;
            }
        }

        private void ClearInfo()
        {
            tb_title.Text = "";
            rtb_mota.Text = "";
            dtp_start.Value = DateTime.Now;
            dtp_end.Value = DateTime.Now;
        }

    }
}
        