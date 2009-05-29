
using System.Data.SqlClient;
using System.Text;
using hz.sms.DBUtility;

using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using hz.sms.DBUtility;//请先添加引用
namespace hz.sms.DAL
{
	/// <summary>
	/// 数据访问类SmsUserService。
	/// </summary>
	public class SmsUserService
	{
		public SmsUserService()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string userId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sms_users");
			strSql.Append(" where userId=@userId ");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.VarChar,50)};
			parameters[0].Value = userId;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据,及其子表数据
		/// </summary>
	/*	public void Add(hz.sms.Model.SmsUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sms_users(");
			strSql.Append("userId,payType,repayType,logFlag,state,oemId,parentUserId,groupId,processDate,agentLevel,userName,password,agentPass,corpSign,corporation,province,phone,linkman)");
			strSql.Append(" values (");
			strSql.Append("@userId,@payType,@repayType,@logFlag,@state,@oemId,@parentUserId,@groupId,@processDate,@agentLevel,@userName,@password,@agentPass,@corpSign,@corporation,@province,@phone,@linkman)");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.VarChar,20),
					new SqlParameter("@payType", SqlDbType.Int,4),
					new SqlParameter("@repayType", SqlDbType.Int,4),
					new SqlParameter("@logFlag", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@oemId", SqlDbType.VarChar,20),
					new SqlParameter("@parentUserId", SqlDbType.VarChar,50),
					new SqlParameter("@groupId", SqlDbType.Int,4),
					new SqlParameter("@processDate", SqlDbType.DateTime),
					new SqlParameter("@agentLevel", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.VarChar,20),
					new SqlParameter("@password", SqlDbType.VarChar,20),
					new SqlParameter("@agentPass", SqlDbType.VarChar,20),
					new SqlParameter("@corpSign", SqlDbType.VarChar,20),
					new SqlParameter("@corporation", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@linkman", SqlDbType.VarChar,20)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.payType;
			parameters[2].Value = model.repayType;
			parameters[3].Value = model.logFlag;
			parameters[4].Value = model.state;
			parameters[5].Value = model.oemId;
			parameters[6].Value = model.parentUserId;
			parameters[7].Value = model.groupId;
			parameters[8].Value = model.processDate;
			parameters[9].Value = model.agentLevel;
			parameters[10].Value = model.userName;
			parameters[11].Value = model.password;
			parameters[12].Value = model.agentPass;
			parameters[13].Value = model.corpSign;
			parameters[14].Value = model.corporation;
			parameters[15].Value = model.province;
			parameters[16].Value = model.phone;
			parameters[17].Value = model.linkman;

			List<CommandInfo> sqllist = new List<CommandInfo>();
		   
			CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
			sqllist.Add(cmd);
			StringBuilder strSql2;
			foreach (hz.sms.Model.Business models in model.Businesss)
			{
				strSql2=new StringBuilder();
				strSql2.Append("insert into user_business(");
				strSql2.Append("userId,businessId,priority,price,channelId,feeType,channelGroupId,flag,useableCount)");
				strSql2.Append(" values (");
				strSql2.Append("@userId,@businessId,@priority,@price,@channelId,@feeType,@channelGroupId,@flag,@useableCount)");
				SqlParameter[] parameters2 = {
						new SqlParameter("@userId", SqlDbType.VarChar,20),
						new SqlParameter("@businessId", SqlDbType.Int,4),
						new SqlParameter("@priority", SqlDbType.Int,4),
						new SqlParameter("@price", SqlDbType.Decimal,9),
						new SqlParameter("@channelId", SqlDbType.Int,4),
						new SqlParameter("@feeType", SqlDbType.Int,4),
						new SqlParameter("@channelGroupId", SqlDbType.Int,4),
						new SqlParameter("@flag", SqlDbType.Int,4),
						new SqlParameter("@useableCount", SqlDbType.Decimal,9)};
				parameters2[0].Value = models.userId;
				parameters2[1].Value = models.businessId;
				parameters2[2].Value = models.priority;
				parameters2[3].Value = models.price;
				parameters2[4].Value = models.channelId;
				parameters2[5].Value = models.feeType;
				parameters2[6].Value = models.channelGroupId;
				parameters2[7].Value = models.flag;
				parameters2[8].Value = models.useableCount;

				cmd = new CommandInfo(strSql2.ToString(), parameters2);
				sqllist.Add(cmd);
			}
			DbHelperSQL.ExecuteSqlTran(sqllist);
		}
     */
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(hz.sms.Model.SmsUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sms_users set ");
			strSql.Append("userId=@userId,");
			strSql.Append("payType=@payType,");
			strSql.Append("repayType=@repayType,");
			strSql.Append("logFlag=@logFlag,");
			strSql.Append("state=@state,");
			strSql.Append("oemId=@oemId,");
			strSql.Append("parentUserId=@parentUserId,");
			strSql.Append("groupId=@groupId,");
			strSql.Append("processDate=@processDate,");
			strSql.Append("agentLevel=@agentLevel,");
			strSql.Append("userName=@userName,");
			strSql.Append("password=@password,");
			strSql.Append("agentPass=@agentPass,");
			strSql.Append("corpSign=@corpSign,");
			strSql.Append("corporation=@corporation,");
			strSql.Append("province=@province,");
			strSql.Append("phone=@phone,");
			strSql.Append("linkman=@linkman");
			strSql.Append(" where userId=@userId ");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.VarChar,20),
					new SqlParameter("@payType", SqlDbType.Int,4),
					new SqlParameter("@repayType", SqlDbType.Int,4),
					new SqlParameter("@logFlag", SqlDbType.Int,4),
					new SqlParameter("@state", SqlDbType.Int,4),
					new SqlParameter("@oemId", SqlDbType.VarChar,20),
					new SqlParameter("@parentUserId", SqlDbType.VarChar,50),
					new SqlParameter("@groupId", SqlDbType.Int,4),
					new SqlParameter("@processDate", SqlDbType.DateTime),
					new SqlParameter("@agentLevel", SqlDbType.Int,4),
					new SqlParameter("@userName", SqlDbType.VarChar,20),
					new SqlParameter("@password", SqlDbType.VarChar,20),
					new SqlParameter("@agentPass", SqlDbType.VarChar,20),
					new SqlParameter("@corpSign", SqlDbType.VarChar,20),
					new SqlParameter("@corporation", SqlDbType.VarChar,100),
					new SqlParameter("@province", SqlDbType.VarChar,20),
					new SqlParameter("@phone", SqlDbType.VarChar,50),
					new SqlParameter("@linkman", SqlDbType.VarChar,20)};
			parameters[0].Value = model.userId;
			parameters[1].Value = model.payType;
			parameters[2].Value = model.repayType;
			parameters[3].Value = model.logFlag;
			parameters[4].Value = model.state;
			parameters[5].Value = model.oemId;
			parameters[6].Value = model.parentUserId;
			parameters[7].Value = model.groupId;
			parameters[8].Value = model.processDate;
			parameters[9].Value = model.agentLevel;
			parameters[10].Value = model.userName;
			parameters[11].Value = model.password;
			parameters[12].Value = model.agentPass;
			parameters[13].Value = model.corpSign;
			parameters[14].Value = model.corporation;
			parameters[15].Value = model.province;
			parameters[16].Value = model.phone;
			parameters[17].Value = model.linkman;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据，及子表所有相关数据
		/// </summary>
	/*	public void Delete(string userId)
		{
			List<CommandInfo> sqllist = new List<CommandInfo>();
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete sms_users ");
			strSql.Append(" where userId=@userId ");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.VarChar,50)};
			parameters[0].Value = userId;

			CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
			sqllist.Add(cmd);
			StringBuilder strSql2=new StringBuilder();
			strSql2.Append("delete user_business ");
			strSql2.Append(" where userId=@userId ");
			SqlParameter[] parameters2 = {
					new SqlParameter("@userId", SqlDbType.VarChar,50)};
			parameters2[0].Value = userId;

			cmd = new CommandInfo(strSql2.ToString(), parameters2);
			sqllist.Add(cmd);
			DbHelperSQL.ExecuteSqlTran(sqllist);
		}
        */

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public hz.sms.Model.SmsUser GetModel(string userId)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userId,payType,repayType,logFlag,state,oemId,parentUserId,groupId,processDate,agentLevel,userName,password,agentPass,corpSign,corporation,province,phone,linkman from sms_users ");
			strSql.Append(" where userId=@userId ");
			SqlParameter[] parameters = {
					new SqlParameter("@userId", SqlDbType.VarChar,50)};
			parameters[0].Value = userId;

			hz.sms.Model.SmsUser model=new hz.sms.Model.SmsUser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                #region  父表信息

                model.userId = ds.Tables[0].Rows[0]["userId"].ToString();
                if (ds.Tables[0].Rows[0]["payType"].ToString() != "")
                {
                    model.payType = int.Parse(ds.Tables[0].Rows[0]["payType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["repayType"].ToString() != "")
                {
                    model.repayType = int.Parse(ds.Tables[0].Rows[0]["repayType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["logFlag"].ToString() != "")
                {
                    model.logFlag = int.Parse(ds.Tables[0].Rows[0]["logFlag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["state"].ToString() != "")
                {
                    model.state = int.Parse(ds.Tables[0].Rows[0]["state"].ToString());
                }
                model.oemId = ds.Tables[0].Rows[0]["oemId"].ToString();
                model.parentUserId = ds.Tables[0].Rows[0]["parentUserId"].ToString();
                if (ds.Tables[0].Rows[0]["groupId"].ToString() != "")
                {
                    model.groupId = int.Parse(ds.Tables[0].Rows[0]["groupId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["processDate"].ToString() != "")
                {
                    model.processDate = DateTime.Parse(ds.Tables[0].Rows[0]["processDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["agentLevel"].ToString() != "")
                {
                    model.agentLevel = int.Parse(ds.Tables[0].Rows[0]["agentLevel"].ToString());
                }
                model.userName = ds.Tables[0].Rows[0]["userName"].ToString();
                model.password = ds.Tables[0].Rows[0]["password"].ToString();
                model.agentPass = ds.Tables[0].Rows[0]["agentPass"].ToString();
                model.corpSign = ds.Tables[0].Rows[0]["corpSign"].ToString();
                model.corporation = ds.Tables[0].Rows[0]["corporation"].ToString();
                model.province = ds.Tables[0].Rows[0]["province"].ToString();
                model.phone = ds.Tables[0].Rows[0]["phone"].ToString();
                model.linkman = ds.Tables[0].Rows[0]["linkman"].ToString();

                #endregion  父表信息end

                #region  子表信息

                //model.Businesss =GetBusinessByUserId(userId);
                

                #endregion  子表信息end

                return model;
            }
            else
            {
                return null;
            }
		}

        private static List<hz.sms.Model.Business> GetBusinessByUserId(string userId)
        {
            List<hz.sms.Model.Business>  models=new List<hz.sms.Model.Business>();;
            StringBuilder strSql2 = new StringBuilder();
            strSql2.Append(
                "select userId,businessId,priority,price,channelId,feeType,channelGroupId,flag,useableCount from user_business ");
            strSql2.Append(" where userId=@userId ");
            SqlParameter[] parameters2 = {
                                                 new SqlParameter("@userId", SqlDbType.VarChar, 50)
                                             };
            parameters2[0].Value = userId;

            DataSet ds2 = DbHelperSQL.Query(strSql2.ToString(), parameters2);
            if (ds2.Tables[0].Rows.Count > 0)
            {
                #region  子表字段信息

                int i = ds2.Tables[0].Rows.Count;
                
                hz.sms.Model.Business modelt;
                for (int n = 0; n < i; n++)
                {
                    modelt = new hz.sms.Model.Business();
                    modelt.userId = ds2.Tables[0].Rows[0]["userId"].ToString();
                    if (ds2.Tables[0].Rows[0]["businessId"].ToString() != "")
                    {
                        modelt.businessId = int.Parse(ds2.Tables[0].Rows[0]["businessId"].ToString());
                    }
                    if (ds2.Tables[0].Rows[0]["priority"].ToString() != "")
                    {
                        modelt.priority = int.Parse(ds2.Tables[0].Rows[0]["priority"].ToString());
                    }
                    if (ds2.Tables[0].Rows[0]["price"].ToString() != "")
                    {
                        modelt.price = decimal.Parse(ds2.Tables[0].Rows[0]["price"].ToString());
                    }
                    if (ds2.Tables[0].Rows[0]["channelId"].ToString() != "")
                    {
                        modelt.channelId = int.Parse(ds2.Tables[0].Rows[0]["channelId"].ToString());
                    }
                    if (ds2.Tables[0].Rows[0]["feeType"].ToString() != "")
                    {
                        modelt.feeType = int.Parse(ds2.Tables[0].Rows[0]["feeType"].ToString());
                    }
                    if (ds2.Tables[0].Rows[0]["channelGroupId"].ToString() != "")
                    {
                        modelt.channelGroupId = int.Parse(ds2.Tables[0].Rows[0]["channelGroupId"].ToString());
                    }
                    if (ds2.Tables[0].Rows[0]["flag"].ToString() != "")
                    {
                        modelt.flag = int.Parse(ds2.Tables[0].Rows[0]["flag"].ToString());
                    }
                    if (ds2.Tables[0].Rows[0]["useableCount"].ToString() != "")
                    {
                        modelt.useableCount = decimal.Parse(ds2.Tables[0].Rows[0]["useableCount"].ToString());
                    }
                    models.Add(modelt);
                }
                
                #endregion  子表字段信息end
            }
            return models;
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select userId,payType,repayType,logFlag,state,oemId,parentUserId,groupId,processDate,agentLevel,userName,password,agentPass,corpSign,corporation,province,phone,linkman ");
			strSql.Append(" FROM sms_users ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			parameters[0].Value = "sms_users";
			parameters[1].Value = "System.Collections.Generic.List`1[LTP.CodeHelper.ColumnInfo]";
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

