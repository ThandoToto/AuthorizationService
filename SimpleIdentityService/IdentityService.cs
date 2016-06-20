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
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;

namespace SimpleIdentityService
{
    public class IdentityService : IIdentityService
    {
        ServiceUserManager _userManager;
        ServiceSignInManager _signInManager;

        public IdentityService(ServiceUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser(User user)
        {
            string password = Password.GeneratePassword(6);
            var identityUser = user.ConverNewUser();
            var createResult = await _userManager.CreateAsync(identityUser, password);

            if (createResult.Succeeded)
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

        public async Task<SignInStatus> Login(IOwinContext context, string email, string password, bool rememberMe = false)
        {
            _signInManager = new ServiceSignInManager(_userManager, context.Authentication);
            var result = await _signInManager.PasswordSignInAsync(email, password, rememberMe, shouldLockout: false);
            if (result == SignInStatus.Success)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user.ChangePassword != null)
                    return result;
                else
                {
                    return SignInStatus.RequiresVerification;
                }
            }
            return result;
        }

        public async Task<IdentityResult> Reset(string userId)
        {
            string code = await _userManager.GenerateEmailConfirmationTokenAsync(userId);
            string password = Password.GeneratePassword(6);
            var resetResult = await _userManager.ResetPasswordAsync(userId, code, password);
            if (resetResult.Succeeded)
            {
                var user = _userManager.FindById(userId);
                user.ChangePassword = null;
                await _userManager.UpdateAsync(user);
                await _userManager.SendEmailAsync(userId, "Password Reset", $"Username: {user.UserName} \n Password: {password}");
            }
            return resetResult;
        }

        public async Task<IdentityResult> RemoveUserWithEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> RemoveUserWithId(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> UpdateUser(User user)
        {
            var updateUser = await _userManager.FindByEmailAsync(user.Email);
            updateUser.FirstName = user.FirstName;
            updateUser.LastName = user.LastName;
            updateUser.PhoneNumber = user.Cell;
            updateUser.UserName = user.Email;
            updateUser.Email = user.Email;
            return await _userManager.UpdateAsync(updateUser);
        }
    }
}
