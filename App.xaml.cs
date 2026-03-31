using System;
using System.Windows;

namespace MyWpfApp
{
    public partial class App : Application
    {
        public App()
        {
            this.DispatcherUnhandledException += (s, e) =>
            {
                MessageBox.Show(
                    e.Exception.ToString(),
                    "WPF Startup Exception"
                );
                e.Handled = true;
            };
        }
    }
}