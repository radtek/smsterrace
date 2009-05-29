using System;
using System.Collections.Generic;
using System.Text;
using hz.sms.Model;
using hz.sms.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace hz.sms.DAL
{
    public class MoPendingDealService
    {
        //public static int AddMo(MoPendingDeal mo)
        //{
        //    try
        //    {
        //        String sql = "insert into mo_pending_deal(mobileId,extCode,channelId,content)"
        //                            + " values(@mobileId,@extCode,@channelId,@content)";
        //        SqlParameter[] ps ={
        //        new SqlParameter("@mobileId",mo.MobileId),
        //        new SqlParameter("@extCode",mo.ExtCode),
        //        new SqlParameter("@channelId",mo.ChannelId),
        //        new SqlParameter("@content",mo.Content),
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
        public int Add(hz.sms.Model.MoPendingDeal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into mo_pending_deal(");
            strSql.Append("mobileId,extCode,channelId,content,processDate)");
            strSql.Append(" values (");
            strSql.Append("@mobileId,@extCode,@channelId,@content,@processDate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@mobileId", SqlDbType.VarChar,14),
					new SqlParameter("@extCode", SqlDbType.VarChar,30),
					new SqlParameter("@channelId", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.VarChar,200),
					new SqlParameter("@processDate", SqlDbType.DateTime)};
            parameters[0].Value = model.mobileId;
            parameters[1].Value = model.extCode;
            parameters[2].Value = model.channelId;
            parameters[3].Value = model.content;
            parameters[4].Value = model.processDate;

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
            strSql.Append("select count(1) from mo_pending_deal");
            strSql.Append(" where seqId=@seqId ");
            SqlParameter[] parameters = {
					new SqlParameter("@seqId", SqlDbType.Decimal)};
            parameters[0].Value = seqId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(hz.sms.Model.mo_pending_deal model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update mo_pending_deal set ");
            strSql.Append("mobileId=@mobileId,");
            strSql.Append("extCode=@extCode,");
            strSql.Append("channelId=@channelId,");
            strSql.Append("content=@content,");
            strSql.Append("processDate=@processDate");
            strSql.Append(" where seqId=@seqId ");
            SqlParameter[] parameters = {
					new SqlParameter("@seqId", SqlDbType.Decimal,9),
					new SqlParameter("@mobileId", SqlDbType.VarChar,14),
					new SqlParameter("@extCode", SqlDbType.VarChar,30),
					new SqlParameter("@channelId", SqlDbType.Int,4),
					new SqlParameter("@content", SqlDbType.VarChar,200),
					new SqlParameter("@processDate", SqlDbType.DateTime)};
            parameters[0].Value = model.seqId;
            parameters[1].Value = model.mobileId;
            parameters[2].Value = model.extCode;
            parameters[3].Value = model.channelId;
            parameters[4].Value = model.content;
            parameters[5].Value = model.processDate;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(decimal seqId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete mo_pending_deal ");
            strSql.Append(" where seqId=@seqId ");
            SqlParameter[] parameters = {
					new SqlParameter("@seqId", SqlDbType.Decimal)};
            parameters[0].Value = seqId;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public hz.sms.Model.mo_pending_deal GetModel(decimal seqId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 seqId,mobileId,extCode,channelId,content,processDate from mo_pending_deal ");
            strSql.Append(" where seqId=@seqId ");
            SqlParameter[] parameters = {
					new SqlParameter("@seqId", SqlDbType.Decimal)};
            parameters[0].Value = seqId;

            hz.sms.Model.mo_pending_deal model = new hz.sms.Model.mo_pending_deal();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["seqId"].ToString() != "")
                {
                    model.seqId = decimal.Parse(ds.Tables[0].Rows[0]["seqId"].ToString());
                }
                model.mobileId = ds.Tables[0].Rows[0]["mobileId"].ToString();
                model.extCode = ds.Tables[0].Rows[0]["extCode"].ToString();
                if (ds.Tables[0].Rows[0]["channelId"].ToString() != "")
                {
                    model.channelId = int.Parse(ds.Tables[0].Rows[0]["channelId"].ToString());
                }
                model.content = ds.Tables[0].Rows[0]["content"].ToString();
                if (ds.Tables[0].Rows[0]["processDate"].ToString() != "")
                {
                    model.processDate = DateTime.Parse(ds.Tables[0].Rows[0]["processDate"].ToString());
                }
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
            strSql.Append("select seqId,mobileId,extCode,channelId,content,processDate ");
            strSql.Append(" FROM mo_pending_deal ");
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
            parameters[0].Value = "mo_pending_deal";
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
