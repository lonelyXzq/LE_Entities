#define ThreadTrack

using System;
using System.Collections.Generic;
using System.Text;



namespace LE_Entities.ThreadTracker
{

    public static class ThreadTracker
    {
        private static readonly WaitTimeLog waitTimeLog = new WaitTimeLog();

        public static void AddTimes(string name)
        {
            waitTimeLog.Add(name);
        }

        public static void OutPut()
        {
            waitTimeLog.Output();
        }
    }
}
