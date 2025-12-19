using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_doan
{
    public enum AimStatus
    {
        DangThucHien = 0,
        HoanThanh = 1,
        ChuaThucHien = 2
    }
    public class Aim
    {
        public string Id { get; set; }
        public string title { get; set; }
        public string mota { get; set; }
        public AimStatus status { get; set; }
        public DateTime date_start { get; set; }
        public DateTime date_end { get; set; }

    }
}