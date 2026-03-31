using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using MyWpfApp.Services;

namespace MyWpfApp.ViewModels
{
    public partial class TablesViewModel : ObservableObject
    {
        private readonly FakeMySqlService mysql;

        [ObservableProperty]
        private ObservableCollection<string> tables;

        [ObservableProperty]
        private string selectedTable;

        public TablesViewModel(FakeMySqlService mysql)
        {
            this.mysql = mysql;
            tables = new ObservableCollection<string>();

            foreach (var t in mysql.Database.Tables)
                tables.Add(t.Name);
        }
    }
}
