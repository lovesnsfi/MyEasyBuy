using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MyEasyBuy.DAL
{
    /// <summary>
    /// 数据访问类:eb_shoppingcart
    /// </summary>
    public partial class eb_shoppingcart
    {
        public eb_shoppingcart()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from eb_shoppingcart");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MyEasyBuy.Model.eb_shoppingcart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eb_shoppingcart(");
            strSql.Append("gid,UserId,Count)");
            strSql.Append(" values (");
            strSql.Append("@gid,@UserId,@Count)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Count", SqlDbType.Int,4)};
            parameters[0].Value = model.gid;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Count;

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
        public bool Update(MyEasyBuy.Model.eb_shoppingcart model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eb_shoppingcart set ");
            strSql.Append("gid=@gid,");
            strSql.Append("UserId=@UserId,");
            strSql.Append("Count=@Count");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@gid", SqlDbType.Int,4),
					new SqlParameter("@UserId", SqlDbType.Int,4),
					new SqlParameter("@Count", SqlDbType.Int,4),
					new SqlParameter("@sid", SqlDbType.Int,4)};
            parameters[0].Value = model.gid;
            parameters[1].Value = model.UserId;
            parameters[2].Value = model.Count;
            parameters[3].Value = model.sid;

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
        public bool Delete(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eb_shoppingcart ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

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
        public bool DeleteList(string sidlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eb_shoppingcart ");
            strSql.Append(" where sid in (" + sidlist + ")  ");
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
        public MyEasyBuy.Model.eb_shoppingcart GetModel(int sid)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 sid,gid,UserId,Count from eb_shoppingcart ");
            strSql.Append(" where sid=@sid");
            SqlParameter[] parameters = {
					new SqlParameter("@sid", SqlDbType.Int,4)
			};
            parameters[0].Value = sid;

            MyEasyBuy.Model.eb_shoppingcart model = new MyEasyBuy.Model.eb_shoppingcart();
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
        public MyEasyBuy.Model.eb_shoppingcart DataRowToModel(DataRow row)
        {
            MyEasyBuy.Model.eb_shoppingcart model = new MyEasyBuy.Model.eb_shoppingcart();
            if (row != null)
            {
                if (row["sid"] != null && row["sid"].ToString() != "")
                {
                    model.sid = int.Parse(row["sid"].ToString());
                }
                if (row["gid"] != null && row["gid"].ToString() != "")
                {
                    model.gid = int.Parse(row["gid"].ToString());
                }
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["Count"] != null && row["Count"].ToString() != "")
                {
                    model.Count = int.Parse(row["Count"].ToString());
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
            strSql.Append("select sid,gid,UserId,Count ");
            strSql.Append(" FROM eb_shoppingcart ");
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
            strSql.Append(" sid,gid,UserId,Count ");
            strSql.Append(" FROM eb_shoppingcart ");
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
            strSql.Append("select count(1) FROM eb_shoppingcart ");
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
                strSql.Append("order by T.sid desc");
            }
            strSql.Append(")AS Row, T.*  from eb_shoppingcart T ");
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
            parameters[0].Value = "eb_shoppingcart";
            parameters[1].Value = "sid";
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

