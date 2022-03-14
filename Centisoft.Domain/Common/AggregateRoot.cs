using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Domain.Common
{
    public abstract class AggregateRoot<TKey>
         : Entity<TKey> where TKey : struct
    {

    }
}
