using SamCommerce.CustomerModule.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Repositories
{
    public interface ICustomerRepository : IMemberRepository
    {
        IQueryable<OrganizationEntity> Organizations { get; }
        IQueryable<ContactEntity> Contacts { get; }
        IQueryable<VendorEntity> Vendors { get; }
        IQueryable<EmployeeEntity> Employees { get; }
    }
}
