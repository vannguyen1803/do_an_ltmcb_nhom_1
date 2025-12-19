using System;

namespace Project_doan
{
    public class Event
    {
        public string UId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Frequency { get; set; }
        public string TimezoneId { get; set; }

        public Event()
        {
            UId = Guid.NewGuid().ToString();
            Title = "";
            Description = "";
            Start = DateTime.Now;
            End = DateTime.Now.AddHours(1);
            Frequency = "None";
            TimezoneId = TimeZoneInfo.Local.Id;
        }

        public Event(string title, DateTime start, DateTime end)
        {
            UId = Guid.NewGuid().ToString();
            Title = title;
            Description = "";
            Start = start;
            End = end;
            Frequency = "None";
            TimezoneId = TimeZoneInfo.Local.Id;
        }
    }
}