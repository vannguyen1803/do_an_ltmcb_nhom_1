using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project_doan.Program;

namespace Project_doan
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main() // ✅ dùng async Task
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Init();
            //await FirebaseInit.SeedDataAsync(); // ✅ chạy seed async

            Application.Run(new Login());
        }

        //public static class FirebaseInit
        //{
        private static FirestoreDb db;

        // 🔹 Khởi tạo kết nối Firestore
        public static void Init()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"serviceAccountKey.json";
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

            //db = FirestoreDb.Create("do-an-ltmcb-nhom1"); // 🔸 thay bằng project id của bạn
        }
        
        //public static async Task SeedDataAsync()
        //{
        //    Console.WriteLine("⚙️  Bắt đầu tạo dữ liệu mẫu...");

        //    // --- 1. NguoiDung ---
        //    var user = new
        //    {
        //        MaND = "ND001",
        //        Username = "van",
        //        Pass = "123van",
        //        HoTen = "Nguyễn Vân",
        //        Email = "24521980@gm.uit.edu.vn",
        //        NgayTao = DateTime.UtcNow,              // ✅ UTC
        //        TrangThai = true
        //    };
        //    await db.Collection("NguoiDung").AddAsync(user);
        //    // --- 2. ThoiGianBieu ---
        //    var tgb = new
        //    {
        //        MaTGB = "TGB001",
        //        MaND = "ND001",
        //        TenTGB = "Lịch học kỳ 1",
        //        KieuLich = "Tuần",
        //        NgayBD = new DateTime(2025, 9, 1, 0, 0, 0, DateTimeKind.Utc),   // ✅ UTC
        //        NgayKT = new DateTime(2025, 12, 31, 0, 0, 0, DateTimeKind.Utc)  // ✅ UTC
        //    };
        //    await db.Collection("ThoiGianBieu").AddAsync(tgb);

        //    // --- 4. MucTieu ---
        //    var mucTieu = new
        //    {
        //        MaMT = "MT001",
        //        MaND = "ND001",
        //        TenMT = "Đạt GPA 3.5",
        //        Loai = "Học tập",
        //        MoTa = "Cải thiện kết quả học kỳ 1",
        //        NgayBD = DateTime.UtcNow,                       // ✅
        //        NgayKT = DateTime.UtcNow.AddMonths(3),          // ✅
        //        TrangThai = "Đang thực hiện"
        //    };
        //    await db.Collection("MucTieu").AddAsync(mucTieu);
        //    // --- 5. NhacNho ---
        //    var nn = new
        //    {
        //        MaNN = "NN001",
        //        MaND = "ND001",
        //        NoiDung = "Ôn tập Toán 8h sáng mai",
        //        ThoiGianNN = DateTime.UtcNow.AddHours(20),      // ✅
        //        TrangThai = false
        //    };
        //    await db.Collection("NhacNho").AddAsync(nn);
        //    // --- 6. NhatKyHoc ---
        //    var nk = new
        //    {
        //        MaNK = "NK001",
        //        MaND = "ND001",
        //        NgayGhi = DateTime.UtcNow,                      // ✅
        //        NoiDung = "Hôm nay học tốt, hiểu bài nhanh hơn",
        //        DanhGia = "Tốt",
        //        TienBo = "Tăng khả năng ghi nhớ"
        //    };
        //    await db.Collection("NhatKyHoc").AddAsync(nk);
        //    // --- 7. Pomodoro ---
        //    var pomodoro = new
        //    {
        //        MaPomodoro = "P001",
        //        MaND = "ND001",
        //        NgayThucHien = DateTime.UtcNow.Date,            // ✅
        //        SoPhien = 3,
        //        TongThoiGian = 75
        //    };
        //    await db.Collection("Pomodoro").AddAsync(pomodoro);
        //    // --- 8. GioHoc ---
        //    var gioHoc = new
        //    {
        //        MaGH = "GH001",
        //        MaND = "ND001",
        //        Ngay = DateTime.UtcNow.Date,                    // ✅
        //        TongGioHoc = 2
        //    };
        //    await db.Collection("GioHoc").AddAsync(gioHoc);
        //    // --- 9. LichSu_DangNhap ---
        //    var lichSu = new
        //    {
        //        MaLS = "LS001",
        //        MaND = "ND001",
        //        ThoiGianDangNhap = DateTime.UtcNow,             // ✅
        //        ThoiGianDangXuat = (DateTime?)null,
        //        DiaChiIP = "192.168.1.10",
        //        ThietBi = "Laptop"
        //    };
        //    await db.Collection("LichSu_DangNhap").AddAsync(lichSu);
        //}
        //}
    }
}
