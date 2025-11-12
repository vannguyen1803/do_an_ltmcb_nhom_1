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

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {

            string email = tb_email.Text;
            string password = tb_pass.Password;

            if (email == "admin" && password == "123")
            {
        
                tb_error.Text = ""; 
                Home homeWindow = new Home();
                homeWindow.Show();
                this.Close();
            }
            else
            {
               
                tb_error.Text = "Sai email hoặc mật khẩu";
            }
        }
        private void btn_toggle_pass_Click(object sender, RoutedEventArgs e)
        {
            isPasswordVisible = !isPasswordVisible; 

            if (isPasswordVisible)
            {
               
                tb_pass_visible.Visibility = Visibility.Visible; 
                tb_pass.Visibility = Visibility.Collapsed;     
                tb_pass_visible.Text = tb_pass.Password;     

                img_toggle_pass.Source = new BitmapImage(new Uri("/Images/eye_open.png", UriKind.Relative));
            }
            else
            {
 
                tb_pass_visible.Visibility = Visibility.Collapsed; 
                tb_pass.Visibility = Visibility.Visible;       
                tb_pass.Password = tb_pass_visible.Text;     

                img_toggle_pass.Source = new BitmapImage(new Uri("/Images/eye_close.png", UriKind.Relative));
            }
        }
    }
}
