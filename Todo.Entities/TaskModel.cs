using System.Windows.Media;

namespace Todo.Entities
{
    public class TaskModel
    {
        public DateTime TaskDateTime { get; set; }

        public string? Title { get; set; }

        public bool IsDone { get; set; }

        public string? TaskText { get; set; }

        public SolidColorBrush? CheckboxColor { get; set; }

        public string? DisplayTime { get; set; }
    }
}
