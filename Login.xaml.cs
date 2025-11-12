using System.Windows;
using System;
using System.Windows.Media.Imaging;

namespace DoAnCuoiKy
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {

        public Login()
        {
            InitializeComponent();
        }
        private bool isPasswordVisible = false;
        /// <summary>
        /// Hàm này sẽ được gọi khi bạn nhấn nút "Sign In"
        /// </summary>
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            string email = tb_email.Text;
            string password = tb_pass.Password;

            if (email == "admin" && password == "123")
            {
                // Đăng nhập thành công!
                tb_error.Text = ""; // Xóa thông báo lỗi nếu có

                // 1. Tạo một cửa sổ Home mới
                Home homeWindow = new Home();

                // 2. Hiển thị cửa sổ Home
                homeWindow.Show();

                // 3. Đóng cửa sổ Đăng nhập (Login)
                this.Close();
            }
            else
            {
                // Đăng nhập thất bại
                tb_error.Text = "Sai email hoặc mật khẩu";
            }
        }
        private void btn_toggle_pass_Click(object sender, RoutedEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible; // Đảo trạng thái

            if (isPasswordVisible)
            {
                // HIỂN THỊ MẬT KHẨU
                tb_pass_visible.Visibility = Visibility.Visible; // Hiện TextBox
                tb_pass.Visibility = Visibility.Collapsed;     // Ẩn PasswordBox
                tb_pass_visible.Text = tb_pass.Password;     // Copy text

                // SỬA LỖI: Đổi ảnh sang "mắt mở"
                // (Giả sử bạn có file /Images/eye_open.png)
                img_toggle_pass.Source = new BitmapImage(new Uri("/Images/eye_open.png", UriKind.Relative));
            }
            else
            {
                // ẨN MẬT KHẨU
                tb_pass_visible.Visibility = Visibility.Collapsed; // Ẩn TextBox
                tb_pass.Visibility = Visibility.Visible;       // Hiện PasswordBox
                tb_pass.Password = tb_pass_visible.Text;       // Copy text

                // SỬA LỖI: Đổi ảnh về "mắt đóng"
                // (Giả sử bạn có file /Images/eye_closed.png)
                img_toggle_pass.Source = new BitmapImage(new Uri("/Images/eye_close.png", UriKind.Relative));
            }
        }
    }
}