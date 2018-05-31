using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;

namespace MyEasyBuy.crm
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetCode();
        }

        private void GetCode()
        {
            //26个英文字母+10个数字
            string[] codes = { 
                             "0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F","G",
                             "F","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"
                             };
            Random rd = new Random();
            string code = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                code += codes[rd.Next(36)];
            }
             //将生成的验证码通过GDI+绘制出来
            Bitmap bmp = new Bitmap(117, 53);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#99C1CB"));
            Font font = new Font("微软雅黑", 22,FontStyle.Bold);
            Brush b = new SolidBrush(Color.Black);
            Brush r = new SolidBrush(Color.FromArgb(166, 8, 8));
            char[] ch = code.ToArray();
            for (int i = 0; i < ch.Length; i++)
            {
                if (ch[i]>='0' || ch[i]<=9)
                {
                    g.DrawString(ch[i].ToString(), font, r, new Point(3 + (i * 25), 3));
                }
                else
                {
                    g.DrawString(ch[i].ToString(), font, b, new Point(3 + (i * 25), 3));
                }
            }
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(ms.ToArray());
            Session["ValidateCode"] = code;  //将验证码存在Session中
            g.Dispose();
            bmp.Dispose();

        }
    }
}