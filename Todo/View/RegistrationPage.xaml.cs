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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private readonly UserRepository _userRepository;
        public RegistrationPage()
        {
            InitializeComponent();
            _userRepository = new UserRepository();
        }
        private void Back_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.GoBack();

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            var user = _userRepository.Register(Name.Text, post.Text, Password.Text, PasswordConfirmation.Text);
            if (user == null)
            {
                MessageBox.Show("При регистрации произошла ошибка", "Предупреждение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
                Manager.MainFrame?.Navigate(new MainEmptyPage(user));
        }
    }
}
