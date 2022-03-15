using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : ICommand
    {
        public DeleteCompanyCommand(int companyId)
        {
            Ensure.That(companyId).IsGt(0);
            CompanyId = companyId;
        }
        public int CompanyId { get; set; }
    }
}
