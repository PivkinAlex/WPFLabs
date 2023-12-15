using Desktop.Repository;
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

namespace Desktop
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.NameValid(Name) == false)
            {
                if (string.IsNullOrWhiteSpace(Name.Text))
                    MessageBox.Show("Пустое имя недопустимо");
                else
                    MessageBox.Show("Неправильно введено имя");
            }
            else if (Validator.EmailValid(Email) == false)
            {
                if (string.IsNullOrWhiteSpace(Email.Text))
                    MessageBox.Show("Пустое значение адреса почты недопустимо");
                else
                    MessageBox.Show("Неправильно введена почта");
            }
            else if (Validator.PassValid(Password1) == false)
            {
                if (string.IsNullOrWhiteSpace(Password1.Password))
                    MessageBox.Show("Пустое значение пароля недопустимо");
                else if (string.IsNullOrWhiteSpace(Password2.Password))
                    MessageBox.Show("Пустое значение пароля недопустимо");
                else
                    MessageBox.Show("Пароль слишком короткий (минимум 6 символов)");
            }
            else if (Validator.CheckPassValid(Password1, Password2))
            {
                MessageBox.Show("Пароли не совпадают");
            }
            else if (UserRepository.CheckEmail(Email.Text))
            {
                UserRepository.AddUser(Name.Text, Email.Text, Password1.Password);
                var wind = new MainEmpty();
                wind.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Почта уже зарегестрирована");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var wind = new Log_In();
            wind.Show();
            this.Close();
        }
    }
}
