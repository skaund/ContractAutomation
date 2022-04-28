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
using System.Windows.Shapes;

namespace GlanApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim();
            string pass = passBox.Password.Trim();


            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "Логин должен содержать минимум 5 символов";
                textBoxLogin.Foreground = Brushes.Red;


            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "Пароль должен содержать минимум 5 символов";
                passBox.Foreground = Brushes.Red;
            }
 
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.Background = Brushes.Transparent;

                User authUser = null;

                using (ApplicationContext db = new ApplicationContext())
                {
                    authUser = db.Users.Where(b => b.login == login && b.pass == pass).FirstOrDefault();

                }
                if (authUser != null)
                {
                    
                    UserPageWindow userPageWindow = new UserPageWindow();
                    userPageWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
                


            }
        }

        private void Button_Window_Registration_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
