using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService.Config
{
    public class EmailService : IIdentityMessageService
    {
        string _fromAddress, _emailServer, _emailUser, _emailPassword = string.Empty;

        public EmailService(string emailServer, string emailUser, string emailPassword, string emailFrom)
        {
            _fromAddress = emailFrom;
            _emailServer = emailServer;
            _emailUser = emailUser;
            _emailPassword = emailPassword;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            MailMessage mailMessage = new MailMessage(_fromAddress, message.Destination, message.Subject, message.Body);
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(_emailServer);
            client.Credentials = new NetworkCredential(_emailUser, _emailPassword);
            client.Send(mailMessage);

            await Task.FromResult<int>(0);
        }
        
    }
}

