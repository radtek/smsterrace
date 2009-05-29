using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using log4net;
using hz.sms.IBLL;
using hz.sms.DAL;
using hz.sms.Model;

namespace hz.sms.BLL
{
    public delegate int EventSession(object sender,SmsSessionInfo e);
    public delegate int EventSessionError(object sender,SmsSessionInfo e,params object[] exInfo);  

   static public class BaseSmsManage
    {
       public static readonly ILog log = LogManager.GetLogger("ManageLog");

      public static void CircleEx(IExRequest req)
       {
           if (ThreadNum>0)
           {
               return;
           }
           try
           {
               UpdateThreadNum(1);
               //req.SendSms();
           }
           catch (Exception ex)
           {
               log.Error("CircleEx异常:",ex);
           }
           finally {
               UpdateThreadNum(-1);
           }
       }



      

       /// <summary>
       /// 按msgId获取数据并分组
       /// </summary>
       /// <returns>分组后的键值</returns>
       static public Dictionary<string, List<SubmitMsg>> GetMsgGroup(List<SubmitMsg> msgList)
       {
           try
           {
               Dictionary<string, List<SubmitMsg>> ht = new Dictionary<string, List<SubmitMsg>>();
               int msgCount = 0;    //消息个数
               foreach (SubmitMsg msg in msgList)
               {
                   string msgId = msg.MsgId;
                   if (!ht.ContainsKey(msgId))  //如果没有此匹消息，就新创建
                   {
                       List<SubmitMsg> listRow = new List<SubmitMsg>();
                       listRow.Add(msg);
                       ht.Add(msgId, listRow);
                   }
                   else     //如果已有此匹消息，就向这匹消息添加
                   {
                       List<SubmitMsg> listRow = ht[msgId];
                       listRow.Add(msg);
                   }
                   msgCount++;
               }
               return ht;
           }
           catch (Exception ex)
           {

               log.Error("从数据分组出错!", ex);
               return null;
           }
       }

     static  public List<string> ExtractPhone(List<SubmitMsg> list)
       {
           List<string> pList=new List<string>();
           foreach (SubmitMsg msg in list)
           {
              pList.Add( msg.MobileId);
           }
           return pList;
       }

       static int threadNum;
       /// <summary>并发线程计数
       /// 
       /// </summary>
       public static int ThreadNum
       {
           get { return threadNum; }
       }

     static  public int UpdateThreadNum(int j)
       {
               threadNum = threadNum + j;
               return threadNum;
       }

        /// <summary>url转换字符集为指定字符集
        /// 
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="name">字符集名称</param>
        /// <returns>转化后的字符串</returns>
       static public string URLEncoding(string str, string name)
        {
            return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding(name));
        }

       /// <summary>获取字符md5码
       /// 
       /// </summary>
       /// <param name="strText"></param>
       /// <returns>md5码</returns>
     static  public string MD5Encrypt(string strText)
       {
           return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5");
       }

        /// <summary>
        /// 将list中包含的号码格式化
        /// </summary>
        /// <param name="msgDataRow">包含数据行的list</param>
        /// <returns>格式化后的字符</returns>
      public static string PhoneNumTogether(params string[] phoneList)
        {
            StringBuilder phoneNumList = new StringBuilder();
            foreach (string phone in phoneList)
            {
                phoneNumList.Append(",");
                phoneNumList.Append(phone);
            }
            string phoneNums = phoneNumList.ToString();
            if (phoneNums.IndexOf(',') == 0)
            {
                phoneNums = phoneNums.Substring(1);
            }
            return phoneNums;
        }

        /// <summary>将电话字符串用separator指定的字符分割
       /// 
       /// </summary>
        /// <param name="photoString">电话串</param>
        /// <param name="separator">分隔符</param>
       /// <returns>电话号数组</returns>
      public static  string[] UnPhotoTogether(string phoneNumString,params char[] separator)
        {
            return phoneNumString.Split((separator),StringSplitOptions.RemoveEmptyEntries);
        }



        /// <summary>
        /// 使用post，请求指定url
        /// </summary>
        /// <param name="requestStr">url</param>
        /// <returns>响应字符串</returns>

       public static string SendPostRequestByUrl(string requestStr) { 
        return  SendPostRequestByUrl(requestStr,"GB2312");
       }
       public static string SendPostRequestByUrl(string requestStr, string textEncoding)
        {
            try
            {
                String url = requestStr;
                string[] urlList = url.Split(new char[] { '?' });
                WebRequest req = WebRequest.Create(urlList[0]);
                req.Method = "POST";
                req.ContentType = "application/x-www-form-urlencoded";

                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(urlList[1]);
                req.ContentLength = data.Length;
                Stream stm = req.GetRequestStream();

                stm.Write(data, 0, data.Length);
                stm.Close();

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();

                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding(textEncoding));
                string retString = sr.ReadToEnd();
                sr.Close();
                //log.Debug(retString);
                return retString;
            }
            catch (Exception ex)
            {
                log.Error("SendPostRequestByUrl发送出错", ex);
                return "";
            }
        }

        /// <summary>
        /// 使用WebClient，请求指定url
        /// </summary>
        /// <param name="requestStr">url</param>
        /// <returns>响应字符串</returns>
       public static string WebClientRequestByUrl(string requestStr)
        {
            try
            {
                String url = requestStr;
                WebClient df = new WebClient();
                return df.DownloadString(url);
            }
            catch (Exception ex)
            {
                log.Error("WebClientRequestByUrl发送出错", ex);
                return "";
            }
        }
    }
}
