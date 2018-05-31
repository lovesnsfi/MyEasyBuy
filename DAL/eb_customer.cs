using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MyEasyBuy.DAL
{
    /// <summary>
    /// 数据访问类:eb_customer
    /// </summary>
    public partial class eb_customer
    {
        public eb_customer()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from eb_customer");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(MyEasyBuy.Model.eb_customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into eb_customer(");
            strSql.Append("UserName,Password,Sex,Birthday,Email,Phone,IsDel)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@Password,@Sex,@Birthday,@Email,@Phone,@IsDel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.Date,3),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDel", SqlDbType.Bit)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.IsDel;

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
        public bool Update(MyEasyBuy.Model.eb_customer model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update eb_customer set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("Password=@Password,");
            strSql.Append("Sex=@Sex,");
            strSql.Append("Birthday=@Birthday,");
            strSql.Append("Email=@Email,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("IsDel=@IsDel");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.NVarChar,50),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@Birthday", SqlDbType.Date,3),
					new SqlParameter("@Email", SqlDbType.NVarChar,50),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@IsDel", SqlDbType.Bit),
					new SqlParameter("@UserId", SqlDbType.Int,4)};
            parameters[0].Value = model.UserName;
            parameters[1].Value = model.Password;
            parameters[2].Value = model.Sex;
            parameters[3].Value = model.Birthday;
            parameters[4].Value = model.Email;
            parameters[5].Value = model.Phone;
            parameters[6].Value = model.IsDel;
            parameters[7].Value = model.UserId;

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
        public bool Delete(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eb_customer ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

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
        public bool DeleteList(string UserIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from eb_customer ");
            strSql.Append(" where UserId in (" + UserIdlist + ")  ");
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
        public MyEasyBuy.Model.eb_customer GetModel(int UserId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserId,UserName,Password,Sex,Birthday,Email,Phone,IsDel from eb_customer ");
            strSql.Append(" where UserId=@UserId");
            SqlParameter[] parameters = {
					new SqlParameter("@UserId", SqlDbType.Int,4)
			};
            parameters[0].Value = UserId;

            MyEasyBuy.Model.eb_customer model = new MyEasyBuy.Model.eb_customer();
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
        public MyEasyBuy.Model.eb_customer DataRowToModel(DataRow row)
        {
            MyEasyBuy.Model.eb_customer model = new MyEasyBuy.Model.eb_customer();
            if (row != null)
            {
                if (row["UserId"] != null && row["UserId"].ToString() != "")
                {
                    model.UserId = int.Parse(row["UserId"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["Password"] != null)
                {
                    model.Password = row["Password"].ToString();
                }
                if (row["Sex"] != null)
                {
                    model.Sex = row["Sex"].ToString();
                }
                if (row["Birthday"] != null && row["Birthday"].ToString() != "")
                {
                    model.Birthday = DateTime.Parse(row["Birthday"].ToString());
                }
                if (row["Email"] != null)
                {
                    model.Email = row["Email"].ToString();
                }
                if (row["Phone"] != null)
                {
                    model.Phone = row["Phone"].ToString();
                }
                if (row["IsDel"] != null)
                {
                    model.IsDel =bool.Parse(row["IsDel"].ToString());
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
            strSql.Append("select UserId,UserName,Password,Sex,Birthday,Email,Phone,IsDel ");
            strSql.Append(" FROM eb_customer ");
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
            strSql.Append(" UserId,UserName,Password,Sex,Birthday,Email,Phone,IsDel ");
            strSql.Append(" FROM eb_customer ");
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
            strSql.Append("select count(1) FROM eb_customer ");
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
                strSql.Append("order by T.UserId desc");
            }
            strSql.Append(")AS Row, T.*  from eb_customer T ");
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
            parameters[0].Value = "eb_customer";
            parameters[1].Value = "UserId";
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

