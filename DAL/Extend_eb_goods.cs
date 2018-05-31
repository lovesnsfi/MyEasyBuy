using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;

namespace MyEasyBuy.DAL
{
    /// <summary>
    /// 分部的类，用户手写的
    /// </summary>
    public partial  class eb_goods
    {
        /// <summary>
        /// 拿到商品的数据，并且带商品分类的名称
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetTableWidthCname(string strWhere)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT a.*,b.cname FROM dbo.eb_goods a");
            sb.Append(" INNER JOIN dbo.eb_category b ON a.cid = b.cid ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                sb.Append(" where ").Append(strWhere);
            }
            return DbHelperSQL.Query(sb.ToString()).Tables[0];
        }
    }
}
