using Centisoft.Application.Contracts.Persistence;
using Centisoft.Domain.AggregateRoots;
using Centisoft.Domain.Common;
using Centisoft.Domain.ValueObjects;
using Centisoft.Persistence.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Persistence.Repositories
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(DataContext context) : base(TableNames.CompanyTableName, context) { }
        public async Task<int> AddAsync(Company entity)
        {
            using(var connection = dataContext.CreateConnection())
            {
                string query = $"insert into {tableName} (Name, Street, City, ZipCode, Email) OUTPUT INSERTED.Id values (@name, @street, @city, @zipcode, @email)";
                return await connection.QuerySingleAsync<int>(query, new { name = entity.Name, street=entity.Address.Street, city=entity.Address.City, zipcode = entity.Address.ZipCode, email = entity.Email.Value });
            }
        }

        public void DeleteAsync(int id)
        {
            using (var connection = dataContext.CreateConnection())
            {
                string command = $"delete from {tableName} where id = @id";
                connection.Execute(command, new { id });
            }
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            using (var connection = dataContext.CreateConnection())
            {
                List<Company> result = new List<Company>();
                var query = $"select Id, Name from {tableName}";
                var companies = await connection.QueryAsync<Company>(query);
                foreach(var company in companies)
                {
                    company.Address = await GetAddressFromCompanyId(company.Id);
                    company.Email = await GetEmailFromCompanyId(company.Id);
                    result.Add(company);
                }
                return result;
            }
        }

        private async Task<Address> GetAddressFromCompanyId(int companyId)
        {
            using(var connection = dataContext.CreateConnection())
            {
                string query = $"select * from {tableName} where id = @id";
                return await connection.QuerySingleAsync<Address>(query, new { id = companyId });
            }
        }

        private async Task<Email> GetEmailFromCompanyId(int companyId)
        {
            using(var connection = dataContext.CreateConnection())
            {
                string query = $"select Email as Value from {tableName} where id = @id";
                return await connection.QuerySingleAsync<Email>(query, new { id = companyId });
            }
        }

        public async Task<Result<Company>> GetByIdAsync(int id)
        {
            using (var connection = dataContext.CreateConnection())
            {
                string query = $"select Street, City, ZipCode from {tableName} where id = @id";
                return await connection.QuerySingleAsync<Company>(query, new { id });
            }
        }

        /// <summary>
        /// This will only update the values of the aggregate root, not the value objects
        /// </summary>
        /// <param name="entity"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
