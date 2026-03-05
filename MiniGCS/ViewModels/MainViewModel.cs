using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using MiniGCS.Models; // Drone sınıfımızı kullanmak için

namespace MiniGCS.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private Drone _activeDrone;
        private DispatcherTimer _timer;

        // Ekrana yansıyacak veriler (Data Binding için)
        public string SpeedDisplay => $"{_activeDrone.Speed} km/s";
        public string AltitudeDisplay => $"{_activeDrone.Altitude} m";
        public string BatteryDisplay => $"% {_activeDrone.BatteryLevel}";

        public MainViewModel()
        {
            _activeDrone = new Drone { IsConnected = true };

            // Her 1 saniyede bir veriyi güncelle
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (s, e) =>
            {
                _activeDrone.SimulateTelemetry();

                // Arayüze "Değerler değişti, rakamları yenile!" diyoruz
                OnPropertyChanged(nameof(SpeedDisplay));
                OnPropertyChanged(nameof(AltitudeDisplay));
                OnPropertyChanged(nameof(BatteryDisplay));
            };
            _timer.Start();
        }

        // --- WPF'in standart haberleşme kodu (Değişmez Kalıptır) ---
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}