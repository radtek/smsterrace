using System;
using System.Collections.Generic;
using System.Text;
using log4net;
using System.Collections;
using hz.sms.Model;
using hz.sms.DAL;
using hz.sms.Comm;

namespace hz.sms.BLL
{
    public class SmsSendSession : hz.sms.IBLL.IExRequest, hz.sms.BLL.ISmsSendSession
    {
        public readonly string channelId = InitInfo.CHANNEL_NUM;
        public readonly int bringCount = InitInfo.MAX_COUNT;
        public readonly int timerEventCount = InitInfo.TIMER_EVENT_COUNT;

        public SmsSendSession() { }
        //static SmsSendSession smsSendSession;
        //public static SmsSendSession CreateInstance()
        //{
        //    if (smsSendSession == null)
        //    {
        //        smsSendSession = new SmsSendSession();            
        //    }
        //  return smsSendSession;
        //}
        public static readonly ILog log = LogManager.GetLogger("ManageLog");
      public   string URL_FRIST;
      public   string URL_FOOT;
        string[] sendParam;

        int threadNum;
        /// <summary>并发线程计数
        /// 
        /// </summary>
        public int ThreadNum
        {
            get { return threadNum; }
        }

        int UpdateThreadNum(int j)
        {
            lock (this)
            {
                threadNum = threadNum + j;
                return threadNum;
            }
        }


        public void LoopSend()
        {

            if (ThreadNum > timerEventCount)
            {
                Console.WriteLine("并发线程数：" + ThreadNum + "返回!");
                return;
            }
            try
            {
                UpdateThreadNum(1);
                SendData();
            }
            catch (Exception ex)
            {
                log.Error("LoopSend异常:", ex);
            }
            finally
            {
                UpdateThreadNum(-1);
            }
        }

        #region IExRequest 成员






        public string[] SendParam
        {
            get
            {
                return sendParam;
            }
            set
            {
                sendParam = value;
            }
        }


        public event EventSession SendBegin = delegate(object obj, SmsSessionInfo e) { return 0; };
        public event EventSession SendEnd = delegate(object obj, SmsSessionInfo e) { return 0; };
        public event EventSession DealWithBegin = delegate(object obj, SmsSessionInfo e) { return 0; };
        public event EventSession DealWithEnd = delegate(object obj, SmsSessionInfo e) { return 0; };
        public event EventSessionError SessionError = delegate(object obj, SmsSessionInfo e, object[] exInfo) { return 0; };

        SubmitMsgService sm = new SubmitMsgService();
        public virtual void  SendData()
        {

            List<SubmitMsg> list = sm.GetMsgList(90, channelId);
            
            Dictionary<string, List<SubmitMsg>> map = BaseSmsManage.GetMsgGroup(list);
            Console.WriteLine("["+DateTime.Now+"]\t获取信息"+map.Count+"组,共"+list.Count);
            foreach (KeyValuePair<string, List<SubmitMsg>> kv in map)
            {
                SmsSessionInfo ssInfo = null;
                try
                {
                    ssInfo = GenerateInfo(kv.Value);
                    SendSms(ssInfo);
                    ResultDealWith(ssInfo);
                }
                catch (Exception ex)
                {
                    log.Error("SendData发送", ex);
                    SessionError(this, ssInfo, "SendData", ex);
                }
            }
        }

        public SmsSessionInfo GenerateInfo(List<SubmitMsg> smsgList)
        {
            try
            {
                SmsSessionInfo smsSessionInfo = new SmsSessionInfo();
                smsSessionInfo.SubmitMsgInstance = smsgList[0];
                smsSessionInfo.Mobiles = BaseSmsManage.ExtractPhone(smsgList).ToArray();
                smsSessionInfo.RequestUrl = CreateUrl(smsSessionInfo);
                return smsSessionInfo;
            }
            catch (Exception ex)
            {
                log.Error("GenerateInfo:", ex);
                throw ex;
            }
        }

        public string SendSms(SmsSessionInfo smsSessionInfo)
        {
            try
            {
                SendBegin(this, smsSessionInfo);
                string responesResult = BaseSmsManage.SendPostRequestByUrl(smsSessionInfo.RequestUrl);
                smsSessionInfo.ResponesResult = responesResult;
                SendEnd(this, smsSessionInfo);
                return responesResult;
            }
            catch (Exception ex)
            {
                log.Error("SendSms:" + hz.sms.Comm.ObjManage.ObjToString(smsSessionInfo), ex);
                throw ex;
            }
        }

        public virtual string CreateUrl(SmsSessionInfo smsSessionInfo)
        {
            string str = BaseSmsManage.PhoneNumTogether(smsSessionInfo.Mobiles);
            string s = "&MOBILE=" + str + "&CONTENT=" + smsSessionInfo.SubmitMsgInstance.Message;
            string url = URL_FRIST + s + URL_FOOT;
            return url;
        }
        public virtual void ResultDealWith(SmsSessionInfo smsSessionInfo)
        {
            try
            {
                DealWithBegin(this, smsSessionInfo);
                ResultToReportSubmit(smsSessionInfo);
                DealWithEnd(this, smsSessionInfo);
            }
            catch (Exception ex)
            {
                log.Error("ResultDealWith:" + hz.sms.Comm.ObjManage.ObjToString(smsSessionInfo), ex);
                throw ex;
            }
        }

        #endregion

        public virtual int RstrToState(string str)
        {
            int i = -1;
            try
            {
                switch (str.Trim())
                {
                    case "OK": i = 0;
                        break;
                    case "ERROR": i = 1;
                        break;
                    default: i = 1;
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Error("RstrToState获取发送状态错误", ex);
            }
            return i;
        }
        public virtual string RstrToDesc(string str)
        {
            string s = "";
            try
            {
                switch (str.Trim())
                {
                    case "0": s = "发送成功";
                        break;
                    case "-1": s = "发送失败";
                        break;
                    default: s = str;
                        break;
                }
            }
            catch (Exception ex)
            {
                log.Error("RstrToDesc获取发送状态描述", ex);
            }
            return s;
        }

        public List<ReportSubmit>
            ResultToReportSubmit(SmsSessionInfo smsSessionInfo)
        {
            List<ReportSubmit> list = new List<ReportSubmit>();
            ReportSubmitServeic rS = new ReportSubmitServeic();
            int state = RstrToState(smsSessionInfo.ResponesResult);
            string desc = RstrToDesc(smsSessionInfo.ResponesResult);
            foreach (string phone in smsSessionInfo.Mobiles)
            {
                try
                {
                    ReportSubmit rs = new ReportSubmit();
                    rs.channelId = Convert.ToInt32(channelId);
                    rs.mobileId = phone;
                    rs.state = state;
                    rs.stateDesc = desc;
                    rs.msgId = smsSessionInfo.SubmitMsgInstance.MsgId;
                    rs.seqid = smsSessionInfo.SubmitMsgInstance.SeqId + "";
                    list.Add(rs);
                    rS.Add(rs);
                }
                catch (Exception ex)
                {
                    log.Error("ResultToReportSubmit", ex);
                    SessionError(this, smsSessionInfo, "ResultToReportSubmit", ex);

                }
            }
            return list;
        }
    }
}
