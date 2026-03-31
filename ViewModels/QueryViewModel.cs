using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Linq;
using MyWpfApp.Services;

namespace MyWpfApp.ViewModels
{
    public partial class QueryViewModel : ObservableObject
    {
        private readonly FakeMySqlService db;

        [ObservableProperty]
        private string queryText = "SELECT * FROM random_table;";

        [ObservableProperty]
        public ObservableCollection<string> queryResults = new();

        public QueryViewModel(FakeMySqlService db)
        {
            this.db = db;
        }

        [RelayCommand]
        private void RunQuery()
        {
            queryResults.Clear();

            // Pick a random table
            var table = db.Database.Tables.ElementAtOrDefault(
                new System.Random().Next(db.Database.Tables.Count));

            if (table == null)
            {
                queryResults.Add("no.");
                return;
            }

            // Display table info
            queryResults.Add($"selected: {table.Name}");
            queryResults.Add("columns: " + string.Join(", ", table.Columns));

            // Show sample rows (first 10)
            foreach (var row in table.Rows.Take(10))
                queryResults.Add(string.Join(" | ", row));
        }
    }
}