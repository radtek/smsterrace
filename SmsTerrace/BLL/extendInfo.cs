using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using HzTerrace.Model;
namespace HzTerrace.BLL
{
	/// <summary>
	/// ҵ���߼���extendInfo ��ժҪ˵����
	/// </summary>
	public class extendInfo
	{
		private readonly HzTerrace.DAL.extendInfo dal=new HzTerrace.DAL.extendInfo();
		public extendInfo()
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
		public void Add(HzTerrace.Model.extendInfo model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(HzTerrace.Model.extendInfo model)
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
		public HzTerrace.Model.extendInfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

       

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public HzTerrace.Model.extendInfo GetModelByCache(int id)
		{
			
			string CacheKey = "extendInfoModel-" + id;
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
			return (HzTerrace.Model.extendInfo)objModel;
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
		public List<HzTerrace.Model.extendInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// ����relationId,�õ�����ʵ��
        /// </summary>
        public List<HzTerrace.Model.extendInfo> GetExtendByRelId(int relId)
        {
            string sqlWhere = " relationId="+relId;
            return GetModelList(sqlWhere);
        }

        /// <summary>
        /// ����relationId,�õ�������Ϣ
        /// </summary>
        public List<HzTerrace.Model.extendInfo> GetGroupInfo(int relId)
        {
            string sqlWhere = "sign='group_sign' and relationId=" + relId;
            return GetModelList(sqlWhere);
        }

        /// <summary>
        /// ����relationId,�õ��Զ�����չ��Ϣ
        /// </summary>
        public List<HzTerrace.Model.extendInfo> GetExtendInfo(int relId)
        {
            string sqlWhere = "(sign not like '%_sign' or sign is null) and relationId=" + relId;
            return GetModelList(sqlWhere);
        }

		/// <summary>
		/// ��������б�
		/// </summary>
		public List<HzTerrace.Model.extendInfo> DataTableToList(DataTable dt)
		{
			List<HzTerrace.Model.extendInfo> modelList = new List<HzTerrace.Model.extendInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				HzTerrace.Model.extendInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new HzTerrace.Model.extendInfo();
					if(dt.Rows[n]["id"].ToString()!="")
					{
						model.id=int.Parse(dt.Rows[n]["id"].ToString());
					}
					if(dt.Rows[n]["relationId"].ToString()!="")
					{
						model.relationId=int.Parse(dt.Rows[n]["relationId"].ToString());
					}
					model.name=dt.Rows[n]["name"].ToString();
					model.value=dt.Rows[n]["value"].ToString();
					model.sign=dt.Rows[n]["sign"].ToString();
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

