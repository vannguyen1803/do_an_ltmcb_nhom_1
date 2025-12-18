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
            if (_events.Count == 0)
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
                var item = new Event_day(ev);
                item.Width = flp_events.ClientSize.Width - 25;
                item.Margin = new Padding(10);

                item.OnDelete += Item_OnDelete;

                // Thêm event cho phép chỉnh sửa
                item.Click += Item_OnClick; // Khi click vào panel Event_day

                flp_events.Controls.Add(item);
            }
        }
        private void Item_OnClick(object sender, EventArgs e)
        {
            var item = sender as Event_day;
            if (item == null) return;

            EditEvent frm = new EditEvent(item.CurrentEvent); // Dùng constructor EDIT MODE

            if (frm.ShowDialog() == DialogResult.OK)
            {
                // Sau khi chỉnh sửa, LoadEvents để làm mới list
                LoadEvents();

                // Báo cho Calendar biết đã có sự kiện được cập nhật/thay đổi
                OnAddEvent?.Invoke(frm.CurrentEvent); // Reuse OnAddEvent cho việc Update
            }
        }
        private void Item_OnDelete(Event_day item)
        {
            if (MessageBox.Show(
                "Bạn có chắc muốn xóa sự kiện này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            flp_events.Controls.Remove(item);
            _events.Remove(item.CurrentEvent);

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

                // báo cho Calendar 
                OnAddEvent?.Invoke(newEvent);
            }
        }
    }
}
