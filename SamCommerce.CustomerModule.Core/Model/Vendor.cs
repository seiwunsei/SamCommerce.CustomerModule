﻿using SamCommerce.CoreModule.Core.Seo;
using SamCommerce.Platform.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Model
{
    public class Vendor : Member, ISeoSupport, IHasSecurityAccounts
    {
        public Vendor()
        {
            //Retain Vendor as discriminator  in case of  derived types must have the same MemberType 
            MemberType = nameof(Vendor);
        }
        /// <summary>
        /// Vendor description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Vendor site url
        /// </summary>
        public string SiteUrl { get; set; }

        /// <summary>
        /// Vendor logo url
        /// </summary>
        public string LogoUrl { get; set; }

        /// <summary>
        /// Vendor group
        /// </summary>
        public string GroupName { get; set; }

        #region IHasSecurityAccounts Members

        /// <summary>
        /// All security accounts associated with this vendor
        /// </summary>
        public ICollection<ApplicationUser> SecurityAccounts { get; set; } = new List<ApplicationUser>();

        #endregion


        public override string ObjectType => typeof(Vendor).FullName;

    }
}