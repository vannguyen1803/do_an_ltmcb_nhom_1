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
            _db = Program.db;
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
                    UserSession.MaND = data.ContainsKey("MaND") ? data["MaND"].ToString() : "";
                    if (data.ContainsKey("Birthday"))
                    {
                        Timestamp t = (Timestamp)data["Birthday"];
                        UserSession.Birthday = t.ToDateTime();
                    }
                    else
                    {
                        UserSession.Birthday = DateTime.MinValue;
                    }
                    try
                    {
                        UserSession.ScheduleCache = await GetAllSchedulesAsync();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error loading schedule cache: " + ex.Message);
                        UserSession.ScheduleCache = new Dictionary<string, List<Event>>();
                    }

                    try
                    {
                        UserSession.NoteCache = await GetAllNotesAsync();
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error loading note cache: " + ex.Message);
                        UserSession.NoteCache = new List<Dictionary<string, object>>();
                    }

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
        
        // Sửa lại SaveScheduleAsync (Thêm mới/Ghi đè nếu đã tồn tại)
        public async Task<string> SaveScheduleAsync(DateTime date, Event ev)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                string dateKey = date.ToString("yyyy-MM-dd");
                if (string.IsNullOrEmpty(ev.UId))
                    ev.UId = Guid.NewGuid().ToString();

                // 1. Lấy danh sách sự kiện hiện tại (từ cache hoặc Firebase)
                List<Event> events;
                if (UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    events = UserSession.ScheduleCache[dateKey];
                }
                else
                {
                    // Tải từ Firebase nếu chưa có trong cache
                    events = await GetEventsFromFirebase(userDoc, dateKey);
                }

                // 2. Thêm sự kiện mới vào danh sách
                events.Add(ev);

                // Cập nhật lại cache
                UserSession.ScheduleCache[dateKey] = events;

                // 3. Chuyển đổi danh sách Event sang format lưu trữ của Firebase (List of Map)
                var eventsData = events.Select(e => new Dictionary<string, object>
        {
            { "UId", e.UId },
            { "Title", e.Title },
            { "Start", e.Start },
            { "End", e.End },
            { "Frequency", e.Frequency },
            { "Description", e.Description },
            { "TimezoneId", e.TimezoneId },
            // Có thể thêm CreatedAt, UpdatedAt
        }).ToList();

                var updateData = new Dictionary<string, object>
        {
            { "Events", eventsData }
        };

                // 4. Lưu lại toàn bộ danh sách cập nhật vào document ngày
                // SetAsync sẽ tạo mới nếu chưa có, hoặc ghi đè nếu đã có
                await userDoc
                    .Collection("Schedule")
                    .Document(dateKey)
                    .SetAsync(updateData);

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi lưu lịch: " + ex.Message;
            }
        }

        // Hàm hỗ trợ đọc Events từ Firebase và chuyển đổi sang List<Event>
        private async Task<List<Event>> GetEventsFromFirebase(DocumentReference userDoc, string dateKey)
        {
            var snap = await userDoc
                .Collection("Schedule")
                .Document(dateKey)
                .GetSnapshotAsync();

            if (!snap.Exists || !snap.ToDictionary().TryGetValue("Events", out object eventsObj))
            {
                return new List<Event>();
            }

            if (eventsObj is List<object> eventsList)
            {
                return eventsList.Select(item =>
                {
                    if (item is Dictionary<string, object> data)
                    {
                        // Logic map từ Dictionary sang Event
                        DateTime start = (data["Start"] is Timestamp ts) ? ts.ToDateTime() : DateTime.Parse(data["Start"].ToString());
                        DateTime end = (data["End"] is Timestamp tsEnd) ? tsEnd.ToDateTime() : DateTime.Parse(data["End"].ToString());

                        return new Event
                        {
                            UId = data["UId"].ToString(),
                            Title = data["Title"].ToString(),
                            Description = data.ContainsKey("Description") ? data["Description"].ToString() : "",
                            Frequency = data.ContainsKey("Frequency") ? data["Frequency"].ToString() : "None",
                            Start = start,
                            End = end,
                            // Thêm các trường khác nếu cần
                        };
                    }
                    return null;
                }).Where(e => e != null).ToList();
            }

            return new List<Event>();
        }
        // loadSchedule
        // Trong FirebaseAuthService.cs
        // Sửa GetScheduleAsync (Dùng để load 1 ngày nếu cache miss)
        public async Task<List<Event>> GetScheduleAsync(DateTime date)
        {
            string dateKey = date.ToString("yyyy-MM-dd");

            // 1. Cache
            if (UserSession.ScheduleCache.ContainsKey(dateKey))
                return UserSession.ScheduleCache[dateKey];

            var userDoc = await GetCurrentUserDocAsync();
            if (userDoc == null)
                return new List<Event>();

            // 2. Load từ Firebase và Cache lại
            var events = await GetEventsFromFirebase(userDoc, dateKey);

            // 3. Cache
            UserSession.ScheduleCache[dateKey] = events;

            return events;
        }

        // Load all schedule  
        public async Task<Dictionary<string, List<Event>>> GetAllSchedulesAsync()
        {
            var result = new Dictionary<string, List<Event>>();
            var userDoc = await GetCurrentUserDocAsync();
            if (userDoc == null)
                return result;

            var snap = await userDoc
                .Collection("Schedule")
                .GetSnapshotAsync();

            foreach (var doc in snap.Documents)
            {
                var data = doc.ToDictionary();
                // Kiểm tra các trường cần thiết trước khi cast
                if (!data.ContainsKey("UId") || !data.ContainsKey("Title") || !data.ContainsKey("Start") || !data.ContainsKey("End"))
                {
                    // Bỏ qua document không hợp lệ
                    continue;
                }

                DateTime start;
                DateTime end;

                // Xử lý Start và End từ Timestamp hoặc DateTime (tùy thuộc vào cách bạn lưu)
                if (data["Start"] is Timestamp startTs)
                    start = startTs.ToDateTime();
                else if (data["Start"] is DateTime startDt)
                    start = startDt;
                else
                    continue; // Bỏ qua nếu không phải Timestamp hoặc DateTime

                if (data["End"] is Timestamp endTs)
                    end = endTs.ToDateTime();
                else if (data["End"] is DateTime endDt)
                    end = endDt;
                else
                    continue; // Bỏ qua nếu không phải Timestamp hoặc DateTime


                var ev = new Event
                {
                    UId = data["UId"].ToString(), // Lấy UId từ trường UId trong Document
                    Title = data["Title"].ToString(),
                    Description = data.ContainsKey("Description") ? data["Description"].ToString() : "",
                    Frequency = data.ContainsKey("Frequency") ? data["Frequency"].ToString() : "None",
                    Start = start,
                    End = end,
                };

                // Lấy DateKey (chỉ ngày) của sự kiện
                string dateKey = ev.Start.ToString("yyyy-MM-dd");

                if (!result.ContainsKey(dateKey))
                    result[dateKey] = new List<Event>();

                // Thêm vào danh sách sự kiện của ngày tương ứng
                result[dateKey].Add(ev);
            }

            UserSession.ScheduleCache = result;
            return result;
        }

        //Update event
        public async Task UpdateEventAsync(DateTime date, Event ev)
        {
            var userDoc = await GetCurrentUserDocAsync();
            if (userDoc == null) return;

            string dateKey = date.ToString("yyyy-MM-dd");

            var data = new Dictionary<string, object>
    {
        { "Title", ev.Title },
        { "Description", ev.Description },
        { "Start", ev.Start },
        { "End", ev.End },
        { "Frequency", ev.Frequency },
        { "TimezoneId", ev.TimezoneId }
    };

            await userDoc
                .Collection("Schedule")
                .Document(dateKey)
                .UpdateAsync(data);
        }

        // Delete event
        public async Task<string> DeleteEventAsync(Event ev)
        {
            var userDoc = await GetCurrentUserDocAsync();
            if (userDoc == null)
                return "Không tìm thấy user";

            string dateKey = ev.Start.ToString("yyyy-MM-dd");

            // 1. Kiểm tra cache (Calendar.cs đã xử lý xóa event khỏi cache trước khi gọi hàm này)
            if (!UserSession.ScheduleCache.ContainsKey(dateKey) || UserSession.ScheduleCache[dateKey].Count == 0)
            {
                // Điều kiện này xảy ra khi: 
                // a) Ngày không tồn tại trong cache HOẶC
                // b) Calendar vừa xóa sự kiện cuối cùng trong cache.

                // Nếu list events trong cache rỗng, ta xóa luôn Document ngày trên Firebase.
                await userDoc
                    .Collection("Schedule")
                    .Document(dateKey)
                    .DeleteAsync();

                return "SUCCESS";
            }

            // 2. Nếu vẫn còn sự kiện trong ngày (List trong cache chưa rỗng)

            var events = UserSession.ScheduleCache[dateKey]; // List đã được cập nhật từ Calendar.cs

            // 3. Cập nhật Firebase bằng List đã xóa sự kiện
            var eventsData = events.Select(e => new Dictionary<string, object>
    {
        { "UId", e.UId },
        { "Title", e.Title },
        { "Start", e.Start },
        { "End", e.End },
        { "Frequency", e.Frequency },
        { "Description", e.Description },
        { "TimezoneId", e.TimezoneId },
    }).ToList();

            var updateData = new Dictionary<string, object>
    {
        { "Events", eventsData }
    };

            // Ghi đè lại Document ngày với List sự kiện còn lại
            await userDoc
                .Collection("Schedule")
                .Document(dateKey)
                .SetAsync(updateData);

            return "SUCCESS";
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
        //Thêm mục tiêu
        public async Task<string> AddAimAsync(Aim aim)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                string aimId = Guid.NewGuid().ToString();
                aim.Id = aimId;

                var data = new Dictionary<string, object>
                {
                    { "Id", aimId },
                    { "Ten", aim.title },
                    { "MoTa", aim.mota },
                    { "TrangThai", (int)aim.status },
                    { "DateStart", Timestamp.FromDateTime(aim.date_start.ToUniversalTime()) },
                    { "DateEnd", Timestamp.FromDateTime(aim.date_end.ToUniversalTime()) }
                };

                await userDoc
                    .Collection("MucTieu")
                    .Document(aimId)
                    .SetAsync(data);

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi thêm mục tiêu: " + ex.Message;
            }
        }
        //Lấy dữ liệu mục tiêu
        public async Task<List<Aim>> GetAllAimsAsync()
        {
            var list = new List<Aim>();

            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return list;

                QuerySnapshot snap = await userDoc
                    .Collection("MucTieu")
                    .GetSnapshotAsync();

                foreach (var doc in snap.Documents)
                {
                    var data = doc.ToDictionary();

                    Aim aim = new Aim
                    {
                        Id = data["Id"].ToString(),
                        title = data["Ten"].ToString(),
                        mota = data["MoTa"].ToString(),
                        status = (AimStatus)Convert.ToInt32(data["TrangThai"]),
                        date_start = ((Timestamp)data["DateStart"]).ToDateTime(),
                        date_end = ((Timestamp)data["DateEnd"]).ToDateTime()
                    };

                    list.Add(aim);
                }

                return list;
            }
            catch
            {
                return list;
            }
        }
        //Update dữ liệu
        public async Task<string> UpdateAimAsync(Aim aim)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                var data = new Dictionary<string, object>
                {
                    { "Ten", aim.title },
                    { "MoTa", aim.mota },
                    { "TrangThai", (int)aim.status },
                    { "DateStart", Timestamp.FromDateTime(aim.date_start.ToUniversalTime()) },
                    { "DateEnd", Timestamp.FromDateTime(aim.date_end.ToUniversalTime()) }
                };

                await userDoc
                    .Collection("MucTieu")
                    .Document(aim.Id)
                    .UpdateAsync(data);

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi cập nhật mục tiêu: " + ex.Message;
            }
        }
        //Xóa mục tiêu
        public async Task<string> DeleteAimAsync(string aimId)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                await userDoc
                    .Collection("MucTieu")
                    .Document(aimId)
                    .DeleteAsync();

                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa mục tiêu: " + ex.Message;
            }
        }

        //AddPomo
        public async Task<string> AddPomoAsync(PomoData data)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                data.MaPomodoro = Guid.NewGuid().ToString();


                var pomoDict = new Dictionary<string, object>
                {
                    { "MaPomodoro", data.MaPomodoro },
                    {"MaND", data.MaND },
                    {"NgayThucHien", Timestamp.FromDateTime(data.NgayThucHien.ToUniversalTime()) },
                    {"SoPhien", data.SoPhien },
                    {"TongThoiGian", data.TongThoiGian }
                };

                await userDoc
                    .Collection("Pomodoro")
                    .Document(data.MaPomodoro)
                    .SetAsync(pomoDict);
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "Lỗi lưu Pomodoro: " + ex.Message;
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