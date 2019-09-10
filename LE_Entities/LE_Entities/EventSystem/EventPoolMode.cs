using System;
using System.Collections.Generic;
using System.Text;

namespace LE_Entities.EventSystem
{
    public enum EventPoolMode
    {
        /// <summary>
        /// 只可被订阅一次
        /// </summary>
        Single,
        /// <summary>
        /// 可多次订阅
        /// </summary>
        Multiple,
    }
}
