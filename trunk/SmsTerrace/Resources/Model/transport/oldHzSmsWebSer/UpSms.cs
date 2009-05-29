using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.Model;


namespace SmsTerrace.Model.transport.oldHzSmsWebSer
{
    class UpSms
    {
        public SmsTerrace.SmsWebService.UpSms originalUpSms;
        public UpSms(SmsTerrace.SmsWebService.UpSms baseUpSms)
        {
            this.originalUpSms = baseUpSms;
        }

      
    }
}
