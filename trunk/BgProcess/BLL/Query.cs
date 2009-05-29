using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Configuration;
using System.Net;
using hz.sms.Comm;
using hz.sms.Model;
using System.Xml;
using hz.sms.DAL;
using hz.sms.Comm1;

namespace hz.sms.BLL
{
  public  class Query 
    {
      
      
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
      

      public int GetQuerySms()
      {
          string rTempStr = null;
         while (SendProcessing.get(0) > 0)
          {
              System.Threading.Thread.Sleep(300);
          }
          try
          {
              SendProcessing.get(1);
              rTempStr = QuerySms();
              int iTemp = SaveQueryInfo(InterpretXML(rTempStr));
              return iTemp;
          }
          catch (Exception e)
          {
              Log.Error("获取信息出错！GetQuerySms", "返回的xml信息="+rTempStr+"\r\n"+ e.ToString());
              return -1;
          }
          finally {
              SendProcessing.get(-1);
          }
     
      }

        public string QuerySms()
        {
            try
            {
                string uid = InitInfo.getUSER_ID; // ConfigurationManager.AppSettings["id"].ToString();   //用户名
                string rpwd = InitInfo.getPWD; //ConfigurationManager.AppSettings["pwd"].ToString();   //密码
                string recode = ConfigurationManager.AppSettings["ecode"].ToString(); //企业代码
                string rurl = InitInfo.getADDRESS; //ConfigurationManager.AppSettings["url"].ToString();   //请求地址
                string extno = ConfigurationManager.AppSettings["extno"].ToString(); //扩展号
                
                string param =
                     "USERNAME=" + uid + "&PASSWORD=" + rpwd;
                string url = rurl + "/RecvMsg1.php?" + param;
                string returnResult = SendRequest(url);//recvSms(uid,rpwd);

                Console.WriteLine("接收回复:{0}", returnResult);
              
               return  returnResult;
            }
            catch (Exception ex)
            {
                Log.Error("获取上行发送异常！QuerySms", ex.ToString());
                return "-101";
            }
        }
      /// <summary>获取错误描述
      /// 
      /// </summary>
      /// <param name="r"></param>
      /// <returns></returns>
    static  string GetDesc(string r)
      {
          if (r == null || r.Trim().Length < 1)
          {
              return "";
          }
          switch (r.Trim())
          {
              case "1":
                  return "发送成功";
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
                  return r;
          }
      }
      /// <summary>解析xml为实体
      /// 
      /// </summary>
      /// <param name="xml">xml字符串</param>
      /// <returns>实体数组</returns>
      List<QueryInfo> InterpretXML(string xml)
      {

          try
          {
              string extno = ConfigurationManager.AppSettings["extno"].ToString(); //扩展号
              string[] strList = xml.Split(new string[] { "|" }, StringSplitOptions.None);
              List<QueryInfo> list = new List<QueryInfo>();
              if (strList.Length == 4)
              {
                  QueryInfo qi = new QueryInfo();
                  qi.channelId = int.Parse(InitInfo.CHANNEL_NUM);
                  int i = 0;
                  qi.mobileId = strList[i++];
                  qi.content = strList[i++];
                  qi.extCode = strList[i++].Substring(2);
                  qi.processDate = DateTime.Parse(strList[i++]);
                  list.Add(qi);
              }
              else
              {
                  string s = Query.GetDesc(xml);
                  if ("NOMESSAGE".Equals(s))
                  {
                      return list;
                  }
                  Log.Warning("获取回复不正常!" ,s);
              }
              return list;
          }
          catch (Exception ex1)
          {
              Log.Error("InterpretXML解析出错！","出错的xml:"+xml+" _"+ex1.ToString());
              return new List<QueryInfo>(); 
          }
      }

      int SaveQueryInfo(List<QueryInfo> list)
      {

          try
          {
              int i = 0;
              QueryInfoService qis = new QueryInfoService();
              foreach (QueryInfo var in list)
              {

                  try
                  {
                      Console.WriteLine("debug:保存QueryInfo:手机号"+var.mobileId );
                      int j = qis.Add(var);
                          i++;
                  }
                  catch (Exception e1)
                  {
                      Log.Error("保存上行信息中出错"+e1.ToString());
                  }
              }
              if (list.Count != i)
              {
                  Log.Warning("保存上行信息中有出问题的行！");
              }
              return i;
          }
          catch (Exception ex)
          {
              Log.Error("保存上行信息SaveQueryInfo", ex.ToString());
              return -1;
          }
         
      }

        /// <summary>
        /// 请求指定url
        /// </summary>
        /// <param name="requestStr">url</param>
        /// <returns>响应字符串</returns>
        public virtual string SendRequest(string requestStr)
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

        /// <summary>
        /// 请求指定url
        /// </summary>
        /// <param name="requestStr">url</param>
        /// <returns>响应字符串</returns>
        public virtual string SendWebClientDownloadString(string requestStr)
        {
            String url = requestStr;
            WebClient df = new WebClient();
            return df.DownloadString(url);
        }

    }
}
