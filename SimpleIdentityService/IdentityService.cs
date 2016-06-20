using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using SimpleIdentityService.Models;
using SimpleIdentityService.Models.Managers;
using SimpleIdentityService.Common;
using SimpleIdentityService.Helpers;

namespace SimpleIdentityService
{
    public class IdentityService : IIdentityService
    {
        ServiceUserManager _userManager;

        public IdentityService(ServiceUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser(User user)
        {
            string password = Password.GeneratePassword(6);
            var identityUser = user.ConverNewUser();
            var createResult = await _userManager.CreateAsync(identityUser, password);
            
            if(createResult.Succeeded)
            {
                //string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                 await _userManager.SendEmailAsync(identityUser.Id, "User Account Created", $"Username: {identityUser.UserName} \n Password: {password}");
            }
            
            return createResult;
        }

        public Task<ServiceUser> GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }
    }
}
