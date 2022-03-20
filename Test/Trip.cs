using System;
using System.Collections.Generic;
using System.Threading;

namespace Test
{
    public class Trip
    {
        public string Name { get; }
        public float Priority { get; }
        public double Time { get; }

        public double Kpi { get; }

        public Trip(string name, float priority, double time)
        {
            Name = name;
            Priority = priority;
            Time = time;
            Kpi = Priority * Time;
        }
    }
}