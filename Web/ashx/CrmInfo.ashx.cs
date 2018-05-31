using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace MyEasyBuy.ashx
{
    /// <summary>
    /// CrmInfo 的摘要说明
    /// </summary>
    public class CrmInfo : IHttpHandler,IReadOnlySessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request["action"] == null ? "" : context.Request["action"].ToString();
            //根据action来判断接下来的操作
            switch (action)
            {
                case "CheckCrmSession":
                    CheckCrmSession(context);
                    break;
                case "AddShoppingCart":
                    AddShoppingCart(context);
                    break;
                case "CheckCrmUserName":
                    CheckCrmUserName(context);
                    break;
                case "CheckEmail":
                    CheckEmail(context);
                    break;
                case "CheckValidateCode":
                    CheckValidateCode(context);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 检查用户是否登陆
        /// </summary>
        /// <param name="context"></param>
        private void CheckCrmSession(HttpContext context)
        {
            if (context.Session["CrmUserInfo"]==null)
            {
                //用户没有登陆
                context.Response.Write("0");
            }
            else
            {
                //用户有登陆
                context.Response.Write("1");
            }
        }

        /// <summary>
        /// 添加商品到购物车
        /// </summary>
        /// <param name="context"></param>
        private void AddShoppingCart(HttpContext context)
        {
            //其实购物车在这里是有bug
            string gid = context.Request.Form["gid"].ToString();
            string count = context.Request.Form["count"].ToString();
            int UserId = ((Model.eb_customer)context.Session["CrmUserInfo"]).UserId;
            //先判断一下，该用户的购物车里面，有没有这一条商品，如果有，就直接修改数量
            Model.eb_shoppingcart shoppingcart = null;
            shoppingcart = new BLL.eb_shoppingcart().GetModel(int.Parse(gid), UserId);
            if (shoppingcart!=null)
            {
                //表示该用户已经将该商品曾经加入到购物车里面去
                shoppingcart.Count += int.Parse(count); //修改物车里面的数量
               if(new BLL.eb_shoppingcart().Update(shoppingcart))
               {
                   //添加购物车成功
                   context.Response.Write("1");
               }
               else
               {
                   context.Response.Write("0");
               }
            }
            else
            {
                shoppingcart = new Model.eb_shoppingcart();
                shoppingcart.gid = int.Parse(gid);
                shoppingcart.Count = int.Parse(count);
                shoppingcart.UserId = ((Model.eb_customer)context.Session["CrmUserInfo"]).UserId;
                int sid = new BLL.eb_shoppingcart().Add(shoppingcart);
                if (sid > 0)
                {
                    //添加购物车成功
                    context.Response.Write("1");
                }
                else
                {
                    //添加购物车失败
                    context.Response.Write("0");
                }
            }
        }

        /// <summary>
        /// 注册时，判断用户名是否重复
        /// </summary>
        /// <param name="context"></param>
        private void CheckCrmUserName(HttpContext context)
        {
            string username = context.Request.Form["UserName"] == null ? "" : context.Request.Form["UserName"].ToString();
            if (!string.IsNullOrEmpty(username))
            {
                bool flag = new BLL.eb_customer().CheckCrmUserInfo(username);
                if (flag)
                {
                    //表示账号存在
                    context.Response.Write("1");
                }
                else
                {
                    //表示不存在
                    context.Response.Write("0");
                }
            }
            else
            {
                context.Response.Write("2");
            }
        }
        /// <summary>
        /// 注册时，检查邮箱是否已经注册
        /// </summary>
        /// <param name="context"></param>
        private void CheckEmail(HttpContext context)
        {
            string email = context.Request.Form["Email"] == null ? "" : context.Request.Form["Email"].ToString();
            if (!string.IsNullOrEmpty(email))
            {
                bool flag=new BLL.eb_customer().CheckCrmEmail(email);
                if (flag)
                {
                    //表示存在
                    context.Response.Write("1");
                }
                else
                {
                    //表示不存在
                    context.Response.Write("0");
                }
            }
            else
            {
                context.Response.Write("2");
            }
        }

        /// <summary>
        /// 检查验证码
        /// </summary>
        /// <param name="context"></param>
        private void CheckValidateCode(HttpContext context)
        {
            string code = context.Request.Form["Code"] == null ? "" : context.Request.Form["Code"].ToString();
            if (!string.IsNullOrEmpty(code))
            {
                if (code.ToUpper() == context.Session["ValidateCode"].ToString().ToUpper())
                {
                    //验证码相同
                    context.Response.Write("1");
                }
                else
                {
                    //验证码不相同
                    context.Response.Write("0");
                }
            }
            else
            {
                //未传入验证码
                context.Response.Write("2");
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}