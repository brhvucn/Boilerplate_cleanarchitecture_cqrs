using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.DomainEvents.Contracts
{
    /// <summary>
    /// Responsible for dispatching domain events to all relevant event handlers
    /// </summary>
    public interface IEventDispatcher
    {
        Task DispatchAsync(IDomainEvent domainEvent);
    }
}
