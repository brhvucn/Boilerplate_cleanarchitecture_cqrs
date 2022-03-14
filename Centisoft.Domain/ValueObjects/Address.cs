using Centisoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public string  Street { get; set; }
        public string City { get; set; }    
        public string ZipCode { get; set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return ZipCode;  
        }
    }
}
