using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Model
{
    public class Note
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public string OuterId { get; set; }

        #region ICloneable members

        public virtual object Clone()
        {
            return MemberwiseClone() as Note;
        }

        #endregion
    }
}
