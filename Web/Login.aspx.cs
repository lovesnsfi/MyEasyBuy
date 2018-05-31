using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace MyEasyBuy
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //登陆事件
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string errMsg="";
            Model.eb_admin model = new BLL.eb_admin().CheckLogin(this.txtUserName.Text.Trim(), this.txtPassWord.Text.Trim(), ref errMsg);
            if (!string.IsNullOrEmpty(errMsg))
            {
                //Response.Write("<script>alert('" + errMsg + "');</script>");
                MessageBox.Show(this.Page, errMsg);
            }
            else
            {
                if (model != null)
                {
                    //登陆成功
                    Session["UserInfo"] = model;   //保存用户登陆的信息
                    Response.Redirect("AdminIndex.html");
                }
                else
                {
                    // 登陆失败
                   // Response.Write("<script>alert('登陆失败');</script>");
                    MessageBox.Show(this.Page, "登陆失败");
                }
            }
        }
    }
}