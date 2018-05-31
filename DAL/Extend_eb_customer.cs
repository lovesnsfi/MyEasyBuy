using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Maticsoft.DBUtility;

namespace MyEasyBuy.DAL
{
    public partial class eb_customer
    {
        /// <summary>
        /// 检查用户登陆
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Pwd"></param>
        /// <returns></returns>
        public Model.eb_customer CheckLogin(string UserName,string Pwd)
        {
            string strSql = "select * from eb_customer where UserName=@UserName and Password=@Password";
            SqlParameter[] ps = { 
                              new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                              new SqlParameter("@Password",SqlDbType.NVarChar,50)
                              };
            ps[0].Value = UserName;
            ps[1].Value = Pwd;
            DataSet ds = DbHelperSQL.Query(strSql, ps);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count==1)
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
