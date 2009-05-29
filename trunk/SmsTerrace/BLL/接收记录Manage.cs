using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using SmsTerrace.Model;
namespace SmsTerrace.BLL
{
	/// <summary>
	/// 业务逻辑类接收记录 的摘要说明。
	/// </summary>
	public class 接收记录Manage
	{
		private readonly SmsTerrace.DAL.接收记录Service dal=new SmsTerrace.DAL.接收记录Service();
		public 接收记录Manage()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int 编号)
		{
			return dal.Exists(编号);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(SmsTerrace.Model.接收记录 model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(SmsTerrace.Model.接收记录 model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int 编号)
		{
			
			dal.Delete(编号);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public SmsTerrace.Model.接收记录 GetModel(int 编号)
		{
			
			return dal.GetModel(编号);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public SmsTerrace.Model.接收记录 GetModelByCache(int 编号)
		{
			
			string CacheKey = "接收记录Model-" + 编号;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(编号);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (SmsTerrace.Model.接收记录)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<SmsTerrace.Model.接收记录> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<SmsTerrace.Model.接收记录> modelList = new List<SmsTerrace.Model.接收记录>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				SmsTerrace.Model.接收记录 model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new SmsTerrace.Model.接收记录();
					model.备注=ds.Tables[0].Rows[n]["备注"].ToString();
					if(ds.Tables[0].Rows[n]["编号"].ToString()!="")
					{
						model.编号=int.Parse(ds.Tables[0].Rows[n]["编号"].ToString());
					}
					model.发送人=ds.Tables[0].Rows[n]["发送人"].ToString();
					model.接收人=ds.Tables[0].Rows[n]["接收人"].ToString();
					model.内容=ds.Tables[0].Rows[n]["内容"].ToString();
					model.时间=ds.Tables[0].Rows[n]["时间"].ToString();
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

