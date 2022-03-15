using Centisoft.Application.Contracts.Persistence;
using Centisoft.Domain.Common;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands.DeleteCompany
{
    public class DeleteCompanyCommandHandler : ICommandHandler<DeleteCompanyCommand>
    {
        private ICompanyRepository companyRepository;
        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
        }
        public async Task<Result> Handle(DeleteCompanyCommand command, CancellationToken cancellationToken = default)
        {
            Ensure.That(command).IsNotNull();
            await Task.Run(()=>companyRepository.DeleteAsync(command.CompanyId));
            return Result.Ok();
        }
    }
}
