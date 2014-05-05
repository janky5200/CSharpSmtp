using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Smtp.Mailer;
using Smtp.Mailer.Objects;
namespace testMail
{
    class Program
    {
        static void Main(string[] args)
        {
            //普通测试
            SmtpMailClient client = new SmtpMailClient("smtp.163.com", 25, true, "XXX", "XXX");
            client.Timeout = 18000;
            MailMessage msg = new MailMessage();
            msg.From = new MailAccount("janky5200@163.com", "janky");
            msg.AddTo(new MailAccount("janky5200@Gmail.com", "测试1"));
            msg.AddTo(new MailAccount("janky@4dtechspace.com"));
            msg.AddCC(new MailAccount("janky5200@qq.com"));
            //msg.AddCC(new MailAccount("jlo@well-united.com"));
            msg.MailContent = "<p>IHU 发信IP因发送垃圾邮件或存在异常的连接行为，被暂时挂起。请检测发信IP在历史上的发信情况和发信程序是否存在异常；</p><a href='http://163.com'>163 邮箱</a>";
            msg.Subject = "测试";
            msg.IsHtml = true;
            client.Send(msg);

            //附件测试
            client = new SmtpMailClient("smtp.163.com", 25, true, "XXX", "XXX");
            client.Timeout = 18000;
            msg = new MailMessage();
            msg.From = new MailAccount("janky5200@163.com", "janky");
            msg.AddTo(new MailAccount("janky5200@Gmail.com", "测试1"));
            msg.AddTo(new MailAccount("janky@4dtechspace.com"));
            msg.AddCC(new MailAccount("janky5200@qq.com"));
            msg.MailContent = "<img src='cid:test1234' /><p>IHU 发信IP因发送垃圾邮件或存在异常的连接行为，被暂时挂起。请检测发信IP在历史上的发信情况和发信程序是否存在异常；</p><a href='http://163.com'>163 邮箱</a>";
            msg.Subject = "测试";
            msg.IsHtml = true;

            msg.AddAttachment(@"c:\test\test.txt");
            msg.AddAttachment(@"c:\test\taiwan.jpg", "test1234"); //这里是content-id
            msg.AddAttachment(@"c:\test\filechktool.rar");
            client.SendAsync(msg);

            //ssl 测试
            SmtpServerInfo info = new SmtpServerInfo("smtp.gmail.com", 465, true, "XXX", "janky,.XXX");
            info.EnableSsl = true;
            client = new SmtpMailClient(info);
            client.Timeout = 18000;
            msg = new MailMessage();
            msg.From = new MailAccount("janky5200@Gmail.com", "系统");
            msg.AddTo(new MailAccount("janky5200@163.com", "测试1"));
            msg.AddTo(new MailAccount("janky@4dtechspace.com"));
            msg.AddCC(new MailAccount("janky5200@qq.com"));
            msg.MailContent = "<p>IHU 发信IP因发送垃圾邮件或存在异常的连接行为，被暂时挂起。请检测发信IP在历史上的发信情况和发信程序是否存在异常；</p><a href='http://163.com'>163 邮箱</a>";
            msg.Subject = "测试";
            msg.IsHtml = true;
            client.Send(msg);
            Console.ReadKey();
        }
    }
}
