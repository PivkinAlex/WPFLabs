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
    /// Логика взаимодействия для Log_In.xaml
    /// </summary>
    public partial class Log_In : Window
    {
        public Log_In()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Validator.EmailValid(Login) == false)
            {
                if (string.IsNullOrWhiteSpace(Login.Text))
                    MessageBox.Show("Пустое значение адреса почты недопустимо");
                else
                    MessageBox.Show("Неправильно введен логин");
            }
            else if (Validator.PassValid(Password) == false)
            {
                if (string.IsNullOrWhiteSpace(Password.Password))
                    MessageBox.Show("Пустое значение пароля недопустимо");
                else
                    MessageBox.Show("Неправильно введен пароль");
            }
            else if (UserRepository.CheckUser(Login.Text, Password.Password))
            {
                var wind = new MainEmpty();
                wind.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователя с таким логином и паролем не существует");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var wind = new Registration();
            wind.Show();
            this.Close();
        }
    }
}