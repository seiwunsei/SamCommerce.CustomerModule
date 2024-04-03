using SamCommerce.Platform.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Models
{
    public class MemberDynamicPropertyObjectValueEntity : DynamicPropertyObjectValueEntity
    {
        public virtual MemberEntity Member { get; set; }
    }
}
