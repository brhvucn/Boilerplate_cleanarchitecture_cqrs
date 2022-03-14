using AutoMapper;
using Centisoft.Application.Contracts.Persistence;
using Centisoft.Application.Features.Company.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
    {
        private IMapper mapper;
        private ICompanyRepository companyRepository;
        public GetCompanyQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            var company = await this.companyRepository.GetByIdAsync(request.CompanyId);
            var companyDto = this.mapper.Map<CompanyDto>(company);
            return companyDto;
        }
    }
}
