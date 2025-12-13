using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_doan
{
    internal class Event
    {
        public string UId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string TimezoneId { get; set; }
        public string Frequency { get; set; }


    }
}
