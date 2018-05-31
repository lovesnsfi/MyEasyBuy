using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MyEasyBuy.BLL
{
    public partial class eb_shoppingcart
    {
        /// <summary>
        /// 根据UserId获得购物车列表
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public DataTable GetShoppingCartList(int UserId)
        {
            return dal.GetShoppingCartList(UserId);
        }

         /// <summary>
        /// 根据商品ID与用户ID查询购物车表-----检查该用户在有没有把该商品已经加入购物车
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public MyEasyBuy.Model.eb_shoppingcart GetModel(int gid,int UserId)
        {
            return dal.GetModel(gid, UserId);
        }
    }
}
