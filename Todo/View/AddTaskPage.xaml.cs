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
using Todo.Entities;
using Todo.Repository;
using Todo.Responses;

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для AddTaskPage.xaml
    /// </summary>
    public partial class AddTaskPage : Page
    {
        private readonly TodoRepository _todoRepository;
        private readonly AuthResponse _authResponse;
        public AddTaskPage(AuthResponse response)
        {
            InitializeComponent();
            _authResponse = response;
            _todoRepository = new TodoRepository(response.access_token);
            Category.ItemsSource = new List<string>()
            {
                "Дом","Работа","Учёба","Отдых"
            };
        }
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            var messageBoxResult = MessageBox.Show("Вы действительно хотите отменить действия?", "Отмена действий", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                var inheritResult = MessageBox.Show("Назад?", "Возврат на предыдущую страницу", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (inheritResult == MessageBoxResult.Yes)
                    Manager.MainFrame?.GoBack();
            }
            else
            {
                NameTask.Text = "";
                DateTaskPicker.Text = "";
                TaskTimePicker.Text = "";
                Content.Text = "";
                Category.Text = "";
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameTask.Text) || string.IsNullOrEmpty(DateTaskPicker.Text) || string.IsNullOrEmpty(TaskTimePicker.Text) || string.IsNullOrEmpty(Content.Text) || string.IsNullOrEmpty(Category.Text))
            {
                MessageBox.Show("Все поля обязательны для заполнения", "Предупреждение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var result = _todoRepository.CreateTodo(Category.SelectedItem as string, NameTask.Text, Content.Text, DateTime.Parse(DateTaskPicker.Text));
            if (result.ToLower() == "successfully")
            {
                var main = new MainPage(_authResponse)
                {
                    Todos = _todoRepository.GetAllTodos(),
                };
                Manager.MainFrame?.Navigate(main);
            }
            else
            {
                MessageBox.Show("При создании заметки произошла ошибка", "Предупреждение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectorCategory = Category.SelectedItem as string;
            if (string.IsNullOrEmpty(selectorCategory))
            {
                switch (selectorCategory)
                {
                    case "Дом": break;
                    case "Работа": break;
                    case "Учёба": break;
                    case "Отдых": break;
                }
            }
        }
    }
}
