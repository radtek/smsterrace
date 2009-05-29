using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Net;
using System.IO;
using hz.sms.Comm;
using hz.sms.Model;
using hz.sms.DAL;
using System.Data;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using System.Collections.Specialized;
using hz.sms.Comm1;

namespace hz.sms.BLL
{
    public class SendProcessing
    {
        static int i;

     static public  int get(int j)
        {
            i = i + j;
            return i;
        }
        public string MD5Encrypt(string strText)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(strText, "MD5").ToLower();
        }

        /// <summary>url转换字符集为gb2312
        /// 
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <returns>转化后的字符串</returns>
        public string URLEncoding(string str)
        {
            return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding("gb2312"));
        }

        /// <summary>url转换字符集为指定字符集
        /// 
        /// </summary>
        /// <param name="str">要转换的字符串</param>
        /// <param name="name">字符集名称</param>
        /// <returns>转化后的字符串</returns>
        public string URLEncoding(string str, string name)
        {
            return System.Web.HttpUtility.UrlEncode(str, System.Text.Encoding.GetEncoding(name));
        }

        public string URLEncodingISO(string str)
        {
            byte[] temp = Encoding.Default.GetBytes(str);
            temp = Encoding.Convert(Encoding.GetEncoding("UTF-8"), Encoding.Default, temp);
            return Encoding.Default.GetString(temp);
        }

        /// <summary>
        /// 获取数据并分组
        /// </summary>
        /// <returns>分组后的hsahTable</returns>
        Hashtable groupData()
        {
            try
            {
                Hashtable ht = new Hashtable();
                DataTable dt = (new SubmitMsgService()).GetMsgTable();
                int msgCount = 0;    //消息个数
                foreach (DataRow row in dt.Rows)
                {
                    string msgId = row["msgId"] as string;
                    if (!ht.ContainsKey(msgId))  //如果没有此匹消息，就新创建
                    {
                        List<DataRow> listRow = new List<DataRow>();
                        listRow.Add(row);
                        ht.Add(msgId, listRow);
                    }
                    else     //如果已有此匹消息，就向这匹消息添加
                    {
                        List<DataRow> listRow = ht[msgId] as List<DataRow>;
                        listRow.Add(row);
                    }
                    msgCount++;
                }
                return ht;
            }
            catch (Exception ex)
            {
                Log.Error("从服务器获取数据出错!", ex.ToString());
                return new Hashtable();
            }
        }

        /// <summary>
        /// 将list中包含的号码格式化
        /// </summary>
        /// <param name="msgDataRow">包含数据行的list</param>
        /// <returns>格式化后的字符</returns>
        string RequestSendString(List<DataRow> msgDataRow)
        {
            StringBuilder phoneNumList = new StringBuilder();
            foreach (DataRow row in msgDataRow)
            {
                phoneNumList.Append(",");
                phoneNumList.Append(row["mobileId"] as string);
            }
            string phoneNums = phoneNumList.ToString();
            if (phoneNums.IndexOf(',') == 0)
            {
                phoneNums = phoneNums.Substring(1);
            }
            return phoneNums;
        }

        string[] UnRequestSendString(string photoString)
        {
            return photoString.Split((new char[] { ',' }), StringSplitOptions.RemoveEmptyEntries);
        }


        public void timer1_Tick(object sender, EventArgs e)
        {
            lock (this)
            {
                if (i >= InitInfo.TIMER_EVENT_COUNT)
                {
                    return;
                }
                Console.WriteLine("并发线程数：" + get(1));
            }
            try
            {
                IList resultList = new ArrayList();

                Hashtable ht = groupData();
                Console.WriteLine("获得消息" + ht.Count + "组");
                //遍历hashTable发送消息
                foreach (DictionaryEntry var in ht)
                {
                    List<DataRow> rowlist = var.Value as List<DataRow>;
                    string numlist = RequestSendString(rowlist);

                    string resultString = SendSms(numlist, (rowlist[0]["message"] as string), rowlist[0]["extcode"] as string);

                    resultList.Add(SendedInfo(resultString, rowlist, numlist));   //添加返回结果
                }
                ResultDealwith(resultList);
            }
            catch (Exception e1)
            {
                Log.Error("发送短信出错!", e1.ToString());
            }
            finally
            {
                lock (this)
                {
                    get(-1);
                }
            }
        }

        IList SendedInfo(string resultString, List<DataRow> rowlist, string numlist)
        {
            try
            {
                IList resultInfo = new ArrayList();
                resultInfo.Add(resultString);   //  将返回的字符串添加到[0]
                resultInfo.Add(rowlist[0]["message"] as string);     //将发送的短信内容添加到[1]

                ReportSubmit rsub = new ReportSubmit();
                rsub.seqid = rowlist[0]["seqId"].ToString();
                rsub.channelId = Convert.ToInt32(InitInfo.CHANNEL_NUM);
                rsub.msgId = rowlist[0]["msgId"].ToString();
                rsub.mobileId = numlist;
                rsub.state = getState(resultString);
                rsub.stateDesc = resultString + "_" + GetDesc(resultString); ;// getXMLInfo(resultString, "ErrorDesc");
                resultInfo.Add(rsub);    //将发送的信息实体添加到[2]
                return resultInfo;
            }
            catch (Exception e1)
            {
                Log.Error("整理发送信息出错", e1.ToString());
                return new ArrayList();
            }
        }


        /// <summary>获取节点内容，
        /// 
        /// </summary>
        /// <param name="r">xml字符串</param>
        /// <param name="nodeTagName">标签名字</param>
        /// <returns>节点内容</returns>
        public string getXMLInfo(string r, string nodeTagName)
        {
            string re = r.ToLower().Replace(" language=\"javascript\"", "").Replace("script", "s").Replace("alert", "a");
            if (re.Length >= 100)
            {
                re = re.Substring(0, 100);
            }
            return re;
            //try
            //{
            //    string rTemp = "";
            //    XmlDocument xmlR = new XmlDocument();
            //    xmlR.LoadXml(r);
            //    XmlNodeList xnl = xmlR.GetElementsByTagName(nodeTagName);
            //    if (xnl.Count > 0)
            //    {
            //        rTemp = URLEncodingISO(xnl[0].InnerText.Trim());
            //    }
            //    return rTemp;
            //}
            //catch (Exception ex)
            //{
            //    Log.Error("获取节点内容出错" + ex);
            //    return "";
            //}
        }
       string  GetDesc(string r)
       {
           if (r==null||r.Trim().Length<1)
           {
               return "无返回信息";
           }
           switch (r.Trim())
           {
               case "1":
                   return  "发送成功";
               case "-4":
                   return "内容包含不合法";
               case "-5":
                   return "登录账户错误";
               case "-9":
                   return "手机号码不合法";
               case "-10":
                   return "号码太长";
               case "-11":
                   return "内容太长";
               case "-12":
                   return "提供商内部错误";
               case "-13":
                   return "余额不足";
               case "-20":
                   return "内容太长";
               default:
                 return   "其他错误";
           }
       }

        int getState(string r)
        {

            try
            {
                if (r==null)
                {
                    return -1;
                }
                switch (r.Trim())
                {
                    case "1":
                        return 0;
                    case "":
                        return -1;
                    default:
                        return 1;
                }
            }
            catch (Exception ex)
            {
                Log.Error("状态获取出错!", ex.ToString());
                return -1;
            }

        }
        public string SendSms(string mobiles, string messages, string msgid)
        {
            try
            {
                
                Console.WriteLine("[" + DateTime.Now.ToString() + "]\t正在发送短信:" + mobiles + "\t内容：" + messages);
                string uid = InitInfo.getUSER_ID; // ConfigurationManager.AppSettings["id"].ToString();   //用户名
                string rpwd = InitInfo.getPWD; //ConfigurationManager.AppSettings["pwd"].ToString();   //密码
                string recode = ConfigurationManager.AppSettings["ecode"].ToString(); //企业代码
                string rurl = InitInfo.getADDRESS; //ConfigurationManager.AppSettings["url"].ToString();   //请求地址
               // string extno = ConfigurationManager.AppSettings["extno"].ToString(); //扩展号
                string content = URLEncoding(messages, "GB2312");
                string param =
                    "ECODE=" + recode + "&USERNAME=" + uid + "&PASSWORD=" + rpwd + "&EXTNO=" + msgid + "&MOBILE=" +
                    mobiles + "&CONTENT=" + content + "&SEQ=1000";
                string url = rurl + "/SendMsg.php?" + param;
                Console.WriteLine(url);
                return SendRequest(url);
            }
            catch (Exception ex)
            {
                Log.Error("发送异常！", ex.ToString());
                return "-100";
            }
        }

        //发送结果处理
        void ResultDealwith(IList rListAll)
        {

            foreach (IList rList in rListAll)
            {
                string seqId = "";
                try
                {
                    string resultString = rList[0] as string;
                    string msg = rList[1] as string;
                    ReportSubmit rSub = rList[2] as ReportSubmit;
                    seqId = rSub.seqid;
                    Log.Info("seqId=" + seqId + ";手机号: " + rSub.mobileId + ":  内容:" + msg + " 发送结果:" + rSub.stateDesc + " 发送状态:" + rSub.state);

                    string[] photoList = UnRequestSendString(rSub.mobileId);
                    ReportSubmitServeic rS = new ReportSubmitServeic();
                    foreach (string var in photoList)
                    {
                        rSub.mobileId = var;
                        rS.Add(rSub);
                    }
                    Console.WriteLine("[" + DateTime.Now.ToString() + "]\t发送状态报告完成；");
                }
                catch (Exception e1)
                {
                    Log.Error("状态报告保存出错", "保存出错的seqId=" + seqId + "\r\n" + e1.ToString());
                }
            }
        }



        /// <summary>
        /// 使用post，请求指定url
        /// </summary>
        /// <param name="requestStr">url</param>
        /// <returns>响应字符串</returns>
        public virtual string SendRequest(string requestStr)
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
                
                StreamReader sr = new StreamReader(res.GetResponseStream(), System.Text.Encoding.GetEncoding("GB2312"));
                string retString = sr.ReadToEnd();
                sr.Close();
                Log.Debug(retString);
                return retString;
            }
            catch (Exception ex)
            {
                Log.Error("Post发送出错", ex.ToString());
                return "";
            }
        }

        /// <summary>
        /// 使用WebClient，请求指定url
        /// </summary>
        /// <param name="requestStr">url</param>
        /// <returns>响应字符串</returns>
        public virtual string SendWebClientDownloadString(string requestStr)
        {
            try
            {
                String url = requestStr;
                WebClient df = new WebClient();
                return df.DownloadString(url);
            }
            catch (Exception ex)
            {
                Log.Error("WebClient发送出错", ex.ToString());
                return "";
            }
        }
    }
}
