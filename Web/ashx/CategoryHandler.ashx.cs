using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyEasyBuy.ashx
{
    /// <summary>
    /// CategoryHandler 的摘要说明
    /// </summary>
    public class CategoryHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string cid = context.Request["cid"] == null ? "" : context.Request["cid"].ToString();
            bool flag= new BLL.eb_category().Delete(int.Parse(cid));
            if (flag)
            {
                //如果成功 我就输出1
                context.Response.Write("1");
            }
            else
            {
                //如果不成功，我就输出0
                context.Response.Write("0");
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