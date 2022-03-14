using Centisoft.Application.Contracts.Persistence;
using Centisoft.Domain.AggregateRoots;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
    }
}
