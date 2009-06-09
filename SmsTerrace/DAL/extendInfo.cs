using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using hz.sms.DBUtility;
namespace HzTerrace.DAL
{
	/// <summary>
	/// 数据访问类extendInfo。
	/// </summary>
	public class extendInfo
	{
		public extendInfo()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from extendInfo");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(HzTerrace.Model.extendInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into extendInfo(");
			strSql.Append("relationId,[name],[value],sign)");
			strSql.Append(" values (");
			strSql.Append("@relationId,@name,@value,@sign)");
			OleDbParameter[] parameters = {
					
					new OleDbParameter("@relationId", OleDbType.Integer,4),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@value", OleDbType.VarChar,255),
					new OleDbParameter("@sign", OleDbType.VarChar,50)};
            int i = 0;
			parameters[i++].Value = model.relationId;
			parameters[i++].Value = model.name;
			parameters[i++].Value = model.value;
			parameters[i++].Value = model.sign;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(HzTerrace.Model.extendInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update extendInfo set ");
		
			strSql.Append("relationId=@relationId,");
			strSql.Append("name=@name,");
			strSql.Append("value=@value,");
			strSql.Append("sign=@sign");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4),
					new OleDbParameter("@relationId", OleDbType.Integer,4),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@value", OleDbType.VarChar,255),
					new OleDbParameter("@sign", OleDbType.VarChar,50)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.relationId;
			parameters[2].Value = model.name;
			parameters[3].Value = model.value;
			parameters[4].Value = model.sign;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from extendInfo ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HzTerrace.Model.extendInfo GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select [id],relationId,[name],[value],sign from extendInfo ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			HzTerrace.Model.extendInfo model=new HzTerrace.Model.extendInfo();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["relationId"].ToString()!="")
				{
					model.relationId=int.Parse(ds.Tables[0].Rows[0]["relationId"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				model.value=ds.Tables[0].Rows[0]["value"].ToString();
				model.sign=ds.Tables[0].Rows[0]["sign"].ToString();
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
			strSql.Append("select id,relationId,[name],[value],sign ");
			strSql.Append(" FROM extendInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" [id],relationId,[name],[value],sign ");
			strSql.Append(" FROM extendInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
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
			parameters[0].Value = "extendInfo";
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

