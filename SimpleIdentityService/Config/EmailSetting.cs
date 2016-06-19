using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService.Config
{
    public class EmailSetting : IEmailSetting
    {
        public EmailSetting(string emailServer, string emailUser, string emailPassword, string emailFrom)
        {
            FromAddress = emailFrom;
            Server = emailServer;
            UserName = emailUser;
            Password = emailPassword;
        }

        public string FromAddress { get; }
        public string Server { get;  }
        public string Password { get; }
        public string UserName { get; }
    }
}
