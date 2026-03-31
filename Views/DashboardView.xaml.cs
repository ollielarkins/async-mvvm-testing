using System.Windows.Controls;
using System.Windows.Input;
using MyWpfApp.ViewModels;

namespace MyWpfApp.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void OnRightClick(object sender, MouseButtonEventArgs e)
        {
            if (DataContext is DashboardViewModel vm)
            {
                vm.DecreaseTapCommand.Execute(null);
            }
            e.Handled = true;
        }
    }
}