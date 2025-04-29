using Centisoft.Application.DomainEvents.Contracts;
using Centisoft.Domain.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.DomainEvents.CompanyCreated
{
    /// <summary>
    /// Represents a domain event that is triggered when a company is created.
    /// </summary>
    public class CompanyCreatedEvent : IDomainEvent
    {
        public Company Company { get; }
        public CompanyCreatedEvent(Company company)
        {
            Company = company;
        }
    }
}
