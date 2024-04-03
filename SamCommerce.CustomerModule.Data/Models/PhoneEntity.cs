﻿using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Models
{
    public class PhoneEntity : Entity
    {
        [StringLength(64)]
        public string Number { get; set; }

        [StringLength(64)]
        public string Type { get; set; }

        #region Navigation Properties

        public string MemberId { get; set; }
        public virtual MemberEntity Member { get; set; }

        #endregion
    }
}