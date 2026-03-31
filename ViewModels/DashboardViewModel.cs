using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MyWpfApp.Services;
using System.Windows.Input;

namespace MyWpfApp.ViewModels
{
    public partial class DashboardViewModel : ObservableObject
    {
        [ObservableProperty] private int tapCount;
        [ObservableProperty] private double progressPercent;
        [ObservableProperty] private string statusText = "Idle";
        [ObservableProperty] private string etaText = "";
        [ObservableProperty] private string debugText = "debug: ready";

        public AsyncRelayCommand RunAsyncCommand { get; }

        private readonly Random rnd = new();
        private readonly FakeMySqlService db;

        public DashboardViewModel(FakeMySqlService db)
        {
            this.db = db;
            RunAsyncCommand = new AsyncRelayCommand(RunAsync);
        }

        // TEST UI RESPONSIVENESS
        [RelayCommand]
        public void IncreaseTap()
        {
            TapCount++;
        }

        [RelayCommand]
        public void DecreaseTap()
        {
            TapCount--;
        }

        // RESET EVERYTHING EVERY TIME
        private void ResetUI()
        {
            ProgressPercent = 0;
            StatusText = "idle";
            EtaText = "";
        }

        // -------------------------
        // BLOCKING TASK
        // -------------------------
        [RelayCommand]
        public void RunBlocking()
        {
            ResetUI();
            StatusText = "running sync task…";

            for (int i = 0; i <= 100; i++)
            {
                Thread.Sleep(30); // UI freeze intentionally
                ProgressPercent = i;
            }

            StatusText = "sync task done";
            EtaText = "";
        }

        // -------------------------
        // ASYNC TASK
        // -------------------------
        public async Task RunAsync()
        {
            DebugText = "debug: async started";
            ResetUI();
            StatusText = "running async task…";

            var stopwatch = Stopwatch.StartNew();

            while (ProgressPercent < 100)
            {
                // Random progress increment (1-15%)
                int increment = rnd.Next(1, 16);
                // Random delay (50-800ms)
                int delay = rnd.Next(50, 801);
                
                await Task.Delay(delay);
                
                ProgressPercent = Math.Min(100, ProgressPercent + increment);
                DebugText = $"debug: progress {ProgressPercent:F0}% (+{increment}%)";

                // Calculate ETA
                double elapsedSeconds = stopwatch.Elapsed.TotalSeconds;
                if (ProgressPercent > 0)
                {
                    double totalEstimatedSeconds = elapsedSeconds / (ProgressPercent / 100.0);
                    double remainingSeconds = totalEstimatedSeconds - elapsedSeconds;
                    EtaText = $"{remainingSeconds:F1}s left";
                }

                // Occasionally add a longer pause (10% chance)
                if (rnd.Next(10) == 0)
                {
                    await Task.Delay(rnd.Next(500, 1501)); // 500-1500ms pause
                    DebugText = $"debug: pausing at {ProgressPercent:F0}%";
                }
            }

            StatusText = "async done";
            EtaText = "";
            DebugText = "debug: async finished";
        }

        [RelayCommand]
        public void Reset()
        {
            ResetUI();
        }
    }
}