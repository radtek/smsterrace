using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SmsTerrace.Comm
{
    class NetLink
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionDescription">连接说明</param>
        /// <param name="reservedValue">保留值</param>
        /// <returns></returns>
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connectionDescription, int reservedValue);




        /// <summary>网络是否可用
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
        {

            int I = 0;

            bool state = InternetGetConnectedState(out I, 0);

            return state;

        }

    }


}
