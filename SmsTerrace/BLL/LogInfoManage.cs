using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using SmsTerrace.Model;
namespace SmsTerrace.BLL
{
	/// <summary>
	/// ҵ���߼���LogInfo ��ժҪ˵����
	/// </summary>
	public class LogInfoManage
	{

		private readonly SmsTerrace.DAL.LogInfo dal=new SmsTerrace.DAL.LogInfo();
		public LogInfoManage()
		{}

       internal static void AddLogInfo(int logType,string name,string value)
        {
            SmsTerrace.DAL.LogInfo logDal = new SmsTerrace.DAL.LogInfo();
            SmsTerrace.Model.LogInfo logInfo = new SmsTerrace.Model.LogInfo();
            logInfo.name = name;
            logInfo.type = logType;
            logInfo.value = value;
            logInfo.date = DateTime.Now;
            logDal.Add(logInfo);
        }

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
		public void Add(SmsTerrace.Model.LogInfo model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SmsTerrace.Model.LogInfo model)
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
		public SmsTerrace.Model.LogInfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
	/*	public SmsTerrace.Model.LogInfo GetModelByCache(int id)
		{
			
			string CacheKey = "LogInfoModel-" + id;
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
			return (SmsTerrace.Model.LogInfo)objModel;
		} 
     */ 

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
		public List<SmsTerrace.Model.LogInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SmsTerrace.Model.LogInfo> modelList = new List<SmsTerrace.Model.LogInfo>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SmsTerrace.Model.LogInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SmsTerrace.Model.LogInfo();
					if(ds.Tables[0].Rows[n]["date"].ToString()!="")
					{
						model.date=DateTime.Parse(ds.Tables[0].Rows[n]["date"].ToString());
					}
					if(ds.Tables[0].Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(ds.Tables[0].Rows[n]["id"].ToString());
					}
					model.name=ds.Tables[0].Rows[n]["name"].ToString();
					if(ds.Tables[0].Rows[n]["type"].ToString()!="")
					{
						model.type=int.Parse(ds.Tables[0].Rows[n]["type"].ToString());
					}
					model.value=ds.Tables[0].Rows[n]["value"].ToString();
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

