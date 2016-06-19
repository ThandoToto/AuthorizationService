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
        IEmailSetting _emailSetting;

        public EmailService(IEmailSetting emailSetting)
        {
            _emailSetting = emailSetting;
        }

        public async Task SendAsync(IdentityMessage message)
        {
            MailMessage mailMessage = new MailMessage(_emailSetting.FromAddress, message.Destination, message.Subject, message.Body);
            mailMessage.IsBodyHtml = true;

            SmtpClient client = new SmtpClient(_emailSetting.Server);
            client.Credentials = new NetworkCredential(_emailSetting.UserName, _emailSetting.Password);
            client.Send(mailMessage);

            await Task.FromResult<int>(0);
        }
        
    }
}

