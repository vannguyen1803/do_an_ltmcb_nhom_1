using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Project_doan
{
    internal class FirebaseAuthService
    {
        private readonly string apiKey = "AIzaSyCU2rOT6F_N8Ojlkrz6mPhE6Tn1JFfPHtE";

        public async Task<string> SignUpAsync(string email, string password)
        {
            var client = new HttpClient();
            var request = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}",
                content);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Đăng ký thất bại: {result}");

            return result;
        }

        public async Task<string> SignInAsync(string email, string password)
        {
            var client = new HttpClient();
            var request = new
            {
                email = email,
                password = password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}",
                content);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Đăng nhập thất bại: {result}");

            return result;
        }

        public async Task<string> ResetPasswordAsync(string email)
        {
            var client = new HttpClient();
            var request = new { requestType = "PASSWORD_RESET", email = email };
            var content = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={apiKey}",
                content);

            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Gửi email reset mật khẩu thất bại: {result}");

            return result;
        }
    }
}
