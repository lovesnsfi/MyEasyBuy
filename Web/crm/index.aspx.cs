using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace MyEasyBuy.crm
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取商品所有的分类
                List<Model.eb_category> listCategory = new BLL.eb_category().GetModelList("");
                //skip是跳过多少条记录，take是取多少条记录
                this.rp_Category.DataSource = listCategory.Take(8);
                this.rp_Category.DataBind();

                //绑定商品的信息
                List<Model.eb_goods> listGoods = new BLL.eb_goods().GetModelList("");
               //判断一下是不是有些记录是没有传商品图片的，如果是的，就使用默认的图片替换掉
                //listGoods.ForEach(g =>
                //{
                //    if (string.IsNullOrEmpty(g.goodsimg))
                //    {
                //        g.goodsimg = ConfigHelper.GetConfigString("DefaultGoodsPic");
                //    }
                //});
                this.rp_goods.DataSource = listGoods;
                this.rp_goods.DataBind();
            }
        }

        //根据商品分类来查询
        protected void Category_Click(object sender, EventArgs e)
        {
            //很多个控件指向的都是相同的后台代码
            LinkButton lb = (LinkButton)sender;
            int cid = int.Parse(lb.CommandArgument);
             List<Model.eb_goods> listGoods=null;
            if (cid==0)
            {
                //全部的商品
                listGoods = new BLL.eb_goods().GetModelList("");
            }
            else
            {
                //绑定商品的信息
                listGoods = new BLL.eb_goods().GetModelList(" cid='" + cid + "'");
            }
           
            //判断一下是不是有些记录是没有传商品图片的，如果是的，就使用默认的图片替换掉
            //listGoods.ForEach(g =>
            //{
            //    if (string.IsNullOrEmpty(g.goodsimg))
            //    {
            //        g.goodsimg = ConfigHelper.GetConfigString("DefaultGoodsPic");
            //    }
            //});
            this.rp_goods.DataSource = listGoods;
            this.rp_goods.DataBind();
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            //如果没有输入查询条件，就应该查询出所有
            string strWhere = string.Empty;
            if (!string.IsNullOrEmpty(this.txtQuery.Text.Trim()))
            {
                strWhere = " gname  like '%" + this.txtQuery.Text.Trim() + "%'";
            }
            List<Model.eb_goods> list = new BLL.eb_goods().GetModelList(strWhere);
            this.rp_goods.DataSource = list;
            this.rp_goods.DataBind();


            //查询以后会出现页码
            double sumCount = list.Count;
            double pageSize = 8;//每页默认显示8条
            
            int count =Convert.ToInt32(Math.Ceiling(sumCount/pageSize));
            List<PageList> ls_PageList = new List<PageList>();
            for (int i = 1; i <= count; i++)
            {
                PageList p = new PageList();
                p.text = i;
                p.value = i;
                ls_PageList.Add(p);
            }
            this.rp_pagelist.DataSource = ls_PageList;
            this.rp_pagelist.DataBind();
        }


        public class PageList
        {
            public int value { get; set; }
            public int text { get; set; }
        }

        protected void PageList_Click(object sender, EventArgs e)
        {
            LinkButton lb = sender as LinkButton;
            int PageIndex =int.Parse( lb.CommandArgument);
            List<Model.eb_goods> list = new BLL.eb_goods().GetModelList("");
            var result = list.OrderBy(g => g.gid).Skip((PageIndex - 1) * 4).Take(4).ToList() ;
            this.rp_goods.DataSource =result;
            this.rp_goods.DataBind();
            double sumCount = list.Count;
            double pageSize = 8;
            int count =Convert.ToInt32( Math.Ceiling(sumCount / pageSize));
            List<PageList> ls_PageList = new List<PageList>();
            for (int i = 1; i <= count; i++)
            {
                PageList p = new PageList();
                p.text = i;
                p.value = i;
                ls_PageList.Add(p);
            }
            this.rp_pagelist.DataSource = ls_PageList;
            this.rp_pagelist.DataBind();
        }

        /// <summary>
        /// 退出登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbLogOut_Click(object sender, EventArgs e)
        {
            Session.Remove("CrmUserInfo");
        }
    }
}