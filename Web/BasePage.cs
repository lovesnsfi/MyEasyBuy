using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEasyBuy
{
    public class BasePage : System.Web.UI.Page
    {
        protected void CheckLogin()
        {
            if (Session["UserInfo"]==null)
            {
                //表示用户没有登陆
                Maticsoft.Common.MessageBox.ResponseScript(this.Page, "top.location.href='Login.aspx'");
            }
        }
    }
}