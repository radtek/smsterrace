using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Text;
using hz.sms.DBUtility;
using hz.sms.Model;

namespace SmsTerrace.DAL
{
    public class SmsRecord
    {
        public DataTable GetMoInfo()
        {
            string sql = "select * from 接收记录";
            return DbHelperOleDb.GetTable(sql);
        }
        public int AddMoInfo(MoPendingDeal moPendingDeal)
       {
           string sql = "insert into 接收记录(时间,发送人,接收人,内容,备注)values(@时间,@发送人,@接收人,@内容,@备注)";
            OleDbParameter[] dbParam = {
                                           new OleDbParameter("@时间", moPendingDeal.processDate),
                new OleDbParameter("@发送人",moPendingDeal.mobileId),
                new OleDbParameter("@接收人",""),
                new OleDbParameter("@内容",moPendingDeal.content),
                new OleDbParameter("@备注",moPendingDeal.channelId)
                                       };
            return DbHelperOleDb.ExecuteSql(sql, dbParam);
       }
    }
}
