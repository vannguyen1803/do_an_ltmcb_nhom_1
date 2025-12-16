using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Firestore;

namespace Project_doan
{

    [FirestoreData]
    public class Diary
    {
        [FirestoreProperty]
        public string Title { get; set; }

        [FirestoreProperty]
        public string Date { get; set; } // yyyy-MM-dd

        [FirestoreProperty]
        public string ContentRtf { get; set; }
    }
}
