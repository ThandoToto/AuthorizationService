using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using SimpleIdentityService.Config;
using SimpleIdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService.Models.Managers
{
    public class ServiceUserManager : UserManager<ServiceUser>
    {
        public string ClientAppName { get; set; }

        public ServiceUserManager(IUserStore<ServiceUser> store,
                                  IDataProtectionProvider dataProtectionProvider,
                                  IEmailSetting emailSetting)
            : base(store)
        {
            this.UserValidator = new UserValidator<ServiceUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            this.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                //RequireNonLetterOrDigit = true,
                //RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;

            this.EmailService = new EmailService(emailSetting);

            if (dataProtectionProvider != null)
            {
                string clientApp;
                if (string.IsNullOrEmpty(ClientAppName))
                    clientApp = "Client Application";
                else
                    clientApp = ClientAppName;
                this.UserTokenProvider = new DataProtectorTokenProvider<ServiceUser>(dataProtectionProvider.Create(clientApp));
            }

            //var dataProtectionProvider = options.DataProtectionProvider;
            //if (dataProtectionProvider != null)
            //{
            //    string clientApp;
            //    if (string.IsNullOrEmpty(ClientAppName))
            //        clientApp = "Client Application";
            //    else
            //        clientApp = ClientAppName;
            //    this.UserTokenProvider =
            //        new DataProtectorTokenProvider<ServiceUser>(dataProtectionProvider.Create(clientApp));
            //}
        }
    }
}
