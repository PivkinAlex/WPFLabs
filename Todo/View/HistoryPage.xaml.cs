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
using Todo.XXX;
using System.Collections.ObjectModel;
using Todo.Repository;
using Todo.Responses;

namespace Todo.View
{
    /// <summary>
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        private readonly ObservableCollection<TasksCategory> _tasksCategory;
        private readonly List<SolidColorBrush> _colors;
        public ObservableCollection<TaskModel> Tasks;
        private TodoRepository _todoRepository;
        public List<TodoModel> Todos { get; set; }
        public HistoryPage(AuthResponse authResponse)
        {
            Tasks = new();
            InitializeComponent();
            UserNameTextBlock.Text = authResponse.User.Name;
            _todoRepository = new TodoRepository(authResponse.access_token);

            _colors = new List<SolidColorBrush>
            {
                new SolidColorBrush(Colors.Orange),
                new SolidColorBrush(Colors.Green),
                new SolidColorBrush(Colors.Blue),
                new SolidColorBrush(Colors.Purple)
            };
            Todos = _todoRepository.GetAllTodos().Where(todo => todo.IsCompleted == true).ToList();
            var tasksList = InitTasks();
            Tasks = new ObservableCollection<TaskModel>(tasksList);
            TasksList.ItemsSource = Tasks;
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
        public ObservableCollection<TaskModel> InitTasks()
        {
            var tasks = new ObservableCollection<TaskModel>();
            if (Todos != null && Todos.Any())
            {
                foreach (var todo in Todos)
                {
                    var taskModel = new TaskModel()
                    {
                        Title = todo.Title,
                        TaskDateTime = DateTimeOffset.FromUnixTimeSeconds(todo.Date).UtcDateTime,
                        IsDone = todo.IsCompleted,
                        DisplayTime = todo.Date.ToString(),
                        TaskText = todo.Description,
                    };
                    taskModel.CheckboxColor = Brushes.White;
                    tasks.Add(taskModel);
                }
            }
            return tasks;
        }
        private void TasksButton_Click(object sender, RoutedEventArgs e) => Manager.MainFrame?.GoBack();

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(todo => todo.IsCompleted == true && todo.Category == "Дом").ToList();
            var tasksList = InitTasks();
            Tasks = new ObservableCollection<TaskModel>(tasksList);
            TasksList.ItemsSource = Tasks;
        }

        private void WorkButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(todo => todo.IsCompleted == true && todo.Category == "Работа").ToList();
            var tasksList = InitTasks();
            Tasks = new ObservableCollection<TaskModel>(tasksList);
            TasksList.ItemsSource = Tasks;
        }

        private void StudyButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(todo => todo.IsCompleted == true && todo.Category == "Учёба").ToList();
            var tasksList = InitTasks();
            Tasks = new ObservableCollection<TaskModel>(tasksList);
            TasksList.ItemsSource = Tasks;
        }

        private void ChillButton_Click(object sender, RoutedEventArgs e)
        {
            Todos = _todoRepository.GetAllTodos().Where(todo => todo.IsCompleted == true && todo.Category == "Отдых").ToList();
            var tasksList = InitTasks();
            Tasks = new ObservableCollection<TaskModel>(tasksList);
            TasksList.ItemsSource = Tasks;
        }
    }
}
