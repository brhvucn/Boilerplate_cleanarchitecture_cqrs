using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application
{
    public class CollectionResponseBase<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}
