using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIdentityService.Models
{
    public class ServiceRole : IdentityRole
    {
        public string Description { get; set; }
    }
}
