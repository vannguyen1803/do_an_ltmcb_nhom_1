using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class EditEvent : Form
    {
        private readonly FirebaseAuthService firebase = new FirebaseAuthService();

        private DateTime _date;
        private bool _isEditMode = false;

        public Event CurrentEvent { get; private set; }

        // 👉 ADD MODE
        public EditEvent(DateTime date)
        {
            InitializeComponent();
            _date = date;
        }

        // 👉 EDIT MODE
        public EditEvent(Event ev)
        {
            InitializeComponent();
            _isEditMode = true;
            CurrentEvent = ev;
            _date = ev.Start.Date;
        }

        private void EditEvent_Load(object sender, EventArgs e)
        {
            frequency.SelectedIndex = 0;
            if (_isEditMode && CurrentEvent != null)
            {
                // load dữ liệu cũ
                tb_title.Text = CurrentEvent.Title;
                tb_desc.Text = CurrentEvent.Description;
                day_start.Value = CurrentEvent.Start;
                day_end.Value = CurrentEvent.End;
                frequency.Text = CurrentEvent.Frequency;
            }
            else
            {
                // default khi thêm mới
                day_start.Value = _date.AddHours(8);
                day_end.Value = _date.AddHours(9);
                frequency.SelectedIndex = 0;
            }
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tb_title.Text))
                {
                    MessageBox.Show("Vui lòng nhập tiêu đề");
                    return;
                }

                if (day_end.Value <= day_start.Value)
                {
                    MessageBox.Show("Thời gian kết thúc không hợp lệ");
                    return;
                }

                btn_save.Enabled = false;

                if (_isEditMode)
                {
                    // 👉 UPDATE
                    CurrentEvent.Title = tb_title.Text.Trim();
                    CurrentEvent.Description = tb_desc.Text.Trim();
                    CurrentEvent.Start = day_start.Value;
                    CurrentEvent.End = day_end.Value;
                    CurrentEvent.Frequency = frequency.Text;

                    await firebase.UpdateEventAsync(_date, CurrentEvent);
                }
                else
                {
                    // 👉 ADD
                    CurrentEvent = new Event
                    {
                        UId = Guid.NewGuid().ToString(),
                        Title = tb_title.Text.Trim(),
                        Description = tb_desc.Text.Trim(),
                        Start = day_start.Value,
                        End = day_end.Value,
                        Frequency = frequency.Text,
                        TimezoneId = TimeZoneInfo.Local.Id
                    };

                    await firebase.SaveScheduleAsync(_date, CurrentEvent);
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                btn_save.Enabled = true;
            }
        }

        
    }

}
