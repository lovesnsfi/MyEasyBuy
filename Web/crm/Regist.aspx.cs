using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyEasyBuy.crm
{
    public partial class Regist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //注册事件
        protected void btnRegist_Click(object sender, EventArgs e)
        {
            if (ckAccept.Checked==false)
            {
                Maticsoft.Common.MessageBox.Show(this.Page, "必须同意注册协议才能注册");
                return;
            }
            Model.eb_customer model = new Model.eb_customer();
            model.IsDel = false;
            model.Password = this.txtPwd.Text.Trim();   // 此处没有对密码加密
            model.Phone = this.txtTelephone.Text.Trim();
            model.Sex = this.dropSex.SelectedValue.ToString();
            model.UserName = this.txtUserName.Text.Trim();
            model.Email = this.txtEmail.Text.Trim();
            model.Birthday = DateTime.Parse(this.txtBirthday.Value);
            int UserId = new BLL.eb_customer().Add(model);
            if (UserId>0)
            {
                //表示注册成功 ，向用户发送邮件
                //跳转到主页面去
                BLL.eb_customer customerManager = new BLL.eb_customer();
                customerManager.SendRegistEmail(this.txtUserName.Text, this.txtEmail.Text);
                Response.Redirect("index.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this.Page, "注册失败，请重试或联系管理员");
            }

        }
    }
}