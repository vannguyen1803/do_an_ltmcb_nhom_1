using Google.Cloud.Firestore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Project_doan
{
    internal class FirebaseAuthService
    {
        private readonly FirestoreDb _db;

        public FirebaseAuthService()
        {
            _db = new FirestoreService().GetDb();
        }
        //Đăng nhập
        public async Task<string> SignInAsync(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                    return "Vui lòng nhập username và password";

                CollectionReference users = _db.Collection("NguoiDung");
                Query query = users.WhereEqualTo("Username", username);

                QuerySnapshot result = await query.GetSnapshotAsync();

                if (result.Count == 0)
                    return "Username không tồn tại";

                DocumentSnapshot doc = result.Documents[0];
                var data = doc.ToDictionary();

                if (data.ContainsKey("Pass") && data["Pass"].ToString() == password)
                {
                    return "SUCCESS";
                }

                return "Sai mật khẩu";
            }
            catch (Exception ex)
            {
                return "Lỗi đăng nhập: " + ex.Message;
            }
        }
        //Đăng ký
        public async Task<string> SignUpAsync(string username, string password, string email, string hoten)
        {
            try
            {
                if (string.IsNullOrEmpty(username) ||
                    string.IsNullOrEmpty(password) ||
                    string.IsNullOrEmpty(email) ||
                    string.IsNullOrEmpty(hoten))
                {
                    return "Vui lòng nhập đủ thông tin";
                }

                CollectionReference users = _db.Collection("NguoiDung");
                Query query = users.WhereEqualTo("Username", username);

                QuerySnapshot snap = await query.GetSnapshotAsync();
                if (snap.Count > 0)
                    return "Username đã tồn tại";
                var userData = new Dictionary<string, object>
                {
                    { "Username", username },
                    { "Pass", password },
                    { "Email", email },
                    { "HoTen", hoten },
                    { "TrangThai", true },
                    { "NgayTao", Timestamp.GetCurrentTimestamp() },
                    { "MaND", "ND" + new Random().Next(1000, 9999) }
                };

                await users.AddAsync(userData);

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi đăng ký: " + ex.Message;
            }
        }
        //Quên mật khẩu
        public async Task<string> ResetPasswordAsync(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                    return "Vui lòng nhập email";

                CollectionReference users = _db.Collection("NguoiDung");
                Query query = users.WhereEqualTo("Email", email);

                QuerySnapshot snap = await query.GetSnapshotAsync();

                if (snap.Count == 0)
                    return "Email không tồn tại trong hệ thống";

                DocumentSnapshot doc = snap.Documents[0];
                var data = doc.ToDictionary();

                string oldPass = data["Pass"].ToString();

                return $"Mật khẩu của bạn là: {oldPass}";
            }
            catch (Exception ex)
            {
                return "Lỗi reset mật khẩu: " + ex.Message;
            }
        }
    }
}
