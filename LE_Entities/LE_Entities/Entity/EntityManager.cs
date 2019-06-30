using LE_Entities.Tool;
using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.Entity
{
    public static class EntityManager
    {
        private static readonly DataChain<Entity> dataChain;

        internal static DataChain<Entity> DataChain => dataChain;
    }
}
