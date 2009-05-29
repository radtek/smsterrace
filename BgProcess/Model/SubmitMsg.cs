using System;
using System.Collections.Generic;
using System.Text;

namespace hz.sms.Model
{
   public class SubmitMsg
    {
       public SubmitMsg() { }
       public SubmitMsg(string msg) { this.message = msg; }
        private String msgId;

        public String MsgId
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
        private int msgType;

        public int MsgType
        {
            get { return msgType; }
            set { msgType = value; }
        }
        private int logFlag;

        public int LogFlag
        {
            get { return logFlag; }
            set { logFlag = value; }
        }
        private String userId;

        public String UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        private int priority;

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
        private String extCode;

        public String ExtCode
        {
            get { return extCode; }
            set { extCode = value; }
        }
        private int sendType;

        public int SendType
        {
            get { return sendType; }
            set { sendType = value; }
        }
        private int businessType;

        public int BusinessType
        {
            get { return businessType; }
            set { businessType = value; }
        }
        private int isstop;

        public int Isstop
        {
            get { return isstop; }
            set { isstop = value; }
        }
        private long seqId;

        public long SeqId
        {
            get { return seqId; }
            set { seqId = value; }
        }
    }
}
