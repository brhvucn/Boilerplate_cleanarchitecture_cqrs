using Centisoft.Application.Contracts.Persistence;
using Centisoft.Domain.Common;
using Centisoft.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands
{
    public class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
    {
        private ICompanyRepository companyRepository;
        public CreateCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public async Task<Result> Handle(CreateCompanyCommand command, CancellationToken cancellationToken = default)
        {
            //create the address
            Result<Address> addressResult = Address.Create(command.Street, command.City, command.ZipCode);
            if (addressResult.Failure) return addressResult;
            Result<Email> emailResult = Email.Create(command.Email);
            if (emailResult.Failure) return emailResult;

            var company = new Domain.AggregateRoots.Company(command.Name, addressResult.Value, emailResult.Value);
            var companyId = await this.companyRepository.AddAsync(company);
            return Result.Ok(companyId);
        }        
    }
}
