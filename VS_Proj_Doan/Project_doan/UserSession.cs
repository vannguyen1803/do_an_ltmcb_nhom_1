using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_doan
{
    internal class UserSession
    {
        public static string UserId { get; set; }
        public static string Email { get; set; }
        public static string Username { get; set; }
        public static string HoTen { get; set; }
        public static string MaND { get; set; }
        public static string Phone { get; set; }
        public static DateTime Birthday { get; set; }
        public static string Language { get; set; }
        public static Dictionary<string, List<Event>> ScheduleCache { get; set; } = new Dictionary<string, List<Event>>();
    }
}
