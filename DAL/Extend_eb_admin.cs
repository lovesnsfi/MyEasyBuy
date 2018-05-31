using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace MyEasyBuy.DAL
{
    //用户自定义扩展类
    public  partial class eb_admin
    {
        /// <summary>
        /// 检查用户登陆
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public Model.eb_admin CheckLogin(string UserName,string PassWord)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("select * from eb_admin ");
            sb.Append(" where UserName=@UserName");
            sb.Append(" and PassWord=@PassWord");
            SqlParameter[] ps = { 
                                new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                                new SqlParameter("@PassWord",SqlDbType.NVarChar,50)
                                };
            ps[0].Value = UserName;
            ps[1].Value = PassWord;
            DataSet ds = DbHelperSQL.Query(sb.ToString(), ps);
            if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count==1)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            return null;
        }
    }
}
