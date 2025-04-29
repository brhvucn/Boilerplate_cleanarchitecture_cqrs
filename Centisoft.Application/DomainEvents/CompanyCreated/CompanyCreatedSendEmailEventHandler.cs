using Centisoft.Application.DomainEvents.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.DomainEvents.CompanyCreated
{
    public class CompanyCreatedSendEmailEventHandler : IEventHandler<CompanyCreatedEvent>
    {
        private ILogger<CompanyCreatedSendEmailEventHandler> logger;
        public CompanyCreatedSendEmailEventHandler(ILogger<CompanyCreatedSendEmailEventHandler> logger)
        {
            this.logger = logger;
        }

        public Task HandleAsync(CompanyCreatedEvent domainEvent)
        {
            // Send email logic here
            this.logger.LogInformation($"Email sent to {domainEvent.Company.Email} for company {domainEvent.Company.Name} creation.");
            return Task.CompletedTask;
        }
    }
}
