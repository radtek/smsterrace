using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using SmsTerrace.Model;
namespace SmsTerrace.BLL
{
	/// <summary>
	/// ҵ���߼�����ż�¼ ��ժҪ˵����
	/// </summary>
	public class ���ż�¼Manage
	{
		private readonly SmsTerrace.DAL.���ż�¼Service dal=new SmsTerrace.DAL.���ż�¼Service();
		public ���ż�¼Manage()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int ���)
		{
			return dal.Exists(���);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(SmsTerrace.Model.���ż�¼ model)
		{
			dal.Add(model);
		}
        /// <summary>
        /// ����һ������
        /// </summary>
        public object AddReId(SmsTerrace.Model.���ż�¼ model)
        {
           return  dal.AddReId(model);
        }
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SmsTerrace.Model.���ż�¼ model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int ���)
		{
			
			dal.Delete(���);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public SmsTerrace.Model.���ż�¼ GetModel(int ���)
		{
			
			return dal.GetModel(���);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public SmsTerrace.Model.���ż�¼ GetModelByCache(int ���)
		{
			
			string CacheKey = "���ż�¼Model-" + ���;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(���);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SmsTerrace.Model.���ż�¼)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<SmsTerrace.Model.���ż�¼> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SmsTerrace.Model.���ż�¼> modelList = new List<SmsTerrace.Model.���ż�¼>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SmsTerrace.Model.���ż�¼ model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SmsTerrace.Model.���ż�¼();
					model.��ע=ds.Tables[0].Rows[n]["��ע"].ToString();
					if(ds.Tables[0].Rows[n]["���"].ToString()!="")
					{
						model.���=int.Parse(ds.Tables[0].Rows[n]["���"].ToString());
					}
					model.����=ds.Tables[0].Rows[n]["����"].ToString();
					model.����=ds.Tables[0].Rows[n]["����"].ToString();
					model.ʱ��=ds.Tables[0].Rows[n]["ʱ��"].ToString();
					model.״̬=ds.Tables[0].Rows[n]["״̬"].ToString();
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

