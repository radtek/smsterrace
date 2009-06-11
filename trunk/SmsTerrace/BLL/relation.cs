using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using HzTerrace.Model;
namespace HzTerrace.BLL
{
	/// <summary>
	/// 业务逻辑类relation 的摘要说明。
	/// </summary>
	public class relation
	{
		private readonly HzTerrace.DAL.relation dal=new HzTerrace.DAL.relation();
		public relation()
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
		public void Add(HzTerrace.Model.relation model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(HzTerrace.Model.relation model)
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
		public HzTerrace.Model.relation GetModel(int id)
		{
			
			return dal.GetModel(id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
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
		public List<HzTerrace.Model.relation> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
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

