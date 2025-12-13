using Google.Cloud.Firestore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;

namespace Project_doan
{
    internal class FirestoreService
    {
        private readonly FirestoreDb _db;

        public FirestoreService()
        {
            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)
                               .Parent.Parent.FullName;


            string path = Path.Combine(projectPath, "serviceAccountKey.json");


            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS",path);


            _db = FirestoreDb.Create("do-an-ltmcb-nhom1");
        }

        public FirestoreDb GetDb()
        {
            return _db;
        }
    }
}
