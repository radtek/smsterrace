using System;
using System.Collections.Generic;
using System.Text;

namespace hz.sms.Model
{
   public class Report
    {
        private string msgId;

        public string MsgId
        {
            get { return msgId; }
            set { msgId = value; }
        }

       
        private String mobileId;

        public String MobileId
        {
            get { return mobileId; }
            set { mobileId = value; }
        }
        private String message;

        public String Message
        {
            get { return message; }
            set { message = value; }
        }
        private long seqId;

        public long SeqId
        {
            get { return seqId; }
            set { seqId = value; }
        }
        private int stateCode;

        public int StateCode
        {
            get { return stateCode; }
            set { stateCode = value; }
        }
        private String processDate;

        public String ProcessDate
        {
            get { return processDate; }
            set { processDate = value; }
        }
    }
}
