using Centisoft.Application.DomainEvents.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.DomainEvents
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EventDispatcher> _logger;

        public EventDispatcher(IServiceProvider serviceProvider, ILogger<EventDispatcher> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task DispatchAsync(IDomainEvent domainEvent)
        {
            this._logger.LogDebug($"Dispatching event: {0}", domainEvent.GetType().Name);
            // Create a new scope to resolve scoped services, ensuring they are correctly managed and disposed.
            using (var scope = _serviceProvider.CreateScope())
            {
                var scopedServiceProvider = scope.ServiceProvider;
                var handlerType = typeof(IEventHandler<>).MakeGenericType(domainEvent.GetType());
                var handlers = (IEnumerable<dynamic>)scopedServiceProvider.GetServices(handlerType);

                foreach (var handler in handlers)
                {
                    try
                    {
                        await handler.HandleAsync((dynamic)domainEvent);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, $"Error handling event: {domainEvent.GetType().Name}");
                    }
                }
            }
        }
    }
}
