using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MyEasyBuy.DAL
{
	/// <summary>
	/// 数据访问类:eb_admin
	/// </summary>
	public partial class eb_admin
	{
		public eb_admin()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Uid", "eb_admin"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Uid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from eb_admin");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MyEasyBuy.Model.eb_admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into eb_admin(");
			strSql.Append("UserName,PassWord,Telephone,Power,IsDel)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@PassWord,@Telephone,@Power,@IsDel)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Bit,1)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.Telephone;
			parameters[3].Value = model.Power;
			parameters[4].Value = model.IsDel;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
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
		public bool Update(MyEasyBuy.Model.eb_admin model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update eb_admin set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("Telephone=@Telephone,");
			strSql.Append("Power=@Power,");
			strSql.Append("IsDel=@IsDel");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@Telephone", SqlDbType.NVarChar,50),
					new SqlParameter("@Power", SqlDbType.Int,4),
					new SqlParameter("@IsDel", SqlDbType.Bit,1),
					new SqlParameter("@Uid", SqlDbType.Int,4)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.Telephone;
			parameters[3].Value = model.Power;
			parameters[4].Value = model.IsDel;
			parameters[5].Value = model.Uid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(int Uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from eb_admin ");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool DeleteList(string Uidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from eb_admin ");
			strSql.Append(" where Uid in ("+Uidlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public MyEasyBuy.Model.eb_admin GetModel(int Uid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Uid,UserName,PassWord,Telephone,Power,IsDel from eb_admin ");
			strSql.Append(" where Uid=@Uid");
			SqlParameter[] parameters = {
					new SqlParameter("@Uid", SqlDbType.Int,4)
			};
			parameters[0].Value = Uid;

			MyEasyBuy.Model.eb_admin model=new MyEasyBuy.Model.eb_admin();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public MyEasyBuy.Model.eb_admin DataRowToModel(DataRow row)
		{
			MyEasyBuy.Model.eb_admin model=new MyEasyBuy.Model.eb_admin();
			if (row != null)
			{
				if(row["Uid"]!=null && row["Uid"].ToString()!="")
				{
					model.Uid=int.Parse(row["Uid"].ToString());
				}
				if(row["UserName"]!=null)
				{
					model.UserName=row["UserName"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["Telephone"]!=null)
				{
					model.Telephone=row["Telephone"].ToString();
				}
				if(row["Power"]!=null && row["Power"].ToString()!="")
				{
					model.Power=int.Parse(row["Power"].ToString());
				}
				if(row["IsDel"]!=null && row["IsDel"].ToString()!="")
				{
					if((row["IsDel"].ToString()=="1")||(row["IsDel"].ToString().ToLower()=="true"))
					{
						model.IsDel=true;
					}
					else
					{
						model.IsDel=false;
					}
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Uid,UserName,PassWord,Telephone,Power,IsDel ");
			strSql.Append(" FROM eb_admin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Uid,UserName,PassWord,Telephone,Power,IsDel ");
			strSql.Append(" FROM eb_admin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM eb_admin ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Uid desc");
			}
			strSql.Append(")AS Row, T.*  from eb_admin T ");
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
			parameters[0].Value = "eb_admin";
			parameters[1].Value = "Uid";
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

