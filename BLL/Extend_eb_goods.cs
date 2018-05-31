using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Maticsoft.Common;

namespace MyEasyBuy.BLL
{
    public partial class eb_goods
    {
        /// <summary>
        /// 根据查询条件来得到商品分类，带分类的名称
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <returns>返回查询结果集</returns>
         public DataTable GetTableWidthCname(string strWhere)
        {
            return dal.GetTableWidthCname(strWhere);
        }

        //在这个地方创建商品分类的字典，实现商品分类的ID与
        //商品分类的名称的一个映射关系
        public static string GetCnameByCid(int cid)
         {
            
             object obj = DataCache.GetCache("CategoryDic");
             
             if (obj==null)
             {
                 //第一步：取得所有商品分类的信息
                 List<Model.eb_category> listCategory = new BLL.eb_category().GetModelList("");
                 //遍历集合，来创建一个字典表的映射
                 Dictionary<int, string> dic = new Dictionary<int, string>();
                 //向字典里面添加数据

                 listCategory.ForEach(g =>
                 {
                     dic.Add(g.cid, g.cname);
                 });
                 //把数据加载到缓存里面去
                 DataCache.SetCache("CategoryDic", dic);
                 return dic[cid];
             }
             else
             {
                 Dictionary<int, string> dic = obj as Dictionary<int,string>;
                 return dic[cid];
             }
         }
    }
}
