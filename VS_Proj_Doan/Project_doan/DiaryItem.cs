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
    public partial class DiaryItem : UserControl
    {
        public string DocumentId { get; private set; }
        public DiaryItem(string documentId, string date, string title, string content)
        {
            InitializeComponent();
            this.DocumentId = documentId;
            lb_date.Text = date;
            lb_title.Text = title;
            lb_content.Text = content;

            WireUpClickEvents(this);
            this.Click += DiaryItem_Click;
        }
        private void DiaryItem_Click(object sender, EventArgs e)
        {

        }
        private void WireUpClickEvents(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.Click += (sender, e) => OnClick(e);
                if (c.HasChildren)
                {
                    WireUpClickEvents(c);
                }
            }
        }
        private void DiaryItem_Load(object sender, EventArgs e)
        {

        }

        private void lb_title_Click(object sender, EventArgs e)
        {

        }

        private void lb_content_Click(object sender, EventArgs e)
        {

        }

        private void lb_date_Click(object sender, EventArgs e)
        {

        }
    }
}
