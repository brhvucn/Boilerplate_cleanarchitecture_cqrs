﻿using Centisoft.Domain.Common;
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
        public Company(int id, string name, Address address, Email email)
        {
            //Address and Email cannot be invalid, so no guard check
            Ensure.That(name, nameof(name)).IsNotNullOrEmpty();
            Ensure.That(address, nameof(address)).IsNotNull();
            Ensure.That(email, nameof(email)).IsNotNull();
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Email = email;
            this.Contacts = new List<Contact>();
        }
        public Company(string name, Address address, Email email) : this(0, name, address, email)
        {
            
        }

        public void AddContact(Contact contact)
        {
            Ensure.That(contact, nameof(contact)).IsNotNull();
            this.Contacts.Add(contact);
        }

        public Company() 
        {
            this.Contacts = new List<Contact>();
        } //for ORM

        public string Name { get; set; }    
        public Address Address { get; set; }
        public Email Email { get; set; }

        public List<Contact> Contacts { get; private set; }
    }
}
