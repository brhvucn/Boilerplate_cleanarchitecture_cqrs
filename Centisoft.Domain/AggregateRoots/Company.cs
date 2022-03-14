using Centisoft.Domain.Common;
using Centisoft.Domain.Entities;
using Centisoft.Domain.ValueObjects;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Domain.AggregateRoots
{
    public class Company : AggregateRoot
    {
        public Company(string name, Address address, Email email)
        {
            //Address and Email cannot be invalid, so no guard check
            Ensure.That(name, nameof(name)).IsNotNullOrEmpty();
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Contacts = new List<Contact>();
        }

        public Company() { } //for ORM

        public string Name { get; set; }    
        public Address Address { get; set; }
        public Email Email { get; set; }

        public List<Contact> Contacts { get; private set; }
    }
}
