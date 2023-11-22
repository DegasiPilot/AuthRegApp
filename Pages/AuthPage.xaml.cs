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

namespace AuthRegApp.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if(LoginTb.Text == "")
            {
                errors.AppendLine("Логин пуст!");
            }
            if(PasswordPb.Password == "")
            {
                errors.AppendLine("Пароль пуст!");
            }

            if(errors.Length == 0)
            {
                if(App.db.User.Any(x => x.Login == LoginTb.Text && x.Password == PasswordPb.Password))
                {
                    MessageBox.Show("Вы успешно вошли!");
                }
                else
                {
                    MessageBox.Show("Нет пользователя с таким логином и паролем!");
                }
            }
            else
            {
                MessageBox.Show(errors.ToString());
            }
        }

        private void GoToRegBtn_Click(object sender, RoutedEventArgs e)
        {
            MyNavigation.NextPage(new PageComponent(new RegPage(), "Регистрация"));
        }
    }
}
