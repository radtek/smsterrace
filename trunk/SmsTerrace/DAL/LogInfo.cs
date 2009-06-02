using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using hz.sms.DBUtility;//请先添加引用
namespace SmsTerrace.DAL
{
	/// <summary>
	/// 数据访问类LogInfo。
	/// </summary>
	public class LogInfo
	{
		public LogInfo()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LogInfo");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			return DbHelperOleDb.GetTable(strSql.ToString(),parameters).Rows.Count>0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(SmsTerrace.Model.LogInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LogInfo(");
			strSql.Append("[date],[name],[type],[value])");
			strSql.Append(" values (");
			strSql.Append("@date,@name,@type,@value)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@date", OleDbType.Date),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@type", OleDbType.Integer,4),
					new OleDbParameter("@value", OleDbType.VarChar,0)};
			parameters[0].Value = model.date;
			parameters[1].Value = model.name;
			parameters[2].Value = model.type;
			parameters[3].Value = model.value;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SmsTerrace.Model.LogInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LogInfo set ");
			strSql.Append("date=@date,");
			strSql.Append("name=@name,");
			strSql.Append("type=@type,");
			strSql.Append("value=@value");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@date", OleDbType.Date),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@type", OleDbType.Integer,4),
					new OleDbParameter("@value", OleDbType.VarChar,0)};
			parameters[0].Value = model.date;
			
			parameters[1].Value = model.name;
			parameters[2].Value = model.type;
			parameters[3].Value = model.value;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LogInfo ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SmsTerrace.Model.LogInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select date,id,name,type,value from LogInfo ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			SmsTerrace.Model.LogInfo model=new SmsTerrace.Model.LogInfo();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["date"].ToString()!="")
				{
					model.date=DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				if(ds.Tables[0].Rows[0]["type"].ToString()!="")
				{
					model.type=int.Parse(ds.Tables[0].Rows[0]["type"].ToString());
				}
				model.value=ds.Tables[0].Rows[0]["value"].ToString();
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select date,id,name,type,value ");
			strSql.Append(" FROM LogInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Bit),
					new OleDbParameter("@OrderType", OleDbType.Bit),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "LogInfo";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

