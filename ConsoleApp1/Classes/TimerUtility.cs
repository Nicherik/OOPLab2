using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    public static class TimerUtility
    {

        public static Stopwatch StartTimer() => Stopwatch.StartNew();

        public static long GetElapsedMilliseconds(Stopwatch stopwatch)
        {
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

    }
}
