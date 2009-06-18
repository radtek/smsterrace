using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using HzTerrace.Model;
namespace HzTerrace.BLL
{
	/// <summary>
	/// 业务逻辑类extendInfo 的摘要说明。
	/// </summary>
	public class extendInfo
	{
		private readonly HzTerrace.DAL.extendInfo dal=new HzTerrace.DAL.extendInfo();
		public extendInfo()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int id)
		{
			return dal.Exists(id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(HzTerrace.Model.extendInfo model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(HzTerrace.Model.extendInfo model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int id)
		{		
			dal.Delete(id);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public HzTerrace.Model.extendInfo GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

       

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<HzTerrace.Model.extendInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// 根据relationId,得到对象实体
        /// </summary>
        public List<HzTerrace.Model.extendInfo> GetExtendByRelId(int relId)
        {
            string sqlWhere = " relationId="+relId;
            return GetModelList(sqlWhere);
        }

        /// <summary>
        /// 根据relationId,得到分组信息
        /// </summary>
        public List<HzTerrace.Model.extendInfo> GetGroupInfo(int relId)
        {
            string sqlWhere = "sign='group_sign' and relationId=" + relId;
            return GetModelList(sqlWhere);
        }

        /// <summary>
        /// 根据relationId,得到自定义扩展信息
        /// </summary>
        public List<HzTerrace.Model.extendInfo> GetExtendInfo(int relId)
        {
            string sqlWhere = "(sign not like '%_sign' or sign is null) and relationId=" + relId;
            return GetModelList(sqlWhere);
        }

		/// <summary>
		/// 获得数据列表
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
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

