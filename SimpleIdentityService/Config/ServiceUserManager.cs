using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using SimpleIdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService.Config
{
    public class ServiceUserManager : UserManager<ServiceUser>
    {
        public ServiceUserManager(IUserStore<ServiceUser> store, 
                                  IDataProtectionProvider dataProtectionProvider,
                                  IEmailSetting emailSetting, 
                                  string clientAppName)
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
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };

            this.UserLockoutEnabledByDefault = true;
            this.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            this.MaxFailedAccessAttemptsBeforeLockout = 5;

            this.EmailService = new EmailService(emailSetting);

            if (dataProtectionProvider != null)
            {
                this.UserTokenProvider = new DataProtectorTokenProvider<ServiceUser>(dataProtectionProvider.Create(clientAppName));
            }
        }
    }
}
