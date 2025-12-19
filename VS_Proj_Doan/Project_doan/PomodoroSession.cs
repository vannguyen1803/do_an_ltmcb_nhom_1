using System;

namespace Project_doan
{
    internal class PomodoroSession
    {
        public string SessionId { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public int PhutHoc { get; set; }          // 25 hoặc 50
        public int PhutNghi { get; set; }         // 5 hoặc 10
        public int TongPhutHocThucTe { get; set; } // Thời gian thực tế học được
        public string TrangThai { get; set; }     // "Đang học", "Nghỉ", "Hoàn thành", "Hủy"

        public PomodoroSession()
        {
            SessionId = Guid.NewGuid().ToString();
            NgayBatDau = DateTime.Now;
            TrangThai = "Đang học";
        }
    }
}
