using Centisoft.Domain.Common;
using Centisoft.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Domain.Entities
{
    public class Contact : Entity
    {
        public string Name { get; private set; }
        public Email Email { get; set; }
    }
}
