using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.Model;
using System.Data;
using hz.sms.DBUtility;
using System.Data.SqlClient;

namespace hz.sms.DAL
{
   public class ReportSubmitServeic
    {
        //public static int AddReport(ReportSubmit report)
        //{

        //    try
        //    {
        //        string sql = "insert into report_submit(msgId,mobileId,state,channelId,stateDesc)"
        //               + " values(@msgId,@mobileId,@state,@channelId,@stateDesc)";
        //        SqlParameter[] ps ={
        //        new SqlParameter("@msgId",report.MsgId),
        //        new SqlParameter("@mobileId",report.MobileId),
        //        new SqlParameter("@state",report.Status),
        //        new SqlParameter("@channelId",report.ChannelId),
        //        new SqlParameter("@stateDesc",report.StateDesc),
        //        };
        //        int result = DBHelper.ExecuteCommand(sql, ps);
        //        return result;
        //    }
        //    catch (Exception e1)
        //    {

        //        return 0;
        //    }

        //}
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(hz.sms.Model.ReportSubmit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into report_submit(");
            strSql.Append("msgId,mobileId,state,channelId,stateDesc)");
            strSql.Append(" values (");
            strSql.Append("@msgId,@mobileId,@state,@channelId,@stateDesc)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@msgId", SqlDbType.VarChar,20),
					new SqlParameter("@mobileId", SqlDbType.VarChar,14),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@channelId", SqlDbType.Int,4),
					new SqlParameter("@stateDesc", SqlDbType.VarChar,100)};
            parameters[0].Value = model.msgId;
            parameters[1].Value = model.mobileId;
            parameters[2].Value = model.state;
            parameters[3].Value = model.channelId;
            parameters[4].Value = model.stateDesc;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        #region  成员方法
        /*

          /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal seqId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from report_submit");
            strSql.Append(" where seqId=@seqId ");
            SqlParameter[] parameters = {
					new SqlParameter("@seqId", SqlDbType.Decimal)};
            parameters[0].Value = seqId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
         
       /// <summary>
       /// 更新一条数据
       /// </summary>
       public void Update(hz.sms.Model.ReportSubmit model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update report_submit set ");
           strSql.Append("msgId=@msgId,");
           strSql.Append("mobileId=@mobileId,");
           strSql.Append("state=@state,");
           strSql.Append("channelId=@channelId,");
           strSql.Append("stateDesc=@stateDesc");
           strSql.Append(" where seqId=@seqId ");
           SqlParameter[] parameters = {
                   new SqlParameter("@seqId", SqlDbType.Decimal,9),
                   new SqlParameter("@msgId", SqlDbType.VarChar,20),
                   new SqlParameter("@mobileId", SqlDbType.VarChar,14),
                   new SqlParameter("@state", SqlDbType.Int,4),
                   new SqlParameter("@channelId", SqlDbType.Int,4),
                   new SqlParameter("@stateDesc", SqlDbType.VarChar,100)};
           parameters[0].Value = model.seqId;
           parameters[1].Value = model.msgId;
           parameters[2].Value = model.mobileId;
           parameters[3].Value = model.state;
           parameters[4].Value = model.channelId;
           parameters[5].Value = model.stateDesc;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public void Delete(decimal seqId)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete report_submit ");
           strSql.Append(" where seqId=@seqId ");
           SqlParameter[] parameters = {
                   new SqlParameter("@seqId", SqlDbType.Decimal)};
           parameters[0].Value = seqId;

           DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public hz.sms.Model.report_submit GetModel(decimal seqId)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 seqId,msgId,mobileId,state,channelId,stateDesc from report_submit ");
           strSql.Append(" where seqId=@seqId ");
           SqlParameter[] parameters = {
                   new SqlParameter("@seqId", SqlDbType.Decimal)};
           parameters[0].Value = seqId;

           hz.sms.Model.report_submit model = new hz.sms.Model.report_submit();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["seqId"].ToString() != "")
               {
                   model.seqId = decimal.Parse(ds.Tables[0].Rows[0]["seqId"].ToString());
               }
               model.msgId = ds.Tables[0].Rows[0]["msgId"].ToString();
               model.mobileId = ds.Tables[0].Rows[0]["mobileId"].ToString();
               if (ds.Tables[0].Rows[0]["state"].ToString() != "")
               {
                   model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
               }
               if (ds.Tables[0].Rows[0]["channelId"].ToString() != "")
               {
                   model.channelId = int.Parse(ds.Tables[0].Rows[0]["channelId"].ToString());
               }
               model.stateDesc = ds.Tables[0].Rows[0]["stateDesc"].ToString();
               return model;
           }
           else
           {
               return null;
           }
       }

       /// <summary>
       /// 获得数据列表
       /// </summary>
       public DataSet GetList(string strWhere)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select seqId,msgId,mobileId,state,channelId,stateDesc ");
           strSql.Append(" FROM report_submit ");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           return DbHelperSQL.Query(strSql.ToString());
       }

       /*
       /// <summary>
       /// 分页获取数据列表
       /// </summary>
       public DataSet GetList(int PageSize,int PageIndex,string strWhere)
       {
           SqlParameter[] parameters = {
                   new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                   new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                   new SqlParameter("@PageSize", SqlDbType.Int),
                   new SqlParameter("@PageIndex", SqlDbType.Int),
                   new SqlParameter("@IsReCount", SqlDbType.Bit),
                   new SqlParameter("@OrderType", SqlDbType.Bit),
                   new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                   };
           parameters[0].Value = "report_submit";
           parameters[1].Value = "ID";
           parameters[2].Value = PageSize;
           parameters[3].Value = PageIndex;
           parameters[4].Value = 0;
           parameters[5].Value = 0;
           parameters[6].Value = strWhere;	
           return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
       }*/

        #endregion  成员方法
    }
}
