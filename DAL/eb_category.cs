using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace MyEasyBuy.DAL
{
	/// <summary>
	/// 数据访问类:eb_category
	/// </summary>
	public partial class eb_category
	{
		public eb_category()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("cid", "eb_category"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int cid)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from eb_category");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(MyEasyBuy.Model.eb_category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into eb_category(");
			strSql.Append("cname,summary)");
			strSql.Append(" values (");
			strSql.Append("@cname,@summary)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,50),
					new SqlParameter("@summary", SqlDbType.NChar,10)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.summary;

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
		public bool Update(MyEasyBuy.Model.eb_category model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update eb_category set ");
			strSql.Append("cname=@cname,");
			strSql.Append("summary=@summary");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cname", SqlDbType.NVarChar,50),
					new SqlParameter("@summary", SqlDbType.NVarChar,50),
					new SqlParameter("@cid", SqlDbType.Int,4)};
			parameters[0].Value = model.cname;
			parameters[1].Value = model.summary;
			parameters[2].Value = model.cid;

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
		public bool Delete(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from eb_category ");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

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
		public bool DeleteList(string cidlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from eb_category ");
			strSql.Append(" where cid in ("+cidlist + ")  ");
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
		public MyEasyBuy.Model.eb_category GetModel(int cid)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 cid,cname,summary from eb_category ");
			strSql.Append(" where cid=@cid");
			SqlParameter[] parameters = {
					new SqlParameter("@cid", SqlDbType.Int,4)
			};
			parameters[0].Value = cid;

			MyEasyBuy.Model.eb_category model=new MyEasyBuy.Model.eb_category();
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
		public MyEasyBuy.Model.eb_category DataRowToModel(DataRow row)
		{
			MyEasyBuy.Model.eb_category model=new MyEasyBuy.Model.eb_category();
			if (row != null)
			{
				if(row["cid"]!=null && row["cid"].ToString()!="")
				{
					model.cid=int.Parse(row["cid"].ToString());
				}
				if(row["cname"]!=null)
				{
					model.cname=row["cname"].ToString();
				}
				if(row["summary"]!=null)
				{
					model.summary=row["summary"].ToString();
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
			strSql.Append("select cid,cname,summary ");
			strSql.Append(" FROM eb_category ");
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
			strSql.Append(" cid,cname,summary ");
			strSql.Append(" FROM eb_category ");
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
			strSql.Append("select count(1) FROM eb_category ");
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
				strSql.Append("order by T.cid desc");
			}
			strSql.Append(")AS Row, T.*  from eb_category T ");
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
			parameters[0].Value = "eb_category";
			parameters[1].Value = "cid";
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

