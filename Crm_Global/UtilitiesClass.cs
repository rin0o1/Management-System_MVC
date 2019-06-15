using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Mail;

namespace Crm_Global
{
    public  class MailManager
    {
        private string Sender = "frarino1002@gmail.com";
        

        private MailMessage Message;

        public  Task<bool> SendEmailWithEmailAsync(string To, string Message_, string Subject)
        {
                return Task.Run(async () =>
                   {
                       try
                       {
                           Message = new MailMessage(Sender, To, Subject, Message_);
                           SmtpClient server = new SmtpClient();
                           server.EnableSsl = true;
                           
                           await server.SendMailAsync(Message);
                           return true;
                       }
                       catch (Exception ee)
                       {
                           return false;
                       }
                });
        }

        public  async void SendEmail(string To, string Message_, string Subject)
        {
            try
            {
                Message = new MailMessage(Sender, To, Subject, Message_);
                SmtpClient server = new SmtpClient();
                server.EnableSsl = true;
                await server.SendMailAsync(Message);
               
            }
            catch (Exception ee)
            {
               
            }
        }

    }
}
