using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyEasyBuy.BLL
{
    public partial class eb_admin
    {
        public Model.eb_admin CheckLogin(string UserName,string PassWord,ref string errMsg)
        {
            if (!string.IsNullOrEmpty(UserName)&&!string.IsNullOrEmpty(PassWord))
            {
                return dal.CheckLogin(UserName, PassWord);
            }
            else
            {
                errMsg = "用户名或密码不能为空";
                return null;
            }
        }
    }
}
