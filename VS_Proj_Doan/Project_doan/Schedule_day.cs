using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class Schedule_day : Form
    {
        private DateTime _date;
        private List<Event> _events;

        public event Action<Event> OnDeleteEvent;
        public event Action<Event> OnAddEvent;
        public bool is_changed = false;

        public Schedule_day(DateTime date, List<Event> events)
        {
            InitializeComponent();

            _date = date;
            _events = events ?? new List<Event>();

            lb_date.Text = date.ToString("dd/MM/yyyy");

            LoadEvents();
        }

        private void LoadEvents()
        {
            flp_events.Controls.Clear();

            if (_events == null || _events.Count == 0)
            {
                flp_events.Controls.Add(new Label
                {
                    Text = "Không có sự kiện trong ngày",
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    Margin = new Padding(20)
                });
                return;
            }

            foreach (var ev in _events)
            {
                Event_day item = new Event_day(ev);
                item.Width = flp_events.ClientSize.Width - 25;
                item.Margin = new Padding(10);
                item.OnDelete -= Item_OnDelete;
                item.OnDelete += Item_OnDelete;

                item.Click -= Item_OnClick;
                item.Click += Item_OnClick;

                flp_events.Controls.Add(item);
            }
        }

        private void Item_OnClick(object sender, EventArgs e)
        {
            Event_day item = sender as Event_day;
            if (item == null) return;

            EditEvent frm = new EditEvent(item.CurrentEvent);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                is_changed = true;

                int idx = _events.FindIndex(x => x.UId == frm.CurrentEvent.UId);
                if (idx >= 0)
                {
                    _events[idx] = frm.CurrentEvent;
                }

                LoadEvents();
                OnAddEvent?.Invoke(frm.CurrentEvent);
            }
        }

        private void Item_OnDelete(Event_day item)
        {
            if (item == null || item.CurrentEvent == null)
                return;

            if (MessageBox.Show(
                "Bạn có chắc muốn xóa sự kiện này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            flp_events.Controls.Remove(item);

            _events.RemoveAll(e => e.UId == item.CurrentEvent.UId);

            is_changed = true;

            OnDeleteEvent?.Invoke(item.CurrentEvent);

            if (_events.Count == 0)
                LoadEvents();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            EditEvent frm = new EditEvent(_date);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                Event newEvent = frm.CurrentEvent;

                _events.Add(newEvent);

                LoadEvents();
                is_changed = true;

                OnAddEvent?.Invoke(newEvent);
            }
        }

        private void Schedule_day_Load(object sender, EventArgs e)
        {
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (is_changed)
            {
                this.DialogResult = DialogResult.OK;
            }
            base.OnFormClosing(e);
        }
    }
}
