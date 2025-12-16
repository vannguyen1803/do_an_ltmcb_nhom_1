using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Project_doan
{
    public partial class EditEvent : Form
    {
        private readonly FirebaseAuthService firebase = new FirebaseAuthService();

        private DateTime _date;
        private DateTime _originalDate;
        private bool _isEditMode = false;
        public Event CurrentEvent { get; private set; }

        public EditEvent(DateTime date)
        {
            InitializeComponent();
            _date = date;
            _originalDate = date;
        }

        public EditEvent(Event ev)
        {
            InitializeComponent();
            _isEditMode = true;
            CurrentEvent = ev;
            _date = ev.Start.Date;
            _originalDate = ev.Start.Date;
        }

        private void EditEvent_Load(object sender, EventArgs e)
        {
            frequency.SelectedIndex = 0;
            if (_isEditMode && CurrentEvent != null)
            {
                tb_title.Text = CurrentEvent.Title;
                tb_desc.Text = CurrentEvent.Description;
                day_start.Value = CurrentEvent.Start;
                day_end.Value = CurrentEvent.End;
                frequency.Text = CurrentEvent.Frequency;
            }
            else
            {
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

                    CurrentEvent.Title = tb_title.Text.Trim();
                    CurrentEvent.Description = tb_desc.Text.Trim();
                    CurrentEvent.Start = day_start.Value;
                    CurrentEvent.End = day_end.Value;
                    CurrentEvent.Frequency = frequency.Text;

                    await firebase.UpdateEventAsync(CurrentEvent.Start.Date, CurrentEvent);
                }
                else
                {
                    DateTime startDate = day_start.Value;
                    DateTime endDate = day_end.Value;

                    DateTime? recurrenceEnd = endDate.Date;

                    var dates = GenerateRecurringDates(
                        startDate,
                        recurrenceEnd,
                        frequency.Text
                    );

                    Event firstEvent = null;

                    foreach (var date in dates)
                    {
                        // Giữ nguyên giờ
                        DateTime newStart = new DateTime(
                            date.Year, date.Month, date.Day,
                            startDate.Hour, startDate.Minute, 0
                        );

                        DateTime newEnd = new DateTime(
                            date.Year, date.Month, date.Day,
                            endDate.Hour, endDate.Minute, 0
                        );
                        Event newEvent = new Event
                        {
                            UId = Guid.NewGuid().ToString(),
                            Title = tb_title.Text.Trim(),
                            Description = tb_desc.Text.Trim(),
                            Start = newStart,
                            End = newEnd,
                            Frequency = frequency.SelectedText, // 🔥 lưu như event thường
                            TimezoneId = TimeZoneInfo.Local.Id
                        };

                        await firebase.SaveScheduleAsync(newStart.Date, newEvent);

                        // Lưu event đầu tiên để trả về UI
                        if (firstEvent == null)
                            firstEvent = newEvent;
                    }

                    // ⚠️ BẮT BUỘC
                    CurrentEvent = firstEvent;
                }



                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu event: {ex.Message}");
            }
            finally
            {
                btn_save.Enabled = true;
            }
        }

        private List<DateTime> GenerateRecurringDates(
            DateTime start,
            DateTime? end,
            string frequency)
        {
            var dates = new List<DateTime>();

            if (end == null || frequency == "None")
            {
                dates.Add(start.Date);
                return dates;
            }

            DateTime current = start.Date;
            DateTime endDate = end.Value.Date;

            int maxIterations = 365; // Giới hạn tối đa 1 năm
            int iteration = 0;

            while (current <= endDate && iteration < maxIterations)
            {
                dates.Add(current);
                iteration++;

                switch (frequency)
                {
                    case "Tuần":
                        current = current.AddDays(7);
                        break;

                    case "2 Tuần":
                        current = current.AddDays(14);
                        break;

                    case "Tháng":
                        current = current.AddMonths(1);
                        break;

                    case "Năm":
                        current = current.AddYears(1);
                        break;

                    default:
                        return dates;
                }
            }

            return dates;
        }
    }
}