using SamCommerce.Platform.Core.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Models
{
    public class FavoriteAddressEntity : Entity
    {
        [Required]
        [StringLength(128)]
        public string UserId { get; set; }

        public string AddressId { get; set; }
        public AddressEntity Address { get; set; }
    }
}
