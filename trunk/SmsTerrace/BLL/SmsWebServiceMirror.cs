using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.Model;
using SmsTerrace.IBLL;
using SmsTerrace.Model;
using SmsTerrace.SmsWebService;

namespace SmsTerrace.BLL
{
    [System.Diagnostics.DebuggerStepThrough(), System.ComponentModel.DesignerCategory("code"),

   System.Web.Services.WebServiceBinding(Name = "", Namespace = "")]

    class SmsWebServiceMirror : SmsWebService.Service, IConvertToNorm, ISmsWebServiceMirror
    {

        public SmsWebServiceMirror()
            : base()
        {
            this.Timeout = 30000;
           // this.Url = "http://218.241.155.67:8011/Service.asmx";
        }
        public SmsWebServiceMirror(string serviceUrl)
            : base()
        {
            this.Timeout = 30000;
            this.Url = serviceUrl; 
        }

        public static MoPendingDeal UpSmsToMoPendingDeal(object upSms)
        {
            if (upSms is UpSms)
            {       
                UpSms TempUpSms = upSms as UpSms;
                MoPendingDeal moPendingDeal = new MoPendingDeal(null, TempUpSms.SubNumber, TempUpSms.SrcTerminalID, null, TempUpSms.MsgContent, DateTime.Parse(TempUpSms.UpTime));
                return moPendingDeal;
            }
            else
            {
                return null;
            }
        }
    



        #region IConvertToNorm 成员

        public  MoPendingDeal ConvertToMoPendingDeal(object upSms)
        {
            return UpSmsToMoPendingDeal(upSms);    
        }

        public 接收记录 ConvertTo接收记录(object upSms)
        {
            if (upSms is UpSms)
            {
                UpSms TempUpSms = upSms as UpSms;
                接收记录 moInfo = new 接收记录();
                moInfo.发送人 = TempUpSms.SrcTerminalID;
                moInfo.内容 = TempUpSms.MsgContent;
                moInfo.时间 = TempUpSms.UpTime;
                moInfo.备注 ="子号码"+ TempUpSms.SubNumber;
                return moInfo;
            }
            else
            {
                return null;
            }
        }

        #endregion

       public string ConvertToStatus(string desc)
       {
           switch (desc)
           {
               case "0":
                   return "发送成功";
               case "1":
                   return "发送失败";
               default:
                   return "发送失败";
           }
       }
    }
}
