using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using MyEasyBuy.Model;
namespace MyEasyBuy.BLL
{
    /// <summary>
    /// eb_shoppingcart
    /// </summary>
    public partial class eb_shoppingcart
    {
        private readonly MyEasyBuy.DAL.eb_shoppingcart dal = new MyEasyBuy.DAL.eb_shoppingcart();
        public eb_shoppingcart()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            return dal.Exists(sid);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MyEasyBuy.Model.eb_shoppingcart model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MyEasyBuy.Model.eb_shoppingcart model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int sid)
        {

            return dal.Delete(sid);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string sidlist)
        {
            return dal.DeleteList(sidlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MyEasyBuy.Model.eb_shoppingcart GetModel(int sid)
        {

            return dal.GetModel(sid);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public MyEasyBuy.Model.eb_shoppingcart GetModelByCache(int sid)
        {

            string CacheKey = "eb_shoppingcartModel-" + sid;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(sid);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (MyEasyBuy.Model.eb_shoppingcart)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MyEasyBuy.Model.eb_shoppingcart> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<MyEasyBuy.Model.eb_shoppingcart> DataTableToList(DataTable dt)
        {
            List<MyEasyBuy.Model.eb_shoppingcart> modelList = new List<MyEasyBuy.Model.eb_shoppingcart>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                MyEasyBuy.Model.eb_shoppingcart model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

