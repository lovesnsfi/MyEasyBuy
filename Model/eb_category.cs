using System;
namespace MyEasyBuy.Model
{
	/// <summary>
	/// eb_category:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class eb_category
	{
		public eb_category()
		{}
		#region Model
		private int _cid;
		private string _cname;
		private string _summary;
		/// <summary>
		/// 
		/// </summary>
		public int cid
		{
			set{ _cid=value;}
			get{return _cid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string cname
		{
			set{ _cname=value;}
			get{return _cname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string summary
		{
			set{ _summary=value;}
			get{return _summary;}
		}
		#endregion Model

	}
}

