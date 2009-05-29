using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using hz.sms.DBUtility;
namespace SmsTerrace.DAL
{
	/// <summary>
	/// 数据访问类短信记录。
	/// </summary>
	public class 短信记录Service
	{
		public 短信记录Service()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int 编号)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from 短信记录");
			strSql.Append(" where 编号=@编号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@编号", OleDbType.Integer,4)};
			parameters[0].Value = 编号;

			return DbHelperOleDb.GetTable(strSql.ToString(),parameters).Rows.Count>0;
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(SmsTerrace.Model.短信记录 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into 短信记录(");
			strSql.Append("备注,号码,内容,时间,状态)");
			strSql.Append(" values (");
			strSql.Append("@备注,@号码,@内容,@时间,@状态)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@备注", OleDbType.VarChar,0),
					new OleDbParameter("@号码", OleDbType.VarChar,0),
					new OleDbParameter("@内容", OleDbType.VarChar,0),
					new OleDbParameter("@时间", OleDbType.VarChar,50),
					new OleDbParameter("@状态", OleDbType.VarChar,50)};
			parameters[0].Value = model.备注;
			
			parameters[1].Value = model.号码;
			parameters[2].Value = model.内容;
			parameters[3].Value = model.时间;
			parameters[4].Value = model.状态;

            try
            {
                DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {

                e.ToString();
            }
		}

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public object AddReId(SmsTerrace.Model.短信记录 model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into 短信记录(");
            strSql.Append("备注,编号,号码,内容,时间,状态)");
            strSql.Append(" values (");
            strSql.Append("@备注,@编号,@号码,@内容,@时间,@状态)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@备注", OleDbType.VarChar,0),
					new OleDbParameter("@编号", OleDbType.Integer,4),
					new OleDbParameter("@号码", OleDbType.VarChar,0),
					new OleDbParameter("@内容", OleDbType.VarChar,0),
					new OleDbParameter("@时间", OleDbType.VarChar,50),
					new OleDbParameter("@状态", OleDbType.VarChar,50)};
            parameters[0].Value = model.备注;
            parameters[1].Value = model.编号;
            parameters[2].Value = model.号码;
            parameters[3].Value = model.内容;
            parameters[4].Value = model.时间;
            parameters[5].Value = model.状态;


            strSql.Append(" SELECT @@IDENTITY  from 短信记录 ;");
            return DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
        }
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SmsTerrace.Model.短信记录 model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update 短信记录 set ");
			strSql.Append("备注=@备注,");
			strSql.Append("编号=@编号,");
			strSql.Append("号码=@号码,");
			strSql.Append("内容=@内容,");
			strSql.Append("时间=@时间,");
			strSql.Append("状态=@状态");
			strSql.Append(" where 编号=@编号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@备注", OleDbType.VarChar,0),
					new OleDbParameter("@编号", OleDbType.Integer,4),
					new OleDbParameter("@号码", OleDbType.VarChar,0),
					new OleDbParameter("@内容", OleDbType.VarChar,0),
					new OleDbParameter("@时间", OleDbType.VarChar,50),
					new OleDbParameter("@状态", OleDbType.VarChar,50)};
			parameters[0].Value = model.备注;
			parameters[1].Value = model.编号;
			parameters[2].Value = model.号码;
			parameters[3].Value = model.内容;
			parameters[4].Value = model.时间;
			parameters[5].Value = model.状态;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int 编号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from 短信记录 ");
			strSql.Append(" where 编号=@编号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@编号", OleDbType.Integer,4)};
			parameters[0].Value = 编号;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
        public void DeleteALL()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from 短信记录 ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SmsTerrace.Model.短信记录 GetModel(int 编号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select 备注,编号,号码,内容,时间,状态 from 短信记录 ");
			strSql.Append(" where 编号=@编号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@编号", OleDbType.Integer,4)};
			parameters[0].Value = 编号;

			SmsTerrace.Model.短信记录 model=new SmsTerrace.Model.短信记录();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.备注=ds.Tables[0].Rows[0]["备注"].ToString();
				if(ds.Tables[0].Rows[0]["编号"].ToString()!="")
				{
					model.编号=int.Parse(ds.Tables[0].Rows[0]["编号"].ToString());
				}
				model.号码=ds.Tables[0].Rows[0]["号码"].ToString();
				model.内容=ds.Tables[0].Rows[0]["内容"].ToString();
				model.时间=ds.Tables[0].Rows[0]["时间"].ToString();
				model.状态=ds.Tables[0].Rows[0]["状态"].ToString();
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
            strSql.Append("select 编号,号码,内容,状态,时间,备注 ");
			strSql.Append(" FROM 短信记录 ");
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
			parameters[0].Value = "短信记录";
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

