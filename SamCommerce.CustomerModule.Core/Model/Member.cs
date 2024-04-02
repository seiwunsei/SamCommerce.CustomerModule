using SamCommerce.CoreModule.Core.Seo;
using SamCommerce.Platform.Core.Common;
using SamCommerce.Platform.Core.Domain;
using SamCommerce.Platform.Core.DynamicProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Model
{
    /// <summary>
    /// 和系统有关的任何人和组织都叫Member,
    /// Member有多种类型，比如个人Contact, 组织Orgnization, 某个组织的员工Employee
    /// Contact是站在电商企业的角度来说的，是电商企业的个人用户
    /// Employee是站在电商企业的一个组织用户的角度来说的，是这个组织的员工
    /// 所以Contact和Employee虽然都是人，但是属性是不一样的
    /// </summary>
    public abstract class Member : AuditableEntity, IHasDynamicProperties, ISeoSupport, IHasOuterId, ICloneable
    {
        protected Member()
        {
            MemberType = GetType().Name;
        }

        public string Name { get; set; }
        public virtual string MemberType { get; set; }
        public string OuterId { get; set; }

        public string Status { get; set; }

        public IList<Address> Addresses { get; set; }
        public IList<string> Phones { get; set; }
        public IList<string> Emails { get; set; }
        public IList<Note> Notes { get; set; }
        public IList<string> Groups { get; set; }
        public string IconUrl { get; set; }

        #region IHasDynamicProperties Members

        public virtual string ObjectType => typeof(Member).FullName;
        public ICollection<DynamicObjectProperty> DynamicProperties { get; set; }

        #endregion IHasDynamicProperties Members

        #region ISeoSupport Members

        public virtual string SeoObjectType => GetType().Name;

        public virtual IList<SeoInfo> SeoInfos { get; set; }

        #endregion ISeoSupport Members

        public virtual void ReduceDetails(string responseGroup)
        {
            //Reduce details according to response group
            var memberResponseGroup = EnumUtility.SafeParseFlags(responseGroup, MemberResponseGroup.Full);

            if (!memberResponseGroup.HasFlag(MemberResponseGroup.WithNotes))
            {
                Notes = null;
            }
            if (!memberResponseGroup.HasFlag(MemberResponseGroup.WithAddresses))
            {
                Addresses = null;
            }
            if (!memberResponseGroup.HasFlag(MemberResponseGroup.WithEmails))
            {
                Emails = null;
            }
            if (!memberResponseGroup.HasFlag(MemberResponseGroup.WithGroups))
            {
                Groups = null;
            }
            if (!memberResponseGroup.HasFlag(MemberResponseGroup.WithPhones))
            {
                Phones = null;
            }
            if (!memberResponseGroup.HasFlag(MemberResponseGroup.WithSeo))
            {
                SeoInfos = null;
            }
            if (!memberResponseGroup.HasFlag(MemberResponseGroup.WithDynamicProperties))
            {
                DynamicProperties = null;
            }
        }

        #region ICloneable members

        public virtual object Clone()
        {
            var result = MemberwiseClone() as Member;

            result.Notes = Notes?.Select(x => x.Clone()).OfType<Note>().ToList();
            result.Addresses = Addresses?.Select(x => x.Clone()).OfType<Address>().ToList();
            result.SeoInfos = SeoInfos?.Select(x => x.Clone()).OfType<SeoInfo>().ToList();
            result.DynamicProperties = DynamicProperties?.Select(x => x.Clone()).OfType<DynamicObjectProperty>().ToList();

            return result;
        }

        #endregion ICloneable members
    }
}
