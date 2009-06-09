using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using hz.sms.DBUtility;
using System.Collections.Generic;
namespace HzTerrace.DAL
{
	/// <summary>
	/// 数据访问类relation。
	/// </summary>
	public class relation
	{
		public relation()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from relation");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(HzTerrace.Model.relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into relation(");
			strSql.Append("pertainUser,[name],sex,phone1,phone2,[birthday],[company],[email],[address],[group],[status],[remark])");
			strSql.Append(" values (");
			strSql.Append("@pertainUser,@name,@sex,@phone1,@phone2,@birthday,@company,@email,@address,@group,@status,@remark)");
			OleDbParameter[] parameters = {
					
					new OleDbParameter("@pertainUser", OleDbType.Integer,4),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@sex", OleDbType.Boolean,2),
					new OleDbParameter("@phone1", OleDbType.VarChar,50),
					new OleDbParameter("@phone2", OleDbType.VarChar,50),
					new OleDbParameter("@birthday", OleDbType.Date),
					new OleDbParameter("@company", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,50),
					new OleDbParameter("@group", OleDbType.Integer,4),
					new OleDbParameter("@status", OleDbType.Integer,4),
					new OleDbParameter("@remark", OleDbType.VarChar,0)};
            int i = 0;
			parameters[i++].Value = model.pertainUser;
			parameters[i++].Value = model.name;
            parameters[i++].Value = model.sex;
            parameters[i++].Value = model.phone1;
            parameters[i++].Value = model.phone2;
            parameters[i++].Value = model.birthday;
            parameters[i++].Value = model.company;
            parameters[i++].Value = model.email;
            parameters[i++].Value = model.address;
            parameters[i++].Value = model.group;
            parameters[i++].Value = model.status;
            parameters[i++].Value = model.remark;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(HzTerrace.Model.relation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update relation set ");
		
			strSql.Append("pertainUser=@pertainUser,");
			strSql.Append("name=@name,");
			strSql.Append("sex=@sex,");
			strSql.Append("phone1=@phone1,");
			strSql.Append("phone2=@phone2,");
			strSql.Append("birthday=@birthday,");
			strSql.Append("company=@company,");
			strSql.Append("email=@email,");
			strSql.Append("address=@address,");
			strSql.Append("group=@group,");
			strSql.Append("status=@status,");
			strSql.Append("remark=@remark");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4),
					new OleDbParameter("@pertainUser", OleDbType.Integer,4),
					new OleDbParameter("@name", OleDbType.VarChar,50),
					new OleDbParameter("@sex", OleDbType.Boolean,2),
					new OleDbParameter("@phone1", OleDbType.VarChar,50),
					new OleDbParameter("@phone2", OleDbType.VarChar,50),
					new OleDbParameter("@birthday", OleDbType.Date),
					new OleDbParameter("@company", OleDbType.VarChar,50),
					new OleDbParameter("@email", OleDbType.VarChar,50),
					new OleDbParameter("@address", OleDbType.VarChar,50),
					new OleDbParameter("@group", OleDbType.Integer,4),
					new OleDbParameter("@status", OleDbType.Integer,4),
					new OleDbParameter("@remark", OleDbType.VarChar,0)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.pertainUser;
			parameters[2].Value = model.name;
			parameters[3].Value = model.sex;
			parameters[4].Value = model.phone1;
			parameters[5].Value = model.phone2;
			parameters[6].Value = model.birthday;
			parameters[7].Value = model.company;
			parameters[8].Value = model.email;
			parameters[9].Value = model.address;
			parameters[10].Value = model.group;
			parameters[11].Value = model.status;
			parameters[12].Value = model.remark;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from relation ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
        internal List<Model.extendInfo> GetExtendInfoList(int id)
        {
            DAL.extendInfo extDal = new DAL.extendInfo();
            DataTable dt = extDal.GetList("relationId=" + id).Tables[0];
            List<Model.extendInfo> list = new List<Model.extendInfo>();
            foreach (DataRow item in dt.Rows)
            {
                Model.extendInfo extendInfoM = new Model.extendInfo();
                extendInfoM.id = item["id"] as int?;
                extendInfoM.name = item["name"] as string;
                extendInfoM.relationId = (int)item["relationId"];
                extendInfoM.value = item["value"] as string;
                extendInfoM.sign = item["sign"] as string;
                list.Add(extendInfoM);
            }
            return list;
        }

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HzTerrace.Model.relation GetModel(int id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select [id],pertainUser,[name],sex,phone1,phone2,birthday,company,email,address,group,status,remark from relation ");
			strSql.Append(" where id=@id ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@id", OleDbType.Integer,4)};
			parameters[0].Value = id;

			HzTerrace.Model.relation model=new HzTerrace.Model.relation();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["id"].ToString()!="")
				{
					model.id=int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["pertainUser"].ToString()!="")
				{
					model.pertainUser=int.Parse(ds.Tables[0].Rows[0]["pertainUser"].ToString());
				}
				model.name=ds.Tables[0].Rows[0]["name"].ToString();
				if(ds.Tables[0].Rows[0]["sex"].ToString()!="")
				{
					if((ds.Tables[0].Rows[0]["sex"].ToString()=="1")||(ds.Tables[0].Rows[0]["sex"].ToString().ToLower()=="true"))
					{
						model.sex=true;
					}
					else
					{
						model.sex=false;
					}
				}
				model.phone1=ds.Tables[0].Rows[0]["phone1"].ToString();
				model.phone2=ds.Tables[0].Rows[0]["phone2"].ToString();
				if(ds.Tables[0].Rows[0]["birthday"].ToString()!="")
				{
					model.birthday=DateTime.Parse(ds.Tables[0].Rows[0]["birthday"].ToString());
				}
				model.company=ds.Tables[0].Rows[0]["company"].ToString();
				model.email=ds.Tables[0].Rows[0]["email"].ToString();
				model.address=ds.Tables[0].Rows[0]["address"].ToString();
				if(ds.Tables[0].Rows[0]["group"].ToString()!="")
				{
					model.group=int.Parse(ds.Tables[0].Rows[0]["group"].ToString());
				}
				if(ds.Tables[0].Rows[0]["status"].ToString()!="")
				{
					model.status=int.Parse(ds.Tables[0].Rows[0]["status"].ToString());
				}
				model.remark=ds.Tables[0].Rows[0]["remark"].ToString();
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
			strSql.Append("select [id],pertainUser,[name],sex,phone1,phone2,birthday,company,email,address,group,status,remark ");
			strSql.Append(" FROM relation ");
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
			strSql.Append(" [id],pertainUser,[name],sex,phone1,phone2,birthday,company,email,address,group,status,remark ");
			strSql.Append(" FROM relation ");
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
			parameters[0].Value = "relation";
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

