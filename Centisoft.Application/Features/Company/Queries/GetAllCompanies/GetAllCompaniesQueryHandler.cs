using AutoMapper;
using Centisoft.Application.Contracts.Persistence;
using Centisoft.Application.Features.Company.Dto;
using Centisoft.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Queries.GetAllCompanies
{
    public class GetAllCompaniesQueryHandler : IQueryHandler<GetAllCompaniesQuery, CollectionResponseBase<CompanyDto>>
    {
        private ICompanyRepository companyRepository;
        private IMapper mapper;
        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<Result<CollectionResponseBase<CompanyDto>>> Handle(GetAllCompaniesQuery query, CancellationToken cancellationToken = default)
        {
            List<CompanyDto> result = new List<CompanyDto>();
            var companies = await this.companyRepository.GetAllAsync();
            foreach (var company in companies)
            {
                var mappedCompany = mapper.Map<CompanyDto>(company);
                //handle the contacts
                foreach (var contact in company.Contacts)
                {
                    var mappedContact = mapper.Map<ContactDto>(contact);
                }
                result.Add(mappedCompany);
            }
            return new CollectionResponseBase<CompanyDto>()
            {
                Data = result
            };
        }        
    }
}
