using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LE_Entities.IdManager
{
    public static class IdDeliverer<T>
    {
        private static volatile int id = -1;

        public static int GetNextId()
        {
            return Interlocked.Increment(ref id);
        }
    }
}
