using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using hz.sms.Comm;
using hz.sms.DBUtility;

namespace SmsTerrace.DAL
{
	/// <summary>
	/// ���ݷ�������ռ�¼��
	/// </summary>
	public class ���ռ�¼Service
	{
		public ���ռ�¼Service()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ���)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ���ռ�¼");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@���", OleDbType.Integer,4)};
			parameters[0].Value = ���;

			return DbHelperOleDb.GetTable(strSql.ToString(),parameters).Rows.Count>0;
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(SmsTerrace.Model.���ռ�¼ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ���ռ�¼(");
			strSql.Append("��ע,������,������,����,ʱ��)");
			strSql.Append(" values (");
			strSql.Append("@��ע,@������,@������,@����,@ʱ��)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@��ע", OleDbType.VarChar,0),					
					new OleDbParameter("@������", OleDbType.VarChar,50),
					new OleDbParameter("@������", OleDbType.VarChar,50),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@ʱ��", OleDbType.VarChar,50)};
			parameters[0].Value = model.��ע;
			parameters[1].Value = model.������;
			parameters[2].Value = model.������!=null? model.������:"";
			parameters[3].Value = model.����;
			parameters[4].Value = model.ʱ��;
            try
            {

                DbHelperOleDb.ExecuteSql(strSql.ToString(), parameters);
            }
            catch (Exception e)
            {

                Log.Error(e.ToString());
            }

		}
        /// <summary>
        /// ����һ������,�д���
        /// </summary>
        public object AddReId(SmsTerrace.Model.���ռ�¼ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ���ռ�¼(");
            strSql.Append("��ע,���,������,������,����,ʱ��)");
            strSql.Append(" values (");
            strSql.Append("@��ע,@���,@������,@������,@����,@ʱ��)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@��ע", OleDbType.VarChar,0),
					new OleDbParameter("@���", OleDbType.Integer,4),
					new OleDbParameter("@������", OleDbType.VarChar,50),
					new OleDbParameter("@������", OleDbType.VarChar,50),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@ʱ��", OleDbType.VarChar,50)};
            parameters[0].Value = model.��ע;
            parameters[1].Value = model.���;
            parameters[2].Value = model.������;
            parameters[3].Value = model.������;
            parameters[4].Value = model.����;
            parameters[5].Value = model.ʱ��;


            strSql.Append(" SELECT @@IDENTITY  from ���ռ�¼");
            return DbHelperOleDb.GetSingle(strSql.ToString(),parameters);
        }

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SmsTerrace.Model.���ռ�¼ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ���ռ�¼ set ");
			strSql.Append("��ע=@��ע,");
			strSql.Append("���=@���,");
			strSql.Append("������=@������,");
			strSql.Append("������=@������,");
			strSql.Append("����=@����,");
			strSql.Append("ʱ��=@ʱ��");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@��ע", OleDbType.VarChar,0),
					new OleDbParameter("@���", OleDbType.Integer,4),
					new OleDbParameter("@������", OleDbType.VarChar,50),
					new OleDbParameter("@������", OleDbType.VarChar,50),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@ʱ��", OleDbType.VarChar,50)};
			parameters[0].Value = model.��ע;
			parameters[1].Value = model.���;
			parameters[2].Value = model.������;
			parameters[3].Value = model.������;
			parameters[4].Value = model.����;
			parameters[5].Value = model.ʱ��;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ���)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ���ռ�¼ ");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@���", OleDbType.Integer,4)};
			parameters[0].Value = ���;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
        public void DeleteALL()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ���ռ�¼ ");
           

            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SmsTerrace.Model.���ռ�¼ GetModel(int ���)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ���,������,������,����,ʱ��,��ע from ���ռ�¼ ");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@���", OleDbType.Integer,4)};
			parameters[0].Value = ���;

			SmsTerrace.Model.���ռ�¼ model=new SmsTerrace.Model.���ռ�¼();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.��ע=ds.Tables[0].Rows[0]["��ע"].ToString();
				if(ds.Tables[0].Rows[0]["���"].ToString()!="")
				{
					model.���=int.Parse(ds.Tables[0].Rows[0]["���"].ToString());
				}
				model.������=ds.Tables[0].Rows[0]["������"].ToString();
				model.������=ds.Tables[0].Rows[0]["������"].ToString();
				model.����=ds.Tables[0].Rows[0]["����"].ToString();
				model.ʱ��=ds.Tables[0].Rows[0]["ʱ��"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ���,������,������,����,ʱ��,��ע ");
			strSql.Append(" FROM ���ռ�¼ ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
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
			parameters[0].Value = "���ռ�¼";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

