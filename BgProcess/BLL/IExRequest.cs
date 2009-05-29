using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections;
using hz.sms.Model;
using hz.sms.BLL;

namespace hz.sms.IBLL
{
  public  interface IExRequest
    {
      

        string[] SendParam{get;set;}
       

      event EventSession SendBegin;
      event EventSession SendEnd;
      event EventSession DealWithBegin;
      event EventSession DealWithEnd;
      string SendSms(SmsSessionInfo smsSessionInfo);
      void ResultDealWith(SmsSessionInfo smsSessionInfo);
    }
}
