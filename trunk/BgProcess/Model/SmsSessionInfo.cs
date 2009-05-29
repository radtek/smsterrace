using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.Model;
using System.Collections;

namespace hz.sms.Model
{
   public class SmsSessionInfo
    {
        ReportSubmit[] reportSubmit;

        public ReportSubmit[] ReportSubmit
        {
            get { return reportSubmit; }
            set { reportSubmit = value; }
        }
        SubmitMsg submitMsgInstance;

        public SubmitMsg SubmitMsgInstance
        {
            get { return submitMsgInstance; }
            set { submitMsgInstance = value; }
        }
        string[] mobiles;

        public string[] Mobiles
        {
            get { return mobiles; }
            set { mobiles = value; }
        }
        string responesResult;

        public string ResponesResult
        {
            get { return responesResult; }
            set { responesResult = value; }
        }
        string requestUrl;

        public string RequestUrl
        {
            get { return requestUrl; }
            set { requestUrl = value; }
        }
        Hashtable sessionInfo;

        public Hashtable SessionInfo
        {
            get { return sessionInfo; }
            set { sessionInfo = value; }
        }
    }
}
