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
using Todo.View;
using System.Windows.Media.Animation;
using Todo.Helpers;

namespace Todo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowFrame.Navigate(new LoginPage());
            Manager.MainFrame = MainWindowFrame;

            DoubleAnimation frameAnimation = new();
            frameAnimation.From = 0;
            frameAnimation.To = Width;
            frameAnimation.Duration = TimeSpan.FromSeconds(3);
            BeginAnimation(WidthProperty, frameAnimation);
        }
    }
}
