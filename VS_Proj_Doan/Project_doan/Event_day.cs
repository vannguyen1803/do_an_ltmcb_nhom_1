using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Event_day : UserControl
    {
        public Event CurrentEvent { get; private set; }

        public event Action<Event_day> OnDelete;
        public event Action<Event_day> OnEdit;

        public Event_day(Event ev)
        {
            InitializeComponent();
            LoadEvent(ev);
            AttachClickEvent(this);
        }
        private void AttachClickEvent(Control parent)
        {
            if (parent == btn_xoa)
                return;
            parent.Click += Event_day_Click;

            foreach (Control c in parent.Controls)
            {
                AttachClickEvent(c);
            }
        }
        private void LoadEvent(Event ev)
        {
            CurrentEvent = ev;

            tb_title.Text = ev.Title;
            dtp_end.Value = ev.End;
            tb_frequen.Text = ev.Frequency;
            tb_desc.Text = ev.Description;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            OnDelete?.Invoke(this);
        }
        private void Event_day_Click(object sender, EventArgs e)
        {
            OnEdit?.Invoke(this);
        }
    }
}
