using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Models
{
    public class MemberGroupEntity : Entity
    {
        [StringLength(64)]
        public string Group { get; set; }

        #region Navigation Properties

        public string MemberId { get; set; }
        public virtual MemberEntity Member { get; set; }

        #endregion
    }
}
