using Microsoft.Extensions.Primitives;
using SamCommerce.Platform.Core.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamCommerce.CustomerModule.Data.Caching
{
    public class CustomerCacheRegion : CancellableCacheRegion<CustomerCacheRegion>
    {
        public static IChangeToken CreateChangeToken(string[] memberIds)
        {
            if (memberIds == null)
            {
                throw new ArgumentNullException(nameof(memberIds));
            }
            var changeTokens = new List<IChangeToken>() { CreateChangeToken() };
            foreach (var memberId in memberIds)
            {
                changeTokens.Add(CreateChangeTokenForKey(memberId));
            }
            return new CompositeChangeToken(changeTokens);
        }

        public static void ExpireMemberById(string memberId)
        {
            ExpireTokenForKey(memberId);
        }
    }
}
