using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TestEmail
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.163.com";
            MailMessage message = new MailMessage("mh475201314@163.com","365055754@qq.com");
            message.Subject = this.textBox1.Text.Trim();
            message.Body = this.richTextBox1.Text.Trim();
            smtp.Credentials = new NetworkCredential("mh475201314@163.com", "snsfi007");
            smtp.SendCompleted += (o, ee) =>
            {
                if (ee.Cancelled)
                {
                    MessageBox.Show("取消");
                }
                else
                {
                    if (ee.UserState.ToString()=="ok")
                    {
                        MessageBox.Show("发送成功");
                    }
                    else
                    {
                        MessageBox.Show("发送失败");
                    }
                }
            };
            smtp.SendAsync(message, "ok");
            
        }
        
    }
}
