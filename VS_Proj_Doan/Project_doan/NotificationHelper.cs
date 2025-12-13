using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_doan
{
    public static class NotificationHelper
    {
        private static NotifyIcon notify;
        public static void Show(string title, string message)
        {
            try
            {
              
                if (notify == null)
                {
                    notify = new NotifyIcon();
                    notify.Icon = SystemIcons.Application; 
                    notify.Visible = true;
                }

                if (!notify.Visible)
                {
                    notify.Visible = true;
                }

                notify.BalloonTipTitle = title;
                notify.BalloonTipText = message;
                notify.ShowBalloonTip(3000);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{title}\n{message}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        
    }
}
