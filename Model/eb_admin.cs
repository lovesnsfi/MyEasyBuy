using System;
namespace MyEasyBuy.Model
{
	/// <summary>
	/// eb_admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class eb_admin
	{
		public eb_admin()
		{}
		#region Model
		private int _uid;
		private string _username;
		private string _password;
		private string _telephone;
		private int? _power;
		private bool _isdel;
		/// <summary>
		/// 
		/// </summary>
		public int Uid
		{
			set{ _uid=value;}
			get{return _uid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Power
		{
			set{ _power=value;}
			get{return _power;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsDel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		#endregion Model

	}
}

