using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GlanApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;

        public MainWindow()
        {
            InitializeComponent();

            db = new ApplicationContext();

        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();
            string pass2 = passBox2.Password.Trim();
            string email = textBoxEmail.Text.ToLower();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен содержать минимум 5 символов";
                textBoxLogin.Foreground = Brushes.Red;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Логин должен содержать минимум 5 символов";
                passBox.Foreground = Brushes.Red;
            }
            else if (pass != pass2)
            {
                passBox2.ToolTip = "Подтверждение не совпадает с паролем";
                passBox2.Foreground = Brushes.Red;
            }
            else if (email.Length < 5 || !email.Contains("@"))
            {
                textBoxEmail.ToolTip = "Email введен не корректно";
                textBoxEmail.Foreground = Brushes.Red;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.Background = Brushes.Transparent;
                passBox2.Background = Brushes.Transparent;
                textBoxEmail.Background = Brushes.Transparent;

                
                User user = new User(login, email, pass);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide();
            }



        }

        private void Buttron_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            this.Hide();

        }
    }
}
