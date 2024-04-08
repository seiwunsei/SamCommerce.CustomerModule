﻿using SamCommerce.Platform.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Model
{
    public class Employee : Member, IHasSecurityAccounts, IHasPersonName
    {
        public Employee()
        {
            //Retain Employee as discriminator  in case of  derived types must have the same MemberType 
            MemberType = nameof(Employee);
        }
        public string Salutation { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
        public string DefaultLanguage { get; set; }
        public string TimeZone { get; set; }
        public IList<string> Organizations { get; set; }

        /// <summary>
        /// Employee type
        /// </summary>
        public string EmployeeType { get; set; }

        /// <summary>
        /// Employee activity flag
        /// </summary>
        public bool IsActive { get; set; }

        public string PhotoUrl { get; set; }

        public override string ObjectType => typeof(Employee).FullName;

        #region IHasSecurityAccounts Members

        /// <summary>
        /// All security accounts associated with this employee
        /// </summary>
        public ICollection<ApplicationUser> SecurityAccounts { get; set; } = new List<ApplicationUser>();

        #endregion
    }
}
