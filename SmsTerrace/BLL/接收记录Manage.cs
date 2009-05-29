using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using SmsTerrace.Model;
namespace SmsTerrace.BLL
{
	/// <summary>
	/// ҵ���߼�����ռ�¼ ��ժҪ˵����
	/// </summary>
	public class ���ռ�¼Manage
	{
		private readonly SmsTerrace.DAL.���ռ�¼Service dal=new SmsTerrace.DAL.���ռ�¼Service();
		public ���ռ�¼Manage()
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
		public void Add(SmsTerrace.Model.���ռ�¼ model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SmsTerrace.Model.���ռ�¼ model)
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
		public SmsTerrace.Model.���ռ�¼ GetModel(int ���)
		{
			
			return dal.GetModel(���);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public SmsTerrace.Model.���ռ�¼ GetModelByCache(int ���)
		{
			
			string CacheKey = "���ռ�¼Model-" + ���;
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
			return (SmsTerrace.Model.���ռ�¼)objModel;
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
		public List<SmsTerrace.Model.���ռ�¼> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SmsTerrace.Model.���ռ�¼> modelList = new List<SmsTerrace.Model.���ռ�¼>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SmsTerrace.Model.���ռ�¼ model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SmsTerrace.Model.���ռ�¼();
					model.��ע=ds.Tables[0].Rows[n]["��ע"].ToString();
					if(ds.Tables[0].Rows[n]["���"].ToString()!="")
					{
						model.���=int.Parse(ds.Tables[0].Rows[n]["���"].ToString());
					}
					model.������=ds.Tables[0].Rows[n]["������"].ToString();
					model.������=ds.Tables[0].Rows[n]["������"].ToString();
					model.����=ds.Tables[0].Rows[n]["����"].ToString();
					model.ʱ��=ds.Tables[0].Rows[n]["ʱ��"].ToString();
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

