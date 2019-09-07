using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LE_Entities.Template
{
    public static class TemplateIdManager
    {
        private static readonly Dictionary<string, long> ids;
        private static readonly Dictionary<string, int> bases;
        private static int id;
        private static int bid;

        static TemplateIdManager()
        {
            ids = new Dictionary<string, long>();
            bases = new Dictionary<string, int>();
        }

        public static void Init()
        {

        }

        public static void RegiserBase<Tb>()
        {
            bases.Add(typeof(Tb).FullName, bid);
            bid++;
        }

        public static void Register<Tb>(Type ac)
        {
            if (bases.TryGetValue(typeof(Tb).FullName, out int _bid))
            {
                ids.Add(ac.FullName, (((long)_bid) << 32) + id);
                id++;
            }
        }

        public static long GetId<Ac>()
        {
            if (ids.TryGetValue(typeof(Ac).FullName, out long id))
            {
                return id;
            }
            //
            LE_Log.Log.Error("Template id error", "type: {0} is not a templateType", typeof(Ac).FullName);
            return -1;
        }

        public static int GetBaseId<Ac>()
        {
            return (int)(GetId<Ac>() >> 32);
        }

        public static int GetLocalId<Ac>()
        {
            return (int)(GetId<Ac>());
        }
    }
}
