using System.Windows;
using MyWpfApp.ViewModels;

namespace MyWpfApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}