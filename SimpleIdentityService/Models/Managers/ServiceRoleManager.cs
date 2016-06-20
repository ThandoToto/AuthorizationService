using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService.Models.Managers
{
    public class ServiceRoleManager : RoleManager<ServiceRole>
    {
        public ServiceRoleManager(IRoleStore<ServiceRole> store)
            :base(store)
        {

        }
    }
}
