using SamCommerce.CustomerModule.Core.Model;
using SamCommerce.Platform.Core.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Models
{
    public class VendorEntity : MemberEntity
    {
        public string Description { get; set; }

        [StringLength(2048)]
        public string SiteUrl { get; set; }
        [StringLength(2048)]
        public string LogoUrl { get; set; }
        [StringLength(64)]
        public string GroupName { get; set; }

        public override Member ToModel(Member member)
        {
            //Call base converter first
            base.ToModel(member);

            if (member is Vendor vendor)
            {
                vendor.SiteUrl = SiteUrl;
                vendor.LogoUrl = LogoUrl;
                vendor.GroupName = GroupName;
                vendor.Description = Description;
            }

            return member;
        }

        public override MemberEntity FromModel(Member member, PrimaryKeyResolvingMap pkMap)
        {
            if (member is Vendor vendor)
            {
                SiteUrl = vendor.SiteUrl;
                LogoUrl = vendor.LogoUrl;
                GroupName = vendor.GroupName;
                Description = vendor.Description;
            }
            //Call base converter
            return base.FromModel(member, pkMap);
        }

        public override void Patch(MemberEntity target)
        {
            if (target is VendorEntity vendorTarget)
            {
                vendorTarget.SiteUrl = SiteUrl;
                vendorTarget.LogoUrl = LogoUrl;
                vendorTarget.GroupName = GroupName;
                vendorTarget.Description = Description;
            }

            base.Patch(target);
        }
    }
}