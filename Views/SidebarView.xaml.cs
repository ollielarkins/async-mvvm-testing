using System.Windows.Controls;
using MyWpfApp.ViewModels;

namespace MyWpfApp.Views
{
    public partial class SidebarView : UserControl
    {
        public SidebarView()
        {
            InitializeComponent();

            // SAFE: Delay binding until the view is loaded
            Loaded += SidebarView_Loaded;
        }

        private void SidebarView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (App.Current.MainWindow is not null &&
                App.Current.MainWindow.DataContext is MainViewModel main)
            {
                DataContext = main.SidebarVM;
            }
        }
    }
}