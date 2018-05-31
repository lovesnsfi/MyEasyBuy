using System;
namespace MyEasyBuy.Model
{
    /// <summary>
    /// eb_goods:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class eb_goods
    {
        public eb_goods()
        { }
        #region Model
        private int _gid;
        private string _gname;
        private decimal? _price;
        private decimal? _offset;
        private DateTime? _publishtime;
        private int? _total;
        private int? _cid;
        private string _goodsimg;
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
        public string gname
        {
            set { _gname = value; }
            get { return _gname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? offset
        {
            set { _offset = value; }
            get { return _offset; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? publishTime
        {
            set { _publishtime = value; }
            get { return _publishtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? total
        {
            set { _total = value; }
            get { return _total; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? cid
        {
            set { _cid = value; }
            get { return _cid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string goodsimg
        {
            set { _goodsimg = value; }
            get { return _goodsimg; }
        }
        #endregion Model

    }
}

