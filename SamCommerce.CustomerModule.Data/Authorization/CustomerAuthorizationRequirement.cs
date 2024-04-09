using SamCommerce.Platform.Security.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Authorization
{
    public sealed class CustomerAuthorizationRequirement : PermissionAuthorizationRequirement
    {
        public CustomerAuthorizationRequirement(string permission)
            : base(permission)
        {
        }
    }
}
