using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEasyBuy.crm
{
    public partial class ShoppingCartList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["CrmUserInfo"] == null)
                {
                  
                }
                else
                {

                    InitData();//获得数据
                }
                
            }

        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        private void InitData()
        {
            int UserId = ((Model.eb_customer)Session["CrmUserInfo"]).UserId;
            DataTable dt = new BLL.eb_shoppingcart().GetShoppingCartList(UserId);
            this.rp_ShoppingCartList.DataSource = dt;
            this.rp_ShoppingCartList.DataBind();
        }

        /// <summary>
        /// 删除选中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void delChecked_Click(object sender, EventArgs e)
        {
            //在购物车页面当中，删除选中的数据
            if (!string.IsNullOrEmpty(this.hiddenSid.Value))
            {
                string sids = this.hiddenSid.Value.Substring(0, this.hiddenSid.Value.LastIndexOf(','));
                if (new BLL.eb_shoppingcart().DeleteList(sids))
                {
                    InitData();
                } 
            }
        }

        /// <summary>
        /// 退出登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbLogOut_Click(object sender,EventArgs e)
        {
            Session.Remove("CrmUserInfo");
            this.rp_ShoppingCartList.DataSource = null;
            this.rp_ShoppingCartList.DataBind();
        }
    }
}