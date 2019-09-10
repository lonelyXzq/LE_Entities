using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.ThreadTracker
{
    class WaitTimeLog
    {
        private readonly Dictionary<string, int> times;
        public WaitTimeLog()
        {
            times = new Dictionary<string, int>();
        }

        public void Add(string name)
        {
            if (times.ContainsKey(name))
            {
                times[name]++;
            }
            else
            {
                times.Add(name, 1);
            }
        }

        public void Output()
        {
            foreach (var item in times)
            {
                Console.WriteLine("{0}:{1}", item.Key, item.Value);
            }
        }
    }
}
