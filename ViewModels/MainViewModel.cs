using CommunityToolkit.Mvvm.ComponentModel;
using MyWpfApp.Services;

namespace MyWpfApp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private object currentView;

        public SidebarViewModel SidebarVM { get; }
        public DashboardViewModel DashboardVM { get; }
        public TablesViewModel TablesVM { get; }
        public QueryViewModel QueryVM { get; }
        public LogsViewModel LogsVM { get; }

        private readonly FakeMySqlService mysql;

        public MainViewModel()
        {
            // Shared fake database service for all viewmodels
            mysql = new FakeMySqlService();

            // Create the VMs
            SidebarVM   = new SidebarViewModel(this);
            DashboardVM = new DashboardViewModel(mysql);
            TablesVM    = new TablesViewModel(mysql);
            QueryVM     = new QueryViewModel(mysql);
            LogsVM      = new LogsViewModel(mysql);

            // Default screen
            CurrentView = DashboardVM;
        }

        public void Navigate(object newView)
        {
            CurrentView = newView;
        }
    }
}
