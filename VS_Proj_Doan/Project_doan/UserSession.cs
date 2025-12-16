using System;
using System.Collections.Generic;

namespace Project_doan
{
    public static class UserSession
    {
        public static string MaND { get; set; }
        public static string UserId { get; set; }
        public static string Email { get; set; }
        public static string Username { get; set; }
        public static string HoTen { get; set; }
        public static string Phone { get; set; }
        public static DateTime Birthday { get; set; }

        public static Dictionary<string, List<Event>> ScheduleCache { get; set; } = new Dictionary<string, List<Event>>();

        public static List<Dictionary<string, object>> NoteCache { get; set; } = new List<Dictionary<string, object>>();

        public static void ClearSession()
        {
            MaND = null;
            UserId = null;
            Email = null;
            Username = null;
            HoTen = null;
            Phone = null;
            Birthday = DateTime.MinValue;
            ScheduleCache.Clear();
            NoteCache.Clear();
        }
    }
}