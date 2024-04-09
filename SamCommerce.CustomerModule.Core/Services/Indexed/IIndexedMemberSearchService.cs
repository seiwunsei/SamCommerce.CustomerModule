using SamCommerce.CustomerModule.Core.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Services.Indexed
{
    public interface IIndexedMemberSearchService
    {
        Task<MemberSearchResult> SearchMembersAsync(MembersSearchCriteria criteria);
    }
}