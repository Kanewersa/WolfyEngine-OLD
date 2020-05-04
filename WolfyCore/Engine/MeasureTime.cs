using System;
using System.Diagnostics;

namespace WolfyCore.Engine
{
    public static class MeasureTime
    {
        private static Stopwatch _stopwatch;
        private static string _message;
        
        public static void Start()
        {
            if (_stopwatch != null && _stopwatch.IsRunning)
                throw new Exception("Stopwatch was already running!");
            _stopwatch = Stopwatch.StartNew();
            _message = null;
        }

        public static void Start(string message)
        {
            if (_stopwatch != null && _stopwatch.IsRunning)
                throw new Exception("Stopwatch was already running!");
            _stopwatch = Stopwatch.StartNew();
            _message = message;
        }
        
        public static void Stop()
        {
         _stopwatch.Stop();
         Debug.WriteLine(_message ?? "Stopwatch stopped!");
         Debug.WriteLine("Ms: " + _stopwatch.ElapsedMilliseconds);
         Debug.WriteLine("Ticks: " + _stopwatch.ElapsedTicks);
        }
    }
}