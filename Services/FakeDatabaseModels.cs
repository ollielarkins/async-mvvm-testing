namespace MyWpfApp.Services
{
    public class FakeTable
    {
        public string Name { get; set; }
        public List<string> Columns { get; set; } = new();
        public List<List<string>> Rows { get; set; } = new();
    }

    public class FakeDatabase
    {
        public List<FakeTable> Tables { get; set; } = new();
    }
}