using Centisoft.Domain.Common;
using EnsureThat;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application
{
    public class Dispatcher : IDispatcher
    {
        public Dispatcher(IMediator mediator)
        {
            Mediator = Ensure.Any.IsNotNull(mediator, nameof(mediator));
        }

        public IMediator Mediator { get; }

        public Task<Result<T>> Dispatch<T>(IQuery<T> query)
        {
            Ensure.Any.IsNotNull(query, nameof(query));

            return Mediator.Send(query);
        }

        public Task<Result> Dispatch(ICommand command)
        {
            Ensure.Any.IsNotNull(command, nameof(command));

            return Mediator.Send(command);
        }
    }
}
