using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleIdentityService.Models;
using SimpleIdentityService.Models.Managers;

namespace SimpleIdentityService
{
    public class IdentityService : IIdentityService
    {
        ServiceUserManager _userManager;

        public IdentityService(ServiceUserManager userManager)
        {
            _userManager = userManager;
        }
        public Task<ServiceUser> GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }
    }
}
