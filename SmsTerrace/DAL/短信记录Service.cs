using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using hz.sms.DBUtility;
namespace SmsTerrace.DAL
{
	/// <summary>
	/// ���ݷ�������ż�¼��
	/// </summary>
	public class ���ż�¼Service
	{
		public ���ż�¼Service()
		{}
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ���)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ���ż�¼");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@���", OleDbType.Integer,4)};
			parameters[0].Value = ���;

			return DbHelperOleDb.GetTable(strSql.ToString(),parameters).Rows.Count>0;
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(SmsTerrace.Model.���ż�¼ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ���ż�¼(");
			strSql.Append("��ע,����,����,ʱ��,״̬)");
			strSql.Append(" values (");
			strSql.Append("@��ע,@����,@����,@ʱ��,@״̬)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@��ע", OleDbType.VarChar,0),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@ʱ��", OleDbType.VarChar,50),
					new OleDbParameter("@״̬", OleDbType.VarChar,50)};
			parameters[0].Value = model.��ע;
			
			parameters[1].Value = model.����;
			parameters[2].Value = model.����;
			parameters[3].Value = model.ʱ��;
			parameters[4].Value = model.״̬;

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
        /// ����һ������
        /// </summary>
        public object AddReId(SmsTerrace.Model.���ż�¼ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ���ż�¼(");
            strSql.Append("��ע,���,����,����,ʱ��,״̬)");
            strSql.Append(" values (");
            strSql.Append("@��ע,@���,@����,@����,@ʱ��,@״̬)");
            OleDbParameter[] parameters = {
					new OleDbParameter("@��ע", OleDbType.VarChar,0),
					new OleDbParameter("@���", OleDbType.Integer,4),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@ʱ��", OleDbType.VarChar,50),
					new OleDbParameter("@״̬", OleDbType.VarChar,50)};
            parameters[0].Value = model.��ע;
            parameters[1].Value = model.���;
            parameters[2].Value = model.����;
            parameters[3].Value = model.����;
            parameters[4].Value = model.ʱ��;
            parameters[5].Value = model.״̬;


            strSql.Append(" SELECT @@IDENTITY  from ���ż�¼ ;");
            return DbHelperOleDb.GetSingle(strSql.ToString(), parameters);
        }
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SmsTerrace.Model.���ż�¼ model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ���ż�¼ set ");
			strSql.Append("��ע=@��ע,");
			strSql.Append("���=@���,");
			strSql.Append("����=@����,");
			strSql.Append("����=@����,");
			strSql.Append("ʱ��=@ʱ��,");
			strSql.Append("״̬=@״̬");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@��ע", OleDbType.VarChar,0),
					new OleDbParameter("@���", OleDbType.Integer,4),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@����", OleDbType.VarChar,0),
					new OleDbParameter("@ʱ��", OleDbType.VarChar,50),
					new OleDbParameter("@״̬", OleDbType.VarChar,50)};
			parameters[0].Value = model.��ע;
			parameters[1].Value = model.���;
			parameters[2].Value = model.����;
			parameters[3].Value = model.����;
			parameters[4].Value = model.ʱ��;
			parameters[5].Value = model.״̬;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ���)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ���ż�¼ ");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@���", OleDbType.Integer,4)};
			parameters[0].Value = ���;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
        public void DeleteALL()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ���ż�¼ ");
            DbHelperOleDb.ExecuteSql(strSql.ToString());
        }

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SmsTerrace.Model.���ż�¼ GetModel(int ���)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ��ע,���,����,����,ʱ��,״̬ from ���ż�¼ ");
			strSql.Append(" where ���=@��� ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@���", OleDbType.Integer,4)};
			parameters[0].Value = ���;

			SmsTerrace.Model.���ż�¼ model=new SmsTerrace.Model.���ż�¼();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.��ע=ds.Tables[0].Rows[0]["��ע"].ToString();
				if(ds.Tables[0].Rows[0]["���"].ToString()!="")
				{
					model.���=int.Parse(ds.Tables[0].Rows[0]["���"].ToString());
				}
				model.����=ds.Tables[0].Rows[0]["����"].ToString();
				model.����=ds.Tables[0].Rows[0]["����"].ToString();
				model.ʱ��=ds.Tables[0].Rows[0]["ʱ��"].ToString();
				model.״̬=ds.Tables[0].Rows[0]["״̬"].ToString();
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
            strSql.Append("select ���,����,����,״̬,ʱ��,��ע ");
			strSql.Append(" FROM ���ż�¼ ");
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
			parameters[0].Value = "���ż�¼";
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

