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

namespace KingITGalishnikov
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public static int Employee_number = 1;
        string _login, _password;

        public Authorization()
        {
            InitializeComponent();
        }
        int i = 0;
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            Sotrudniki User = null;

            _login = LoginText.Text;
            _password = PasswordText.Password;
            User = KingITGalishnikovEntities.GetContext().Sotrudniki.Where(p => p.Password == _password && p.Login.ToLower() == _login.ToLower()).FirstOrDefault();
            if (i < 3)

                if (User == null) 
                {
                    i++; MessageBox.Show("Не найдено"); 
                }
                else if (User.Login == "admin ")
                {
                    MessageBox.Show("Успешно");
                    _login = User.Login;
                    manager.MainFrame.Content = new ListSC();
                }
                else
                {
                    Employee_number = User.ID_employee;
                    MessageBox.Show("Успешно");
                    _login = User.Login;
                    manager.MainFrame.Content = new ListSC();
                }
            else
            {
                MessageBox.Show("Попытки авторизации исчерпаны,пройдите капчу!");
                manager.MainFrame.Navigate(new Captcha());
            }
        }
    }
}

