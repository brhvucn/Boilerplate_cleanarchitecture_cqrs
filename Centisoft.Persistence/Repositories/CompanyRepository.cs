using Centisoft.Application.Contracts.Persistence;
using Centisoft.Domain.AggregateRoots;
using Centisoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Persistence.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task<int> AddAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Company>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
