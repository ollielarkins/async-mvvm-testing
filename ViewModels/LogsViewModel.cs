using CommunityToolkit.Mvvm.ComponentModel;
using MyWpfApp.Services;
using System.Collections.ObjectModel;

namespace MyWpfApp.ViewModels
{
    public partial class LogsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> logs;

        public LogsViewModel(FakeMySqlService db)
        {
            logs = new ObservableCollection<string>(db.Logs);
        }
    }
}
