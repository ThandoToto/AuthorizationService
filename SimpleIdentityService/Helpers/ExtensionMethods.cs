using SimpleIdentityService.Common;
using SimpleIdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService.Helpers
{
    public static class ExtensionMethods
    {
        public static ServiceUser ConverNewUser(this User user)
        {
            return new ServiceUser {
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.Cell,
                UserName = user.Username,
                Email = user.Email
            };
        }
    }
}
