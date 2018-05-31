using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;

namespace MyEasyBuy.BLL
{
   public partial class eb_customer
    {
       /// <summary>
       /// 检查客户端用户登陆
       /// </summary>
       /// <param name="UserName"></param>
       /// <param name="Pwd"></param>
       /// <returns></returns>
       public Model.eb_customer CheckLogin(string UserName,string Pwd)
       {
           return dal.CheckLogin(UserName, Pwd);
       }

       /// <summary>
       /// 注册的时候判断用户名是否存在
       /// </summary>
       /// <param name="UserName"></param>
       /// <returns></returns>
       public bool CheckCrmUserInfo(string UserName)
       {
           DataSet ds = dal.GetList(" UserName ='" + UserName + "' and IsDel='0'");
           if (ds!=null&&ds.Tables.Count>0&&ds.Tables[0].Rows.Count>0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       /// <summary>
       /// 注册 时，检查邮箱是否已经被注册
       /// </summary>
       /// <param name="Email"></param>
       /// <returns></returns>
       public bool CheckCrmEmail(string Email)
       {
           DataSet ds = dal.GetList(" Email ='" + Email + "' and IsDel='0'");
           if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
           {
               return true;
           }
           else
           {
               return false;
           }
       }

       /// <summary>
       /// 发送注册邮件
       /// </summary>
       /// <param name="UserName">注册人的用户名</param>
       /// <param name="ToEmailAddress">注册人的密码</param>

       public void SendRegistEmail(string UserName,string ToEmailAddress)
       {
           string subject = "欢迎注册MyEasyBuy购物网站";
           FileStream fs = new FileStream(System.Web.HttpContext.Current.Server.MapPath(@"\Log\RegistMail.txt"), FileMode.Open, FileAccess.Read);
           StreamReader reader = new StreamReader(fs, System.Text.Encoding.UTF8);
           StringBuilder sb = new StringBuilder();
           string lineText = string.Empty;
           while (!string.IsNullOrEmpty(lineText = reader.ReadLine()))
           {
               sb.AppendLine(lineText);
           }
           string result = sb.ToString();
           string body = result.Replace("${UserName}", UserName).Replace("${RegistDate}", DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")).Replace("${RegistIP}", System.Web.HttpContext.Current.Request.UserHostAddress);
           Maticsoft.Common.ProjectMail.Send(ToEmailAddress, subject, body);

       }
    }
}
