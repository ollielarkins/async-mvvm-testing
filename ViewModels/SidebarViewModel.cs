using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyWpfApp.ViewModels
{
    public partial class SidebarViewModel : ObservableObject
    {
        private readonly MainViewModel root;

        public SidebarViewModel(MainViewModel root)
        {
            this.root = root;
        }

        // Navigation command (button click → navigate)
        [RelayCommand]
        private void Navigate(string target)
        {
            root.Navigate(target switch
            {
                "Dashboard" => root.DashboardVM,
                "Tables"    => root.TablesVM,
                "Query"     => root.QueryVM,
                "Logs"      => root.LogsVM,

                _ => root.DashboardVM
            });
        }
    }
}


