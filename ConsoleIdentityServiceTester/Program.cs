using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleIdentityService.Config;
using System.Configuration;
using Microsoft.AspNet.Identity;

namespace ConsoleIdentityServiceTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string server = ConfigurationManager.AppSettings["emailserver"];
            string user = ConfigurationManager.AppSettings["emailuser"];
            string password = ConfigurationManager.AppSettings["emailpassword"];
            string fromAddress = ConfigurationManager.AppSettings["emailfrom"];
            var emailsettings = new EmailSetting(server,user,password,fromAddress);
            var email = new EmailService(emailsettings);
            email.SendAsync(new IdentityMessage { Destination = "thando@appziko.com", Body = $"Messge sent at {DateTime.Now.Minute}", Subject="Account created" });
            Console.ReadLine();
        }
    }
}
