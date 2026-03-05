using System;

namespace MiniGCS.Models
{
    public class Drone
    {
        // Özellikler (Properties): Uçağın anlık durum verileri
        public double Speed { get; set; }      // Hız (km/s)
        public double Altitude { get; set; }   // İrtifa (metre)
        public int BatteryLevel { get; set; }  // Batarya Seviyesi (%)
        public bool IsConnected { get; set; }  // Yer istasyonu ile bağlantı durumu

        // Yapıcı Metot (Constructor): Drone nesnesi ilk oluşturulduğundaki varsayılan değerler
        public Drone()
        {
            Speed = 0.0;
            Altitude = 0.0;
            BatteryLevel = 100;
            IsConnected = false;
        }

        // Davranış (Method): Uçuş simülasyonu - Verileri dinamik olarak günceller
        public void SimulateTelemetry()
        {
            if (!IsConnected) return; // Bağlantı yoksa veri üretme

            Random rnd = new Random();

            // Hızı ve irtifayı gerçekçi görünmesi için rastgele değiştiriyoruz
            Speed = rnd.Next(80, 150);       // 80 ile 150 km/s arası
            Altitude = rnd.Next(400, 1200);  // 400 ile 1200 metre arası

            // Her veri geldiğinde batarya biraz azalsın
            if (BatteryLevel > 0)
            {
                // Rastgele zamanlarda bataryayı %1 düşür
                if (rnd.Next(0, 5) == 1)
                    BatteryLevel -= 1;
            }
        }
    }
}