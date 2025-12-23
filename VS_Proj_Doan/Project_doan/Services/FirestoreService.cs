using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Cloud.Firestore;
using Project_doan.Models;
using Project_doan.UserControls;

namespace Project_doan.Services
{
    internal class FirestoreService
    {
        public static FirestoreDb db { get; private set; }

        private const string ProjectId = "do-an-ltmcb-nhom1"; 

        public static void Initialize()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serviceAccountKey.json");
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);

                db = FirestoreDb.Create(ProjectId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối Firestore: " + ex.Message);
            }
        }
        public static async Task AddPomo(PomoData data)
        {
            try
            {
                CollectionReference collection = db.Collection("Pomodoro");
                await collection.AddAsync(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

    }
}