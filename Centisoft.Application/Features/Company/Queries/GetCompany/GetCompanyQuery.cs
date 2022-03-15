using Centisoft.Application.Features.Company.Dto;
using EnsureThat;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Queries.GetCompany
{
    public class GetCompanyQuery : IQuery<CompanyDto>
    {
        public GetCompanyQuery(int companyId)
        {
            Ensure.That(companyId, nameof(companyId)).IsGt(0);            
            CompanyId = companyId;
        }
        public int CompanyId { get; private set; }
    }
}
