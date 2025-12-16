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
    public class FirebaseAuthService
    {
        private readonly FirestoreDb _db;

        public FirebaseAuthService()
        {
            _db = new FirestoreService().GetDb();
        }
        //Login

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
                    UserSession.Email = data["Email"].ToString();
                    UserSession.Username = data["Username"].ToString();
                    UserSession.HoTen = data["HoTen"].ToString();
                    UserSession.Phone = data.ContainsKey("Phone") ? data["Phone"].ToString() : "";
                    UserSession.Language = data.ContainsKey("Language") ? data["Language"].ToString() : "";
                    if (data.ContainsKey("Birthday"))
                    {
                        Timestamp t = (Timestamp)data["Birthday"];
                        UserSession.Birthday = t.ToDateTime();
                    }
                    else
                    {
                        UserSession.Birthday = DateTime.MinValue;
                    }

                    UserSession.ScheduleCache = await GetAllSchedulesAsync();

                    return "SUCCESS";
                }

                return "Sai mật khẩu";
            }
            catch (Exception ex)
            {
                return "Lỗi đăng nhập: " + ex.Message;
            }
        }
        //signup
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
        //foget password
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


        // user_detail
        public async Task<string> UserdetailAsync(string phone, DateTime birthday, string language)
        {
            try
            {
                string username = UserSession.Username;
                if (string.IsNullOrEmpty(username))
                    return "Không tìm thấy thông tin session user";

                CollectionReference users = _db.Collection("NguoiDung");
                Query query = users.WhereEqualTo("Username", username);

                QuerySnapshot snap = await query.GetSnapshotAsync();
                if (snap.Count == 0)
                    return "Không tìm thấy user trong Firestore";
                DocumentReference userDoc = snap.Documents[0].Reference;
                if (string.IsNullOrEmpty(phone))
                {
                    phone = "";
                    await userDoc.UpdateAsync(new Dictionary<string, object>
                    {
                        { "Birthday", Timestamp.FromDateTime(birthday.ToUniversalTime()) },
                        { "Language", language }
                    });
                    UserSession.Birthday = birthday;
                    UserSession.Language = language;
                }
                else
                {
                    await userDoc.UpdateAsync(new Dictionary<string, object>
        {
            { "Phone", phone },
            { "Birthday", Timestamp.FromDateTime(birthday.ToUniversalTime()) },
            { "Language", language }
        });

                    UserSession.Phone = phone;
                    UserSession.Birthday = birthday;
                    UserSession.Language = language;
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi cập nhật: " + ex.Message;
            }
        }

        //getcurrentuser
        private async Task<DocumentReference> GetCurrentUserDocAsync()
        {
            CollectionReference users = _db.Collection("NguoiDung");
            Query query = users.WhereEqualTo("Username", UserSession.Username);

            QuerySnapshot snap = await query.GetSnapshotAsync();

            if (snap.Count == 0)
                return null;

            return snap.Documents[0].Reference;
        }

        // Save note 
        public async Task<string> SaveNoteAsync(string content)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                string noteId = Guid.NewGuid().ToString();

                var noteData = new Dictionary<string, object>
        {
            { "Id", noteId },
            { "Content", content }

        };

                await userDoc
                    .Collection("Notes")
                    .Document(noteId)
                    .SetAsync(noteData);

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi lưu note: " + ex.Message;
            }
        }


        // LoadNote
        public async Task<List<Dictionary<string, object>>> GetAllNotesAsync()
        {
            var list = new List<Dictionary<string, object>>();

            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return list;

                QuerySnapshot snap = await userDoc
                    .Collection("Notes")

                    .GetSnapshotAsync();

                foreach (var doc in snap.Documents)
                {
                    list.Add(doc.ToDictionary());
                }

                return list;
            }
            catch
            {
                return list;
            }
        }


        //saveSchedule
        public async Task<string> SaveScheduleAsync(DateTime date, string content)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                string dateKey = date.ToString("yyyy-MM-dd");

                var data = new Dictionary<string, object>
        {
            { "Date", dateKey },
            { "Content", content },
            { "UpdatedAt", Timestamp.GetCurrentTimestamp() }
        };

                await userDoc
                    .Collection("Schedule")
                    .Document(dateKey)
                    .SetAsync(data);
                UserSession.ScheduleCache[dateKey] = content;

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi lưu lịch: " + ex.Message;
            }
        }
        // loadSchedule
        public async Task<string> GetScheduleAsync(DateTime date)
        {
            try
            {
                string dateKey = date.ToString("yyyy-MM-dd");

                // Kiểm tra cache trước
                if (UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    return UserSession.ScheduleCache[dateKey];
                }

                return "";
            }
            catch
            {
                return "";
            }
        }
        // Load all schedule  
        public async Task<Dictionary<string, string>> GetAllSchedulesAsync()
        {
            var scheduleDict = new Dictionary<string, string>();

            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return scheduleDict;

                QuerySnapshot snap = await userDoc
                    .Collection("Schedule")
                    .GetSnapshotAsync();

                foreach (var doc in snap.Documents)
                {
                    var data = doc.ToDictionary();
                    if (data.ContainsKey("Date") && data.ContainsKey("Content"))
                    {
                        string dateKey = data["Date"].ToString();
                        string content = data["Content"].ToString();
                        scheduleDict[dateKey] = content;
                    }
                }

                return scheduleDict;
            }
            catch (Exception ex)
            {
                return scheduleDict;
            }
        }
        // Update Note
        public async Task<string> UpdateNoteAsync(string noteId, string content)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                var noteData = new Dictionary<string, object>
        {
            { "Id", noteId },
            { "Content", content }
        };

                await userDoc
                    .Collection("Notes")
                    .Document(noteId)
                    .SetAsync(noteData);

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi cập nhật note: " + ex.Message;
            }
        }

        // Delete Note
        public async Task<string> DeleteNoteAsync(string noteId)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                await userDoc
                    .Collection("Notes")
                    .Document(noteId)
                    .DeleteAsync();

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa note: " + ex.Message;
            }
        }
        private void CheckDbReady()
        {
            if (_db == null || string.IsNullOrEmpty(UserSession.Username))
            {
                throw new InvalidOperationException("Cơ sở dữ liệu hoặc thông tin người dùng chưa sẵn sàng. Vui lòng kiểm tra kết nối và đăng nhập lại.");
            }
        }
        public async Task<string> SaveDiaryEntryAsync(string documentId, Diary entry)
        {
            CheckDbReady();

            try
            {
                DocumentReference userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    throw new InvalidOperationException("Không tìm thấy Document người dùng hiện tại.");
                CollectionReference colRef = userDoc.Collection("diaries");

                if (string.IsNullOrEmpty(documentId))
                {
                    DocumentReference docRef = await colRef.AddAsync(entry);
                    return docRef.Id;
                }
                else
                {
                    await colRef.Document(documentId).SetAsync(entry);
                    return documentId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu Nhật ký: " + ex.Message);
            }
        }

        public async Task<Diary> LoadDiaryEntryAsync(string documentId)
        {
            CheckDbReady();

            try
            {
                DocumentReference userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return null;

                DocumentReference docRef = userDoc.Collection("diaries").Document(documentId);
                DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

                if (snapshot.Exists)
                {
                    return snapshot.ConvertTo<Diary>();
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải Nhật ký: " + ex.Message);
            }
        }
        public async Task<List<Dictionary<string, object>>> GetAllDiaryEntriesAsync()
        {
            CheckDbReady();
            var diaryList = new List<Dictionary<string, object>>();

            try
            {
                DocumentReference userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return diaryList;
                QuerySnapshot snap = await userDoc
                    .Collection("diaries")
                    .OrderByDescending("Date")
                    .GetSnapshotAsync();

                foreach (var doc in snap.Documents)
                {
                    var data = doc.ToDictionary();
                    data.Add("DocumentId", doc.Id);
                    diaryList.Add(data);
                }

                return diaryList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách nhật ký: " + ex.Message);
                throw new Exception("Lỗi khi tải danh sách nhật ký: " + ex.Message);
            }
        }
    }
}
