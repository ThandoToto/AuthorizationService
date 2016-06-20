using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using SimpleIdentityService.Common;
using SimpleIdentityService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService
{
    public interface IIdentityService
    {
        Task<ServiceUser> GetUserByEmail(string email);
        Task<IdentityResult> CreateUser(User user);
        Task<SignInStatus> Login(IOwinContext context, string email, string password, bool rememberMe = false);
        Task<IdentityResult> Reset(string userId);
        Task<IdentityResult> RemoveUserWithEmail(string email);
        Task<IdentityResult> RemoveUserWithId(string id);
        Task<IdentityResult> UpdateUser(User user);
    }
}
