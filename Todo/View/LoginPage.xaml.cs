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
using Todo.Repository;

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private readonly UserRepository _userRepository;
        public LoginPage()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }

        private void Registration_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(new RegistrationPage());

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var authResponse = _userRepository.Authorize(Password.Text, post.Text);
            if (authResponse == null)
            {
                MessageBox.Show("Данный пользователь не найден");
                return;
            }
            if (authResponse.access_token != null && authResponse.access_token != null)
            {
                var todoRepository = new TodoRepository(authResponse.access_token);
                var user = authResponse.User;
                user.Todos = todoRepository.GetAllTodos();
                if (user.Todos == null || !user.Todos.Any())
                    Manager.MainFrame?.Navigate(new MainEmptyPage(authResponse));
                else
                    Manager.MainFrame?.Navigate(new MainPage(authResponse));

            }
        }
    }
}
