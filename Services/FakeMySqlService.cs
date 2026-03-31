using System;
using System.Collections.Generic;

namespace MyWpfApp.Services
{
    public class FakeMySqlService
    {
        public FakeDatabase Database { get; private set; }
        public List<string> Logs { get; private set; } = new();

        private readonly Random rnd = new();

        public FakeMySqlService()
        {
            GenerateFakeDatabase();
        }

        public void GenerateFakeDatabase()
        {
            Database = new FakeDatabase();

            int tableCount = rnd.Next(5, 12);

            for (int t = 0; t < tableCount; t++)
            {
                var table = new FakeTable
                {
                    Name = $"tbl_{RandomWord()}",
                    Columns = new(),
                    Rows = new()
                };

                int colCount = rnd.Next(3, 8);
                for (int c = 0; c < colCount; c++)
                    table.Columns.Add($"col_{RandomWord()}");

                int rowCount = rnd.Next(10, 50);
                for (int r = 0; r < rowCount; r++)
                {
                    List<string> row = new();
                    foreach (var col in table.Columns)
                        row.Add(RandomWord());
                    table.Rows.Add(row);
                }

                Database.Tables.Add(table);
            }
        }

        private string RandomWord()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[]{};:,.<>? ";
            int len = rnd.Next(4, 8);

            char[] buffer = new char[len];
            for (int i = 0; i < len; i++)
                buffer[i] = chars[rnd.Next(chars.Length)];

            return new string(buffer);
        }
    }
}