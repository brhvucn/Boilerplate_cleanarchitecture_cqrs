using Centisoft.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application
{
    public interface IQuery<T> : IRequest<Result<T>>
    {

    }
}
