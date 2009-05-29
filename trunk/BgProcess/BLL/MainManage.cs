using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using hz.sms.Comm;
using log4net;
using hz.sms.Model;

namespace hz.sms.BLL
{
    public class MainManage
    {
        readonly string channelNum = InitInfo.CHANNEL_NUM;
        public static readonly log4net.ILog log = LogManager.GetLogger("ManageLog");
        protected static Timer tim = new Timer();
        public MainManage(){
            this.InitTimer();
        }
        public MainManage(ISmsSendSession sendMsg,ISmsSendSession query,params string[] param)
        {   
            this.sendMsg = sendMsg;
            this.query = query;
            this.InitTimer();
            param = MainCmd( param);
        }

        public string[] MainCmd(string[] param)
        {
            
            
            be: while (true)
            {
                if (param == null || param.Length < 1)
                {
                    Console.Write("SMS>");
                    param = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    continue;
                }
                if (param[0].Equals(@"/begin"))
                {
                    param = null;
                    break;
                }
                if (param[0].Equals(@"/query"))
                {
                    param = null;
                    if (query != null)
                    {
                        query.LoopSend();
                    }
                    else
                    {
                        log.Warn("未发现接收回复方法，不能进行获取回复！");
                    }
                    continue;
                }
                param = null;
            }
            startTimer();
            while (true)
            {
                Console.ReadLine();
                stopTimer();
                goto be;
            }
            return param;
        }

        /// <summary>获取回复
        /// 
        /// </summary>
        ISmsSendSession query;//= new SmsSendSession();

        public ISmsSendSession Query
        {
            get { return query; }
            set { query = value; }
        }
        ISmsSendSession sendMsg;// = new SmsSendSession();
        /// <summary>发送
        /// 
        /// </summary>
        public ISmsSendSession SendMsg
        {
            get { return sendMsg; }
            set { sendMsg = value; }
        }

       protected virtual void InitTimer()
        {
            tim.Interval = InitInfo.SCANNING_INTERVAL;       
            tim.Elapsed += new ElapsedEventHandler(tim_Elapsed);
            tim.Elapsed +=new ElapsedEventHandler(tim_Elapsed1);
            tim.Elapsed += new ElapsedEventHandler(tim_Elapsed2);
        }
      public  void startTimer()
        {
            tim.Enabled = true;
            tim.Start();
            log.Info("\r\n   --- 启动定时器Start ---");
        }
        public void stopTimer()
        {
            tim.Stop();
            tim.Enabled = false;
            log.Info("\r\n   ----- 定时扫描器已Stop！！！-----");
        }
     public   void tim_Elapsed(object sender, ElapsedEventArgs e)
        {
            SystemMonitor();
            return;
        }
     public   void tim_Elapsed1(object sender, ElapsedEventArgs e)
        {
            sendMsg.LoopSend();
            return;
        }
      public  void tim_Elapsed2(object sender, ElapsedEventArgs e)
        {
            query.LoopSend();
            return;
        }
        static DateTime timePosition = DateTime.Now;
        /// <summary>短信监视运行状态
        /// 
        /// </summary>
        /// <returns>是否发送了状态</returns>
        bool SystemMonitor()
        {
            lock (this)
            {
                try
                {
                    if (monitorArray != null )
                    { 
                        DateTime dTime = DateTime.Now;
                        if (dTime.Hour > 8 && dTime.Hour < 18)
                        {
                            if ((dTime.Minute == 10 || dTime.Minute == 40) && dTime > timePosition)
                            {
                                timePosition = dTime.AddMinutes(10);
                               // SendProcessing sendB = new SendProcessing();
                                SmsSessionInfo ssi = new SmsSessionInfo();
                                ssi.Mobiles = monitorArray;
                                string msg="[" + DateTime.Now + "]运行情况报告：" + channelNum + "通道";
                                SubmitMsg smsg= new SubmitMsg(msg);
                                smsg.ExtCode="444444";
                                ssi.SubmitMsgInstance =smsg; 
                                ssi.RequestUrl = sendMsg.CreateUrl(ssi);
                                sendMsg.SendSms(ssi);
                                
                                Console.WriteLine("下次timePosition：" + timePosition);
                            }
                        }
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e1)
                {
                    log.Error("发送监控信息出错", e1);
                    return false;
                }
            }
        }
        public string[] monitorArray = GetMonitorArray();
        public static string[] GetMonitorArray()
        {
            string phoneNum = InitInfo.MONITOR_PHOTO.Trim();
            if (phoneNum != null && phoneNum.Trim().Length > 0)
            {
                string[] phoneArray = phoneNum.Split(new string[] { ",", ";", "|" }, StringSplitOptions.RemoveEmptyEntries);
                if (phoneArray.Length>0)
                {
                    return phoneArray;
                }   
            }
            return null;
        }
    }
}
