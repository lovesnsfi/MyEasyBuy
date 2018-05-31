using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MyEasyBuy.DAL
{
    /// <summary>
    /// 数据访问类:eb_goods
    /// </summary>
    public partial class eb_goods
    {
        public eb_goods()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int gid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from eb_goods");
            strSql.Append(" where gid=@gid");
            SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4)
			};
            parameters[0].Value = gid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MyEasyBuy.Model.eb_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eb_goods(");
            strSql.Append("gname,price,offset,publishTime,total,cid,goodsimg)");
            strSql.Append(" values (");
            strSql.Append("@gname,@price,@offset,@publishTime,@total,@cid,@goodsimg)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@gname", SqlDbType.NVarChar,50),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@offset", SqlDbType.Float,8),
					new SqlParameter("@publishTime", SqlDbType.DateTime),
					new SqlParameter("@total", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@goodsimg", SqlDbType.NVarChar,-1)};
            parameters[0].Value = model.gname;
            parameters[1].Value = model.price;
            parameters[2].Value = model.offset;
            parameters[3].Value = model.publishTime;
            parameters[4].Value = model.total;
            parameters[5].Value = model.cid;
            parameters[6].Value = model.goodsimg;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(MyEasyBuy.Model.eb_goods model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eb_goods set ");
            strSql.Append("gname=@gname,");
            strSql.Append("price=@price,");
            strSql.Append("offset=@offset,");
            strSql.Append("publishTime=@publishTime,");
            strSql.Append("total=@total,");
            strSql.Append("cid=@cid,");
            strSql.Append("goodsimg=@goodsimg");
            strSql.Append(" where gid=@gid");
            SqlParameter[] parameters = {
					new SqlParameter("@gname", SqlDbType.NVarChar,50),
					new SqlParameter("@price", SqlDbType.Float,8),
					new SqlParameter("@offset", SqlDbType.Float,8),
					new SqlParameter("@publishTime", SqlDbType.DateTime),
					new SqlParameter("@total", SqlDbType.Int,4),
					new SqlParameter("@cid", SqlDbType.Int,4),
					new SqlParameter("@goodsimg", SqlDbType.NVarChar,-1),
					new SqlParameter("@gid", SqlDbType.Int,4)};
            parameters[0].Value = model.gname;
            parameters[1].Value = model.price;
            parameters[2].Value = model.offset;
            parameters[3].Value = model.publishTime;
            parameters[4].Value = model.total;
            parameters[5].Value = model.cid;
            parameters[6].Value = model.goodsimg;
            parameters[7].Value = model.gid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int gid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eb_goods ");
            strSql.Append(" where gid=@gid");
            SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4)
			};
            parameters[0].Value = gid;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string gidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eb_goods ");
            strSql.Append(" where gid in (" + gidlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MyEasyBuy.Model.eb_goods GetModel(int gid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 gid,gname,price,offset,publishTime,total,cid,goodsimg from eb_goods ");
            strSql.Append(" where gid=@gid");
            SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4)
			};
            parameters[0].Value = gid;

            MyEasyBuy.Model.eb_goods model = new MyEasyBuy.Model.eb_goods();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public MyEasyBuy.Model.eb_goods DataRowToModel(DataRow row)
        {
            MyEasyBuy.Model.eb_goods model = new MyEasyBuy.Model.eb_goods();
            if (row != null)
            {
                if (row["gid"] != null && row["gid"].ToString() != "")
                {
                    model.gid = int.Parse(row["gid"].ToString());
                }
                if (row["gname"] != null)
                {
                    model.gname = row["gname"].ToString();
                }
                if (row["price"] != null && row["price"].ToString() != "")
                {
                    model.price = decimal.Parse(row["price"].ToString());
                }
                if (row["offset"] != null && row["offset"].ToString() != "")
                {
                    model.offset = decimal.Parse(row["offset"].ToString());
                }
                if (row["publishTime"] != null && row["publishTime"].ToString() != "")
                {
                    model.publishTime = DateTime.Parse(row["publishTime"].ToString());
                }
                if (row["total"] != null && row["total"].ToString() != "")
                {
                    model.total = int.Parse(row["total"].ToString());
                }
                if (row["cid"] != null && row["cid"].ToString() != "")
                {
                    model.cid = int.Parse(row["cid"].ToString());
                }
                if (row["goodsimg"] != null&&!string.IsNullOrEmpty(row["goodsimg"].ToString()))
                {
                    model.goodsimg = row["goodsimg"].ToString();
                }
                else
                {
                    //如果商品没有图片，我们就添加默认的图片
                    model.goodsimg = Maticsoft.Common.ConfigHelper.GetConfigString("DefaultGoodsPic");
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select gid,gname,price,offset,publishTime,total,cid,goodsimg ");
            strSql.Append(" FROM eb_goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" gid,gname,price,offset,publishTime,total,cid,goodsimg ");
            strSql.Append(" FROM eb_goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM eb_goods ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.gid desc");
            }
            strSql.Append(")AS Row, T.*  from eb_goods T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "eb_goods";
            parameters[1].Value = "gid";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

