using System;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Event_day : UserControl
    {
        public Event CurrentEvent { get; private set; }

        public event Action<Event_day> OnDelete;

        public Event_day(Event ev)
        {
            InitializeComponent();
            LoadEvent(ev);
        }

        private void LoadEvent(Event ev)
        {
            CurrentEvent = ev;

            tb_title.Text = ev.Title;
            dtp_end.Value = ev.End;
            tb_frequen.Text = ev.Frequency;
            tb_desc.Text = ev.Description;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OnDelete?.Invoke(this);
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            OnDelete?.Invoke(this);
        }
    }
}
