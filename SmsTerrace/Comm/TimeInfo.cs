using System;
using System.Collections.Generic;
using System.Text;

namespace hz.sms.Comm
{
    class TimeInfo
    {
       static public long getNowUnixTicks()
        {
            DateTime DateTime1970 = new DateTime(1970, 1, 1);
            TimeSpan t = DateTime.UtcNow - DateTime1970;
            long i = (int)t.TotalSeconds;
            return i;
           //DateTime timeStamp=new DateTime(1970,1,1);  //得到1970年的时间戳
           //long a = (DateTime.UtcNow.Ticks - timeStamp.Ticks);
           //return a;          
        }
    }
}
