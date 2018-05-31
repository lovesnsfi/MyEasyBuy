using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;

namespace MyEasyBuy.DAL
{
    public partial class eb_shoppingcart
    {
        public DataTable GetShoppingCartList(int UserId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT a.*,b.gname,b.goodsimg,CAST(b.price*b.offset/10 AS DECIMAL) AS 'offsetPrice',CAST(b.price*b.offset/10*a.Count AS DECIMAL) AS 'sumPay',c.UserName FROM dbo.eb_shoppingcart a ");
            sb.Append(" INNER JOIN dbo.eb_goods b ON a.gid = b.gid ");
            sb.Append(" INNER JOIN dbo.eb_customer c ON a.UserId=c.UserId ");
            sb.Append(" where a.UserId=@UserId");
            SqlParameter[] ps = { 
                                new SqlParameter("@UserId",SqlDbType.Int)
                                };
            ps[0].Value = UserId;
            DataSet ds = DbHelperSQL.Query(sb.ToString(), ps);
            if (ds!=null&&ds.Tables.Count>0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr["goodsimg"]==null||dr["goodsimg"].ToString()=="")
                    {
                        dr["goodsimg"] = Maticsoft.Common.ConfigHelper.GetConfigString("DefaultGoodsPic");
                    }
                }
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据商品ID与用户ID查询购物车表-----检查该用户在有没有把该商品已经加入购物车
        /// </summary>
        /// <param name="gid"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public MyEasyBuy.Model.eb_shoppingcart GetModel(int gid,int UserId)
        {
            string strSql = "select * from eb_shoppingcart where gid=@gid and UserId=@UserId";
            SqlParameter[] ps = { 
                                new SqlParameter("@gid",SqlDbType.Int),
                                new SqlParameter("@UserId",SqlDbType.Int)
                                };
            ps[0].Value = gid;
            ps[1].Value = UserId;
            DataSet ds = DbHelperSQL.Query(strSql, ps);
            if (ds!=null&ds.Tables.Count>0&&ds.Tables[0].Rows.Count==1)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
    }
}
