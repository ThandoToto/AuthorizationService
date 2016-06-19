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
    }
}
