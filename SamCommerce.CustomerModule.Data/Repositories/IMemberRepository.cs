using SamCommerce.CustomerModule.Data.Models;
using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Repositories
{
    public interface IMemberRepository : IRepository
    {
        IQueryable<MemberEntity> Members { get; }
        IQueryable<AddressEntity> Addresses { get; }
        IQueryable<FavoriteAddressEntity> FavoriteAddresses { get; }
        IQueryable<EmailEntity> Emails { get; }
        IQueryable<NoteEntity> Notes { get; }
        IQueryable<PhoneEntity> Phones { get; }
        IQueryable<MemberRelationEntity> MemberRelations { get; }

        Task<MemberEntity[]> GetMembersByIdsAsync(string[] ids, string responseGroup = null, string[] memberTypes = null);
        Task RemoveMembersByIdsAsync(string[] ids, string[] memberTypes = null);
    }
}
