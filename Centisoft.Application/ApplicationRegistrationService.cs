using Centisoft.Application.DomainEvents;
using Centisoft.Application.DomainEvents.CompanyCreated;
using Centisoft.Application.DomainEvents.Contracts;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<IDispatcher>(sp=> new Dispatcher(sp.GetService<IMediator>()));
            //domain events - customer
            services.AddSingleton<IEventDispatcher, EventDispatcher>();
            services.AddScoped<IEventHandler<CompanyCreatedEvent>, CompanyCreatedSendEmailEventHandler>();
            services.AddScoped<IEventHandler<CompanyCreatedEvent>, CompanyCreatedSendWebhookEventHandler>();

            return services;
        }
    }
}
