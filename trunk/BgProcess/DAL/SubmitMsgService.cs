using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.Comm;
using hz.sms.Model;
using System.Data.SqlClient;
using hz.sms.DBUtility;
using System.Configuration;
using System.Data;

namespace hz.sms.DAL
{
   public class SubmitMsgService:hz.sms.DAL.BaseService
    {

       public DataTable GetMsgTable()
       {
            return   GetMsgTable(InitInfo.MAX_COUNT, InitInfo.CHANNEL_NUM);
       }
       public DataTable GetMsgTable(int count,string channelNum)
       {
           try
           {
               SqlParameter[] parameters = {
                                               new SqlParameter("@cacheSize", SqlDbType.VarChar),
                                               new SqlParameter("@channelId", SqlDbType.VarChar)
                                           };
               parameters[0].Value = count;
               parameters[1].Value = channelNum;
               Console.WriteLine("[" + DateTime.Now.ToString() + "]:   Scan DataBase.....");
               DataSet ds = DbHelperSQL.RunProcedure("dt_getSubmitMsg", parameters, "msgTable");
               return ds.Tables["msgTable"];
           }
           catch (Exception ex)
           {
               log.Error("获取数据出错", ex);
               return null;
           }
       }

       public List<SubmitMsg> GetMsgList(int count,string channelNum)
       {
           try
           {
               DataTable dt = GetMsgTable(count,channelNum);
               List<SubmitMsg> list = new List<SubmitMsg>();
               foreach (DataRow row in dt.Rows)
               {
                   SubmitMsg msgTemp = new SubmitMsg();
                   msgTemp.MsgId = row["msgId"].ToString();
                   msgTemp.MobileId = row["mobileId"].ToString();
                   msgTemp.Message = row["message"].ToString();
                   msgTemp.MsgType = Convert.ToInt32(row["msgType"]);
                   msgTemp.LogFlag = Convert.ToInt32(row["logFlag"]);
                   msgTemp.UserId = row["userId"].ToString();
                   msgTemp.Priority = Convert.ToInt32(row["priority"]);
                   msgTemp.ExtCode = row["extcode"].ToString();
                   msgTemp.SendType = Convert.ToInt32(row["sendType"]);
                   msgTemp.BusinessType = Convert.ToInt32(row["businessType"]);
                   msgTemp.Isstop = Convert.ToInt32(row["isstop"]);
                   msgTemp.SeqId = Convert.ToInt64(row["seqId"]);
                   list.Add(msgTemp);
               }
               return list;
           }
           catch (Exception ex)
           {
               log.Error("数据封装为实体出错",ex);
               return null;
           }
       }

       

       public  IList<SubmitMsg> GetMessages()
        {
            IList<SubmitMsg> list = new List<SubmitMsg>();
            try
            {
                    SqlParameter[] parameters = {
					new SqlParameter("@cacheSize", SqlDbType.VarChar),
                        new SqlParameter("@channelId", SqlDbType.VarChar)
                    };
                    parameters[0].Value=ConfigurationManager.AppSettings["maxcount"].ToString();
                    parameters[1].Value=ConfigurationManager.AppSettings["channel"].ToString();
                    Console.WriteLine("[" + DateTime.Now.ToString() + "]:   Scan DataBase.....");
                    using (SqlDataReader reader = DbHelperSQL.RunProcedure("dt_getSubmitMsg", parameters))
                    {
                        while (reader.Read())
                        {
                            SubmitMsg mt = new SubmitMsg();
                            mt.MsgId = reader["msgId"].ToString();
                            mt.MobileId = reader["mobileId"].ToString();
                            mt.Message = reader["message"].ToString();
                            mt.MsgType = Convert.ToInt32(reader["msgType"]);
                            mt.LogFlag = Convert.ToInt32(reader["logFlag"]);
                            mt.UserId = reader["userId"].ToString();
                            mt.Priority = Convert.ToInt32(reader["priority"]);
                            mt.ExtCode = reader["extcode"].ToString();
                            mt.SendType = Convert.ToInt32(reader["sendType"]);
                            mt.BusinessType = Convert.ToInt32(reader["businessType"]);
                            mt.Isstop = Convert.ToInt32(reader["isstop"]);
                            mt.SeqId = Convert.ToInt64(reader["seqId"]);
                            list.Add(mt);
                        }
                        reader.Close();
                        reader.Dispose();
                    }
             
                    Console.WriteLine("[" + DateTime.Now.ToString() + "]:   Scan Complete; "+list.Count);
            }
            catch (Exception e)
            {
                throw;
            }
            return list;
        }
    }
}
