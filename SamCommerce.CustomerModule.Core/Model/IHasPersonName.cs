using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Model
{
    public interface IHasPersonName
    {
        string FirstName { get; set; }

        string LastName { get; set; }

        string FullName { get; set; }
    }
}
