using Google.Cloud.Firestore;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                    UserSession.UserId = doc.Id;


                    UserSession.Username = data["Username"].ToString();
                    UserSession.Email = data["Email"].ToString();
                    UserSession.HoTen = data["HoTen"].ToString();

                    UserSession.Phone = data.ContainsKey("Phone") ? data["Phone"].ToString() : "";

                    if (data.ContainsKey("Birthday"))
                    {
                        Timestamp t = (Timestamp)data["Birthday"];
                        UserSession.Birthday = t.ToDateTime().ToLocalTime();
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống. Vui lòng thử lại.";
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống. Vui lòng thử lại.";
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống. Vui lòng thử lại.";
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
                }
                return "SUCCESS";
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống. Vui lòng thử lại.";
            }
        }

        //getcurrentuser
        private async Task<DocumentReference> GetCurrentUserDocAsync()
        {
            try
            {
                CollectionReference users = _db.Collection("NguoiDung");
                Query query = users.WhereEqualTo("Username", UserSession.Username);

                QuerySnapshot snap = await query.GetSnapshotAsync();

                if (snap.Count == 0)
                    return null;

                return snap.Documents[0].Reference;
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                MessageBox.Show("Không có kết nối Internet. Vui lòng kiểm tra mạng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (RpcException ex)
            {
                MessageBox.Show("Không thể kết nối dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Kết nối quá thời gian. Vui lòng thử lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống. Vui lòng thử lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi lưu ghi chú. Vui lòng thử lại.";
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
        public async Task<string> SaveScheduleAsync(DateTime date, Event evt)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                string dateKey = date.ToString("yyyy-MM-dd");

                var eventData = new Dictionary<string, object>
        {
            { "UId", evt.UId },
            { "Title", evt.Title },
            { "Description", evt.Description ?? "" },
            { "Start", Timestamp.FromDateTime(evt.Start.ToUniversalTime()) },
            { "End", Timestamp.FromDateTime(evt.End.ToUniversalTime()) },
            { "Frequency", evt.Frequency ?? "None" },
            { "TimezoneId", evt.TimezoneId ?? TimeZoneInfo.Local.Id },
            { "Date", dateKey },
            { "UpdatedAt", Timestamp.GetCurrentTimestamp() }
        };

                await userDoc
                    .Collection("Schedule")
                    .Document(evt.UId)
                    .SetAsync(eventData);

                if (!UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    UserSession.ScheduleCache[dateKey] = new List<Event>();
                }

                UserSession.ScheduleCache[dateKey].RemoveAll(e => e.UId == evt.UId);

                UserSession.ScheduleCache[dateKey].Add(evt);

                return "SUCCESS";
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi lưu sự kiện. Vui lòng thử lại.";
            }
        }

        // Load all schedule với Event objects
        public async Task<Dictionary<string, List<Event>>> GetAllSchedulesAsync()
        {
            var scheduleDict = new Dictionary<string, List<Event>>();

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
                    try
                    {
                        var data = doc.ToDictionary();

                        if (!data.ContainsKey("Date"))
                            continue;

                        string dateKey = data["Date"].ToString();

                        Event evt = new Event
                        {
                            UId = doc.Id,
                            Title = data.ContainsKey("Title") ? data["Title"].ToString() :
                                    data.ContainsKey("Content") ? data["Content"].ToString() : "Untitled",
                            Description = data.ContainsKey("Description") ? data["Description"].ToString() : "",
                            Start = data.ContainsKey("Start") ? ((Timestamp)data["Start"]).ToDateTime().ToLocalTime() : DateTime.Parse(dateKey),
                            End = data.ContainsKey("End") ? ((Timestamp)data["End"]).ToDateTime().ToLocalTime() : DateTime.Parse(dateKey).AddHours(1)
                        };

                        if (!scheduleDict.ContainsKey(dateKey))
                        {
                            scheduleDict[dateKey] = new List<Event>();
                        }

                        scheduleDict[dateKey].Add(evt);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing schedule document: {ex.Message}");
                        continue;
                    }
                }

                return scheduleDict;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetAllSchedulesAsync: {ex.Message}");
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi cập nhật ghi chú. Vui lòng thử lại.";
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa ghi chú. Vui lòng thử lại.";
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi thêm mục tiêu. Vui lòng thử lại.";
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi cập nhật mục tiêu: ";
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa mục tiêu: " ;
            }
        }
        // Save Pomodoro Session
        public async Task<string> SavePomodoroSessionAsync(PomodoroSession session)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                var sessionData = new Dictionary<string, object>
        {
            { "SessionId", session.SessionId },
            { "NgayBatDau", Timestamp.FromDateTime(session.NgayBatDau.ToUniversalTime()) },
            { "NgayKetThuc", Timestamp.FromDateTime(session.NgayKetThuc.ToUniversalTime()) },
            { "PhutHoc", session.PhutHoc },
            { "PhutNghi", session.PhutNghi },
            { "TongPhutHocThucTe", session.TongPhutHocThucTe },
            { "TrangThai", session.TrangThai },
            { "NgayTao", session.NgayBatDau.Date.ToString("yyyy-MM-dd") }
        };

                await userDoc
                    .Collection("PomodoroSessions")
                    .Document(session.SessionId)
                    .SetAsync(sessionData);

                return "SUCCESS";
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi phiên pomodoro: ";
            }
        }

        // Get Pomodoro Sessions by Date
        public async Task<List<PomodoroSession>> GetPomodoroSessionsByDateAsync(DateTime date)
        {
            var list = new List<PomodoroSession>();

            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                {
                    System.Diagnostics.Debug.WriteLine("User document not found");
                    return list;
                }

                string dateKey = date.Date.ToString("yyyy-MM-dd");

                QuerySnapshot snap = await userDoc
                    .Collection("PomodoroSessions")
                    .WhereEqualTo("NgayTao", dateKey)
                    .GetSnapshotAsync();

                if (snap == null || snap.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine($"No sessions found for {dateKey}");
                    return list;
                }

                foreach (var doc in snap.Documents)
                {
                    try
                    {
                        var data = doc.ToDictionary();

                        var session = new PomodoroSession
                        {
                            SessionId = data.ContainsKey("SessionId") ? data["SessionId"].ToString() : "",
                            NgayBatDau = data.ContainsKey("NgayBatDau") ? ((Timestamp)data["NgayBatDau"]).ToDateTime().ToLocalTime() : DateTime.MinValue,
                            NgayKetThuc = data.ContainsKey("NgayKetThuc") ? ((Timestamp)data["NgayKetThuc"]).ToDateTime().ToLocalTime() : DateTime.MinValue,
                            PhutHoc = data.ContainsKey("PhutHoc") ? Convert.ToInt32(data["PhutHoc"]) : 0,
                            PhutNghi = data.ContainsKey("PhutNghi") ? Convert.ToInt32(data["PhutNghi"]) : 0,
                            TongPhutHocThucTe = data.ContainsKey("TongPhutHocThucTe") ? Convert.ToInt32(data["TongPhutHocThucTe"]) : 0,
                            TrangThai = data.ContainsKey("TrangThai") ? data["TrangThai"].ToString() : "Unknown"
                        };

                        list.Add(session);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing session document: {ex.Message}");
                        continue;
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetPomodoroSessionsByDateAsync: " + ex.Message);
                return list;
            }
        }

        // Get Statistics by Date Range
        public async Task<Dictionary<string, int>> GetPomodoroStatisticsAsync(DateTime fromDate, DateTime toDate)
        {
            var stats = new Dictionary<string, int>();

            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                {
                    System.Diagnostics.Debug.WriteLine("User document not found");
                    return stats;
                }

                QuerySnapshot snap = await userDoc
                    .Collection("PomodoroSessions")
                    .GetSnapshotAsync();

                if (snap == null || snap.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("No sessions found");
                    return stats;
                }

                foreach (var doc in snap.Documents)
                {
                    try
                    {
                        var data = doc.ToDictionary();

                        if (!data.ContainsKey("NgayBatDau") || !data.ContainsKey("TongPhutHocThucTe"))
                            continue;

                        DateTime ngayBatDau = ((Timestamp)data["NgayBatDau"]).ToDateTime().ToLocalTime();

                        // Lọc theo date range
                        if (ngayBatDau.Date >= fromDate.Date && ngayBatDau.Date <= toDate.Date)
                        {
                            string dateKey = ngayBatDau.ToString("yyyy-MM-dd");
                            int phutHoc = Convert.ToInt32(data["TongPhutHocThucTe"]);

                            if (stats.ContainsKey(dateKey))
                                stats[dateKey] += phutHoc;
                            else
                                stats[dateKey] = phutHoc;
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing statistics document: {ex.Message}");
                        continue;
                    }
                }

                return stats;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetPomodoroStatisticsAsync: " + ex.Message);
                return stats;
            }
        }

        // Get Total Minutes Today
        public async Task<int> GetTotalMinutesTodayAsync()
        {
            try
            {
                var sessions = await GetPomodoroSessionsByDateAsync(DateTime.Today);

                if (sessions == null || sessions.Count == 0)
                    return 0;

                return sessions.Where(s => s != null && s.TrangThai == "Hoàn thành")
                              .Sum(s => s.TongPhutHocThucTe);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error in GetTotalMinutesTodayAsync: " + ex.Message);
                return 0;
            }
        }
        // Update Event
        public async Task<string> UpdateEventAsync(DateTime date, Event evt)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                string dateKey = date.ToString("yyyy-MM-dd");

                var eventData = new Dictionary<string, object>
        {
            { "UId", evt.UId },
            { "Title", evt.Title },
            { "Description", evt.Description ?? "" },
            { "Start", Timestamp.FromDateTime(evt.Start.ToUniversalTime()) },
            { "End", Timestamp.FromDateTime(evt.End.ToUniversalTime()) },
            { "Frequency", evt.Frequency ?? "None" },
            { "TimezoneId", evt.TimezoneId ?? TimeZoneInfo.Local.Id },
            { "Date", dateKey },
            { "UpdatedAt", Timestamp.GetCurrentTimestamp() }
        };

                await userDoc
                    .Collection("Schedule")
                    .Document(evt.UId)
                    .SetAsync(eventData);

                if (!UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    UserSession.ScheduleCache[dateKey] = new List<Event>();
                }

                UserSession.ScheduleCache[dateKey].RemoveAll(e => e.UId == evt.UId);

                UserSession.ScheduleCache[dateKey].Add(evt);

                return "SUCCESS";
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi cập nhật event: ";
            }
        }

        // Delete Event
        public async Task<string> DeleteEventAsync(Event evt)
        {
            try
            {
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return "Không tìm thấy user";

                await userDoc
                    .Collection("Schedule")
                    .Document(evt.UId)
                    .DeleteAsync();

                // Update cache
                string dateKey = evt.Start.ToString("yyyy-MM-dd");
                if (UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    UserSession.ScheduleCache[dateKey].RemoveAll(e => e.UId == evt.UId);
                }

                return "SUCCESS";
            }
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                return "Lỗi xóa event: " + ex.Message;
            }
        }

        // Get Events by Date
        public async Task<List<Event>> GetEventsByDateAsync(DateTime date)
        {
            var list = new List<Event>();

            try
            {
                string dateKey = date.ToString("yyyy-MM-dd");

                // Kiểm tra cache trước
                if (UserSession.ScheduleCache != null &&
                    UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    // ⚠️ FIX: Lọc lại để đảm bảo chỉ lấy events đúng ngày
                    return UserSession.ScheduleCache[dateKey]
                        .Where(e => e.Start.Date == date.Date)
                        .ToList();
                }

                // Nếu không có trong cache, query từ Firestore
                var userDoc = await GetCurrentUserDocAsync();
                if (userDoc == null)
                    return list;

                QuerySnapshot snap = await userDoc
                    .Collection("Schedule")
                    .WhereEqualTo("Date", dateKey)
                    .GetSnapshotAsync();

                foreach (var doc in snap.Documents)
                {
                    try
                    {
                        var data = doc.ToDictionary();

                        // ⚠️ FIX: Kiểm tra dữ liệu đầy đủ trước khi tạo Event
                        if (!data.ContainsKey("Title") && !data.ContainsKey("Content"))
                        {
                            System.Diagnostics.Debug.WriteLine($"Skipping document {doc.Id}: Missing Title/Content");
                            continue;
                        }

                        Event evt = new Event
                        {
                            UId = doc.Id,
                            Title = data.ContainsKey("Title") ? data["Title"].ToString() :
                                    data.ContainsKey("Content") ? data["Content"].ToString() : "Không có tiêu đề",
                            Description = data.ContainsKey("Description") ? data["Description"].ToString() : "",
                            Start = data.ContainsKey("Start") ?
                                    ((Timestamp)data["Start"]).ToDateTime().ToLocalTime() :
                                    DateTime.Parse(dateKey).AddHours(8),
                            End = data.ContainsKey("End") ?
                                  ((Timestamp)data["End"]).ToDateTime().ToLocalTime() :
                                  DateTime.Parse(dateKey).AddHours(9),
                            Frequency = data.ContainsKey("Frequency") ? data["Frequency"].ToString() : "None",
                            TimezoneId = data.ContainsKey("TimezoneId") ? data["TimezoneId"].ToString() : TimeZoneInfo.Local.Id
                        };

                        if (evt.Start.Date == date.Date)
                        {
                            list.Add(evt);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine($"Skipping event {evt.UId}: Start date {evt.Start.Date} != query date {date.Date}");
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Error parsing event: {ex.Message}");
                        continue;
                    }
                }

                if (!UserSession.ScheduleCache.ContainsKey(dateKey))
                {
                    UserSession.ScheduleCache[dateKey] = list;
                }
                else
                {
                    UserSession.ScheduleCache[dateKey] = list;
                }

                return list;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetEventsByDateAsync: {ex.Message}");
                return list;
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                return "Không có kết nối Internet. Vui lòng kiểm tra mạng.";
            }
            catch (RpcException ex)
            {
                return "Không thể kết nối dữ liệu.";
            }
            catch (TaskCanceledException)
            {
                return "Kết nối quá thời gian. Vui lòng thử lại.";
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lưu Nhật ký: ");
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                MessageBox.Show("Không có kết nối Internet. Vui lòng kiểm tra mạng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (RpcException ex)
            {
                MessageBox.Show("Không thể kết nối dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Kết nối quá thời gian. Vui lòng thử lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tải Nhật ký: " );
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
            catch (RpcException ex) when (ex.StatusCode == StatusCode.Unavailable)
            {
                MessageBox.Show("Không có kết nối Internet. Vui lòng kiểm tra mạng.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (RpcException ex)
            {
                MessageBox.Show("Không thể kết nối dữ liệu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Kết nối quá thời gian. Vui lòng thử lại.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tải danh sách nhật ký: " + ex.Message);
                throw new Exception("Lỗi khi tải danh sách nhật ký: " + ex.Message);
            }
        }
        //logout
        public void LogOut()
        {
            try
            {
                UserSession.UserId = null;
                UserSession.Username = null;
                UserSession.Email = null;
                UserSession.HoTen = null;
                UserSession.Phone = null;
                UserSession.Birthday = DateTime.MinValue;
                UserSession.ScheduleCache?.Clear();
                UserSession.NoteCache?.Clear();

                System.Diagnostics.Debug.WriteLine("User logged out successfully");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during logout: {ex.Message}");
            }
        }
    }
}
