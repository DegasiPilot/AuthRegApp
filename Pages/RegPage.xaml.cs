using AuthRegApp.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
            GenderCb.ItemsSource = App.db.Gender.ToList();
            GenderCb.DisplayMemberPath = "Nazvanie";
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckVoidBoxes())
            {
                Client client = new Client();
                client.Familia = FamiliaTb.Text;
                client.Imya = ImyaTb.Text;
                client.Patronumyc = PatronumycTb.Text;
                client.Telephone = TelephoneTb.Text;
                client.Email = EmailTb.Text;
                client.Gender_Id = ((Gender)GenderCb.SelectedItem).Id;
                client.Birthsday = BirthsdayDp.DisplayDate;
                User user = new User();
                user.Client_Id = client.Id;
                user.Role_Id = 1;
                user.Login = LoginTb.Text;
                user.Password = PasswordPb.Password;
                if (TryAddUser(user))
                {
                    App.db.Client.Add(client);
                    App.db.SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен!");
                }
                else
                {
                    MessageBox.Show($"Пользователь с логином {user.Login} уже существует");
                }
            }
        }

        private bool TryAddUser(User user)
        {
            if(App.db.User.Any(x => x.Login == LoginTb.Text))
            {
                return false;
            }
            else
            {
                App.db.User.Add(user);
                return true;
            }
        }

        private bool CheckVoidBoxes()
        {
            StringBuilder errors = new StringBuilder();
            if (FamiliaTb.Text == "")
            {
                errors.AppendLine("Фамилия пуста!");
            }
            if (ImyaTb.Text == "")
            {
                errors.AppendLine("Имя пусто!");
            }
            if (PatronumycTb.Text == "")
            {
                errors.AppendLine("Отчество пусто!");
            }
            if (TelephoneTb.Text == "")
            {
                errors.AppendLine("Телефон пуст!");
            }
            if (EmailTb.Text == "")
            {
                errors.AppendLine("Email пуст!");
            }
            if (GenderCb.SelectedItem == null)
            {
                errors.AppendLine("Гендер пуст!");
            }
            if (BirthsdayDp.SelectedDate == null)
            {
                errors.AppendLine("Дата рождения пуста!");
            }
            if (LoginTb.Text == "")
            {
                errors.AppendLine("Логин пуст!");
            }
            if (PasswordPb.Password == "")
            {
                errors.AppendLine("Пароль пуст!");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return true;
            }
            else
            {
                return false;
            }
        }

        private void GoToAuthBtn_Click(object sender, RoutedEventArgs e)
        {
            MyNavigation.NextPage(new PageComponent(new AuthPage(), "Авторизация"));
        }
    }
}
