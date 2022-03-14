using Centisoft.Domain.Common;
using Centisoft.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Domain.AggregateRoots
{
    public class Company : AggregateRoot
    {
        public string Name { get; set; }    
        public Address Address { get; set; }
        public Email Email { get; set; }
    }
}
