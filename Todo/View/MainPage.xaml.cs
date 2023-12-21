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
using System.Collections.ObjectModel;
using Todo.Responses;
using Todo.Repository;
using System.Linq;
using Todo.ViewModel;
using Todo.Models;
using Todo.Helpers;

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ObservableCollection<TasksCategory> _tasksCategory;
        private List<SolidColorBrush> _colors;
        public HistoryPage _historyPage;
        private AuthResponse _authResponse;
        private TodoRepository _todoRepository;

        public ObservableCollection<TaskModel> Tasks { get; set; }
        public List<TodoModel> Todos { get; set; }

        public MainPage(AuthResponse response)
        {
            InitializeComponent();
            _authResponse = response;
            UserNameTextBlock.Text = response.User.Name;
            _todoRepository = new TodoRepository(response.access_token);
            _historyPage = new HistoryPage(response);

            _colors = new List<SolidColorBrush>
            {
                new SolidColorBrush(Colors.Orange),
                new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Blue),
                new SolidColorBrush(Colors.Purple)
            };
            Todos = _todoRepository.GetAllTodos();
            Tasks = InitTasks();
            TasksList.ItemsSource = Tasks;
        }
        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel)TasksList.SelectedItem;
            var result = _todoRepository.DeleteTodo(Todos.Where(todo => todo.Title == task.Title && todo.Description == task.TaskText).Select(todo => todo.Id).FirstOrDefault() ?? "");
            if (result)
                MessageBox.Show("Заметка успешно удалена", "Уведомление об операции", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Заметку не удалось удалить", "Уведомление об операции", MessageBoxButton.OK, MessageBoxImage.Information);
            Tasks.Remove(task);
        }

        private void DoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            var task = (TaskModel)TasksList.SelectedItem;
            var todoId = Todos.Where(todo => todo.Title == task.Title && todo.Description == task.TaskText).Select(todo => todo.Id).FirstOrDefault() ?? "";
            var changedTodo = _todoRepository.MarkTodo(todoId);
            if (changedTodo)
                MessageBox.Show("Заметка успешно изменена", "Уведомление об операции", MessageBoxButton.OK, MessageBoxImage.Information);
            else
                MessageBox.Show("Заметку не удалось изменить", "Уведомление об операции", MessageBoxButton.OK, MessageBoxImage.Information);

            _historyPage.Todos = _todoRepository.GetAllTodos();
            _historyPage.Tasks = _historyPage.InitTasks();
            TaskFullContent.Visibility = Visibility.Hidden;
        }

        private void TasksList_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksList.SelectedItem is TaskModel task)
            {
                TitleTextBlock.Text = task.Title;
                TimeTextBlock.Text = task.TaskDateTime.TimeOfDay.ToString();
                DateTextBlock.Text = task.TaskDateTime.Date.ToString();
                ContentTextBlock.Text = task.TaskText;
                TaskFullContent.Visibility = Visibility.Visible;
            }
            else
                TaskFullContent.Visibility = Visibility.Hidden;
        }
        private ObservableCollection<TaskModel> InitTasks()
        {
            var tasks = new ObservableCollection<TaskModel>();
            if (Todos != null && Todos.Any())
            {
                foreach (var todo in Todos)
                {
                    var taskModel = new TaskModel()
                    {
                        Title = todo.Title,
                        TaskDateTime = DateTime.Now,
                        IsDone = todo.IsCompleted,
                        DisplayTime = todo.Date.ToString(),
                        TaskText = todo.Description,
                    };
                    if (!taskModel.IsDone)
                        taskModel.CheckboxColor = Brushes.White;
                    tasks.Add(taskModel);
                }
            }
            return tasks;
        }
        private void AddTaskButton_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(new AddTaskPage(_authResponse));

        private void HistoryButton_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.Navigate(_historyPage);

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(t => t.Category == "Дом").ToList();
            Tasks = InitTasks();
            TasksList.ItemsSource = Tasks;
        }

        private void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(t => t.Category == "Работа").ToList();
            Tasks = InitTasks();
            TasksList.ItemsSource = Tasks;
        }

        private void StudyButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(t => t.Category == "Учёба").ToList();
            Tasks = InitTasks();
            TasksList.ItemsSource = Tasks;
        }

        private void ChillButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(t => t.Category == "Отдых").ToList();
            Tasks = InitTasks();
            TasksList.ItemsSource = Tasks;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Выход изприложения", MessageBoxButton.YesNo, MessageBoxImage.Question);
             if (result == MessageBoxResult.Yes)
            {
                Manager.MainFrame?.Navigate(new LoginPage());
            }
        }
    }
}
