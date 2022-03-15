using Centisoft.Application.Contracts.Persistence;
using Centisoft.Domain.Common;
using Centisoft.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommandHandler : ICommandHandler<UpdateCompanyCommand>
    {
        private ICompanyRepository companyRepository;
        public UpdateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<Result> Handle(UpdateCompanyCommand command, CancellationToken cancellationToken = default)
        {
            var addressResult = Address.Create(command.Street, command.City, command.ZipCode);
            if (addressResult.Failure) return Result.Fail(addressResult.Error);
            var emailResult = Email.Create(command.Email);
            if(emailResult.Failure) return Result.Fail(emailResult.Error);
            //create the company
            Domain.AggregateRoots.Company company = new Domain.AggregateRoots.Company(command.CompanyId, command.Name, addressResult.Value, emailResult.Value);
            await Task.Run(()=>this.companyRepository.UpdateAsync(company));
            return Result.Ok();
        }
    }
}
