using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEasyBuy.crm
{
    public partial class GoodsInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //获取前面页面当中传过来的值
                this.hiddenGid.Value = Request.QueryString["gid"] == null ? "" : Request.QueryString["gid"].ToString();
                InitData(); //展示商品信息
            }
        }


        /// <summary>
        /// 根据商品Id查询商品，并绑定到前台控件
        /// </summary>
        private void InitData()
        {
            if (!string.IsNullOrEmpty(this.hiddenGid.Value))
            {
                Model.eb_goods model = new BLL.eb_goods().GetModel(int.Parse(this.hiddenGid.Value));
                if (model!=null)
                {
                    //如果商品存在，开始赋值
                    this.Title ="【商品详细】"+ model.gname;
                    this.goodsimg.ImageUrl = model.goodsimg;
                    this.lbgname.Text = model.gname;
                    this.lbOffsetPrice.Text = (model.price * model.offset / 10).ToString();
                    this.lbprice.Text = model.price.ToString();
                    this.lbtotal.Text = model.total.ToString();

                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this.Page, "当前商品不存在，请刷新重试", "index.aspx");
                }
            }
        }

        //用户登陆
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string UserName = this.txtUserName.Text.Trim();
            string Pwd = this.txtPwd.Text.Trim();
            Model.eb_customer model = new BLL.eb_customer().CheckLogin(UserName, Pwd);
            if (model!=null)
            {
                //如果用户登陆成功，我们就保存用户的信息
                Session["CrmUserInfo"] = model;
                Maticsoft.Common.MessageBox.Show(this.Page, "登陆成功");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this.Page, "登陆失败");
            }
        }

        protected void lbLogOut_Click(object sender,EventArgs e)
        {
            Session.Remove("CrmUserInfo");
        }
    }
}