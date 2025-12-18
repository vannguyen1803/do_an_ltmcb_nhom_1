using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_doan
{
    public static class XuatLich
    {
        public static string ExportEventsToIcs(List<Event> events, string fileName)
        {
            var sb = new StringBuilder();
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("PRODID:-//Project Do An//Calendar Export Tool//EN");

            foreach (var evt in events)
            {
                string dtStamp = DateTime.UtcNow.ToString("yyyyMMddTHHmmssZ");
                string dtStartUtc = evt.Start.ToUniversalTime().ToString("yyyyMMddTHHmmssZ");
                string dtEndUtc = evt.End.ToUniversalTime().ToString("yyyyMMddTHHmmssZ");

                sb.AppendLine("BEGIN:VEVENT");

                string uid = string.IsNullOrEmpty(evt.UId) ? Guid.NewGuid().ToString() + "@yourproject.com" : evt.UId + "@yourproject.com";
                sb.AppendLine($"UID:{uid}");
                sb.AppendLine($"DTSTAMP:{dtStamp}");

                sb.AppendLine($"SUMMARY:{evt.Title}");
                sb.AppendLine($"DESCRIPTION:{evt.Description}");


                sb.AppendLine($"DTSTART:{dtStartUtc}");
                sb.AppendLine($"DTEND:{dtEndUtc}");

                if (!string.IsNullOrEmpty(evt.Frequency))
                {
                    sb.AppendLine($"RRULE:{evt.Frequency}");
                }
                sb.AppendLine("END:VEVENT");
            }

            sb.AppendLine("END:VCALENDAR");
            try
            {
                File.WriteAllText(fileName, sb.ToString(), Encoding.UTF8);
                return $"Xuất file {fileName} thành công!";
            }
            catch (Exception ex)
            {
                return $"Lỗi khi ghi file: {ex.Message}";
            }
        }
    }
}
