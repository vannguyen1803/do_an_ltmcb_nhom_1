using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_doan.Models
{
    internal class NguoiDung
    {
        [FirestoreProperty("Email")]
        public string Email { get; set; }


        [FirestoreProperty("HoTen")]
        public string HoTen { get; set; }


        [FirestoreProperty("MaND")]
        public string MaND { get; set; }


        [FirestoreProperty("Pass")]
        public string Pass { get; set; }


        [FirestoreProperty("TrangThai")]
        public bool TrangThai { get; set; }


        [FirestoreProperty("Username")]
        public string Username { get; set; }


        [FirestoreProperty("NgayTao")]
        public Timestamp NgayTao { get; set; }
    }
}
