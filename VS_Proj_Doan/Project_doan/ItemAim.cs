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
    public partial class ItemAim : UserControl
    {
        public event EventHandler OnCompleteCliked;
        public event EventHandler OnDeleteCliked;
        public event EventHandler<Aim> OnEditClicked;

        public Aim CurrentAim {  get; private set; }
        public ItemAim()
        {
            InitializeComponent();
        }
        public void SetData(Aim aim)
        {

            DateTime today = DateTime.Now;
            DateTime startDay = aim.date_start.Date;

            if (aim.status != AimStatus.HoanThanh)
            {
                if (today < startDay)
                {
                    aim.status = AimStatus.ChuaThucHien;
                }
                else
                {
                    aim.status = AimStatus.DangThucHien;
                }
            }
            this.CurrentAim = aim;

            lb_aim.Text = aim.title;
            rtb_mota.Text = aim.mota;
            lb_start.Text = aim.date_start.ToString("dd/MM/yyyy");
            lb_end.Text = aim.date_end.ToString("dd/MM/yyyy");

            if(aim.status == AimStatus.HoanThanh)
            {
                btn_complete.Visible = false;
            }
            else if(aim.status == AimStatus.ChuaThucHien)
            {
                btn_complete.Enabled = false;
            }

            switch (aim.status)
            {
                case AimStatus.HoanThanh:
                    lb_status.Text = "Đã hoàn thành";
                    break;
                case AimStatus.DangThucHien:
                    lb_status.Text = "Đang thực hiện";
                    break;
                case AimStatus.ChuaThucHien:
                    lb_status.Text = "Chưa thực hiện ";
                    break;
            }
    }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            OnDeleteCliked?.Invoke(this, EventArgs.Empty);
            btn_xoa.Enabled = false;
        }

        private void btn_complete_Click(object sender, EventArgs e)
        {
            OnCompleteCliked?.Invoke(this, EventArgs.Empty);
            btn_complete.Enabled = false;
        }

        private void ItemAim_Click(object sender, EventArgs e)
        {
            OnEditClicked?.Invoke(this, this.CurrentAim);
        }
    }
}
