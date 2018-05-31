using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using MyEasyBuy.Model;
namespace MyEasyBuy.BLL
{
	/// <summary>
	/// eb_category
	/// </summary>
	public partial class eb_category
	{
		private readonly MyEasyBuy.DAL.eb_category dal=new MyEasyBuy.DAL.eb_category();
		public eb_category()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cid)
		{
			return dal.Exists(cid);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(MyEasyBuy.Model.eb_category model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(MyEasyBuy.Model.eb_category model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int cid)
		{
			
			return dal.Delete(cid);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string cidlist )
		{
			return dal.DeleteList(cidlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public MyEasyBuy.Model.eb_category GetModel(int cid)
		{
			
			return dal.GetModel(cid);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public MyEasyBuy.Model.eb_category GetModelByCache(int cid)
		{
			
			string CacheKey = "eb_categoryModel-" + cid;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(cid);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (MyEasyBuy.Model.eb_category)objModel;
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
		public List<MyEasyBuy.Model.eb_category> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<MyEasyBuy.Model.eb_category> DataTableToList(DataTable dt)
		{
			List<MyEasyBuy.Model.eb_category> modelList = new List<MyEasyBuy.Model.eb_category>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				MyEasyBuy.Model.eb_category model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

