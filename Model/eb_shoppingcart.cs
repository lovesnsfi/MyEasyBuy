using System;
namespace MyEasyBuy.Model
{
    /// <summary>
    /// eb_shoppingcart:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class eb_shoppingcart
    {
        public eb_shoppingcart()
        { }
        #region Model
        private int _sid;
        private int _gid;
        private int _userid;
        private int _count;
        /// <summary>
        /// 
        /// </summary>
        public int sid
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int gid
        {
            set { _gid = value; }
            get { return _gid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Count
        {
            set { _count = value; }
            get { return _count; }
        }
        #endregion Model

    }
}

