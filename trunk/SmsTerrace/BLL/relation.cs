using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using HzTerrace.Model;
namespace HzTerrace.BLL
{
	/// <summary>
	/// ҵ���߼���relation ��ժҪ˵����
	/// </summary>
	public class relation
	{
		private readonly HzTerrace.DAL.relation dal=new HzTerrace.DAL.relation();
		public relation()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(HzTerrace.Model.relation model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(HzTerrace.Model.relation model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int id)
		{
			
			dal.Delete(id);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public HzTerrace.Model.relation GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public HzTerrace.Model.relation GetModelByCache(int id)
		{
			
			string CacheKey = "relationModel-" + id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (HzTerrace.Model.relation)objModel;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<HzTerrace.Model.relation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<HzTerrace.Model.relation> DataTableToList(DataTable dt)
		{
			List<HzTerrace.Model.relation> modelList = new List<HzTerrace.Model.relation>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HzTerrace.Model.relation model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new HzTerrace.Model.relation();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["pertainUser"].ToString()!="")
					{
						model.pertainUser=int.Parse(dt.Rows[n]["pertainUser"].ToString());
					}
					model.name=dt.Rows[n]["name"].ToString();
					if(dt.Rows[n]["sex"].ToString()!="")
					{
						if((dt.Rows[n]["sex"].ToString()=="1")||(dt.Rows[n]["sex"].ToString().ToLower()=="true"))
						{
						model.sex=true;
						}
						else
						{
							model.sex=false;
						}
					}
					model.phone1=dt.Rows[n]["phone1"].ToString();
					model.phone2=dt.Rows[n]["phone2"].ToString();
					if(dt.Rows[n]["birthday"].ToString()!="")
					{
						model.birthday=DateTime.Parse(dt.Rows[n]["birthday"].ToString());
					}
					model.company=dt.Rows[n]["company"].ToString();
					model.email=dt.Rows[n]["email"].ToString();
					model.address=dt.Rows[n]["address"].ToString();
					if(dt.Rows[n]["group"].ToString()!="")
					{
						model.group=int.Parse(dt.Rows[n]["group"].ToString());
					}
					if(dt.Rows[n]["status"].ToString()!="")
					{
						model.status=int.Parse(dt.Rows[n]["status"].ToString());
					}
					model.remark=dt.Rows[n]["remark"].ToString();
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

