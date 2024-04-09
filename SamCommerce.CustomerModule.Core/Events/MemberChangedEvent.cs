using SamCommerce.CustomerModule.Core.Model;
using SamCommerce.Platform.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Core.Events
{
    public class MemberChangedEvent : GenericChangedEntryEvent<Member>
    {
        public MemberChangedEvent(IEnumerable<GenericChangedEntry<Member>> changedEntries)
            : base(changedEntries)
        {
        }
    }
}
