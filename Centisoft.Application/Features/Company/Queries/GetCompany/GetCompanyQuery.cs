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
    public class GetCompanyQuery : IRequest<CompanyDto>
    {
        public GetCompanyQuery(int companyId)
        {
            this.CompanyId = Ensure.That(companyId, nameof(companyId)).IsGt(0).Value;            
        }
        public int CompanyId { get; private set; }
    }
}
