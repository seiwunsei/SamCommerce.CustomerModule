using SamCommerce.CustomerModule.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Services
{
    /// <summary>
    /// Abstraction for member CRUD operations
    /// </summary>
    public interface IMemberService
    {
        Task<Member[]> GetByIdsAsync(string[] memberIds, string responseGroup = null, string[] memberTypes = null);
        Task<Member> GetByIdAsync(string memberId, string responseGroup = null, string memberType = null);
        Task SaveChangesAsync(Member[] members);
        Task DeleteAsync(string[] ids, string[] memberTypes = null);
    }
}