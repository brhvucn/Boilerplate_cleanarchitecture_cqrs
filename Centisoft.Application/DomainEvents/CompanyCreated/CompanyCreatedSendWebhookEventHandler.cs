using Centisoft.Application.DomainEvents.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.DomainEvents.CompanyCreated
{
    public class CompanyCreatedSendWebhookEventHandler : IEventHandler<CompanyCreatedEvent>
    {
        private ILogger<CompanyCreatedSendWebhookEventHandler> logger;
        public CompanyCreatedSendWebhookEventHandler(ILogger<CompanyCreatedSendWebhookEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task HandleAsync(CompanyCreatedEvent domainEvent)
        {
            // Send webhook logic here
            this.logger.LogInformation($"Webhook sent for company {domainEvent.Company.Name} creation.");
            return Task.CompletedTask;
        }
    }
}
