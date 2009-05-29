using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.Model;

namespace SmsTerrace.IBLL
{
     interface IConvertToNorm
    {
        MoPendingDeal ConvertToMoPendingDeal(object upSms);
    }
}
