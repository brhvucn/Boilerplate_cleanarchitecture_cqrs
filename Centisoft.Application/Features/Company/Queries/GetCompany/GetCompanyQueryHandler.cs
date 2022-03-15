using AutoMapper;
using Centisoft.Application.Contracts.Persistence;
using Centisoft.Application.Features.Company.Dto;
using Centisoft.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Queries.GetCompany
{
    public class GetCompanyQueryHandler : IQueryHandler<GetCompanyQuery, CompanyDto>
    {
        private IMapper mapper;
        private ICompanyRepository companyRepository;
        public GetCompanyQueryHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this.mapper = mapper;
            this.companyRepository = companyRepository;
        }

        public async Task<Result<CompanyDto>> Handle(GetCompanyQuery query, CancellationToken cancellationToken = default)
        {
            var company = await this.companyRepository.GetByIdAsync(query.CompanyId);
            var companyDto = this.mapper.Map<CompanyDto>(company);
            return Result.Ok(companyDto);
        }
    }
}
