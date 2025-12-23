using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;

namespace Project_doan
{
    public partial class NewAim : Form
    {
        private FirebaseAuthService firebase;
        private Aim currentEditAim = null;
        public event EventHandler OnDataSave;

        public NewAim(Aim aim = null)
        {
            InitializeComponent();
            firebase = new FirebaseAuthService();
            this.currentEditAim = aim;
        }
        private void NewAim_Load(object sender, EventArgs e)
        {
            if (currentEditAim != null)
            {
                tb_title.Text = currentEditAim.title;
                rtb_mota.Text = currentEditAim.mota;
                dtp_start.Value = currentEditAim.date_start;
                dtp_end.Value = currentEditAim.date_end;

                this.Text = "Chỉnh sửa mục tiêu";
            }
            else
            {
                ClearInfo();
                this.Text = "Thêm mục tiêu";
            }
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
                AimStatus initialStatus = AimStatus.DangThucHien;
                if (DateTime.Now.Date < dtp_start.Value.Date)
                {
                    initialStatus = AimStatus.ChuaThucHien;
                }

                string result = "";

                if (currentEditAim == null)
                {
                    Aim newAim = new Aim
                    {
                        title = tb_title.Text.Trim(),
                        mota = rtb_mota.Text.Trim(),
                        date_start = dtp_start.Value,
                        date_end = dtp_end.Value,
                        status = initialStatus
                    };
                    result = await firebase.AddAimAsync(newAim);
                }
                else
                {
                    currentEditAim.title = tb_title.Text.Trim();
                    currentEditAim.mota = rtb_mota.Text.Trim();
                    currentEditAim.date_start = dtp_start.Value;
                    currentEditAim.date_end = dtp_end.Value;

                    if (currentEditAim.status != AimStatus.HoanThanh)
                    {
                        if (DateTime.Now.Date < dtp_start.Value.Date)
                            currentEditAim.status = AimStatus.ChuaThucHien;
                        else
                            currentEditAim.status = AimStatus.DangThucHien;
                    }

                    result = await firebase.UpdateAimAsync(currentEditAim);
                }

                if (result == "SUCCESS")
                {

                    OnDataSave?.Invoke(this, EventArgs.Empty);
                    this.Close();
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
