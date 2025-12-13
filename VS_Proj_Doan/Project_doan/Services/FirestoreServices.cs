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
    internal class FirestoreServices
    {
        private static FirestoreDb db;

        public static FirestoreDb GetDb()
        {
            if(db == null)
            {
                try
                {
                    string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "serviceAccountKey.json");
                    Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", path);
                    db = FirestoreDb.Create("do-an-ltmcb-nhom1");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối Firestore: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
               
            }
            return db;

        }
        public static async Task AddPomo(PomoData data)
        {
            try
            {
                CollectionReference collection = db.Collection("Pomodoro");
                await collection.AddAsync(data);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi lưu dữ liệu: " + ex.Message);
            }
        }

    }
}
