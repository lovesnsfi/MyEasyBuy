using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;

namespace Maticsoft.Common
{
    public  class ProjectMail
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        public static void Send(string toUserAddress,string subject,string body)
        {
            MailMessage message = new MailMessage("mh475201314@163.com", toUserAddress);
            message.Subject = subject;
            message.Body = body;
            SmtpClient smtp = new SmtpClient("smtp.163.com");
            smtp.Credentials = new NetworkCredential("mh475201314", "11langxiaoshi");
            smtp.SendCompleted += (o, e) => 
            {
                if (e.Cancelled)
                {
                    //取消发送
                    using (TextWriter tw=new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(@"\Log\SendMailLog.txt"),true))
                    {
                        string str = DateTime.Now.ToString() + "【邮件取消发送】,发送地址为："+toUserAddress;
                        tw.WriteLine(str);
                        tw.Flush();
                        tw.Close();
                    }
                    return;
                }
                if (e.Error!=null)
                {
                    //发送错误
                    using (TextWriter tw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(@"\Log\SendMailLog.txt"), true))
                    {
                        string str = DateTime.Now.ToString() + "【邮件取消错误】,发送地址为：" + toUserAddress+"，【错误信息】"+e.Error.Message;
                        tw.WriteLine(str);
                        tw.Flush();
                        tw.Close();
                    }
                    return;
                }
                if (e.UserState.ToString()=="ok")
                {
                    //发送成功
                    using (TextWriter tw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(@"\Log\SendMailLog.txt"), true))
                    {
                        string str = DateTime.Now.ToString() + "【邮件发送成功】,发送地址为：" + toUserAddress   ;
                        tw.WriteLine(str);
                        tw.Flush();
                        tw.Close();
                    }
                }
                else
                {
                    //发送失败
                     using (TextWriter tw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath(@"\Log\SendMailLog.txt"), true))
                    {
                        string str = DateTime.Now.ToString() + "【邮件发送失败】,发送地址为：" + toUserAddress  ;
                        tw.WriteLine(str);
                        tw.Flush();
                        tw.Close();
                    }
                }
            };
            smtp.SendAsync(message, "ok");
        }
    }
}
