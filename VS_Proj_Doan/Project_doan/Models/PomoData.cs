using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Project_doan.Models
{
    [FirestoreData]
    public class PomoData
    {
        [FirestoreProperty]
        public string MaPomodoro { get; set; }

        [FirestoreProperty]
        public string MaND { get; set; }

        [FirestoreProperty]
        public DateTime NgayThucHien { get; set; }

        [FirestoreProperty]
        public int SoPhien { get; set; }

        [FirestoreProperty]
        public int TongThoiGian { get;set; }

    }
}
