using Centisoft.Application.Features.Company.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Queries.GetAllCompanies
{
    public class GetAllCompaniesQuery : IRequest<List<CompanyDto>>
    {
        //does not require any properties, since it is loading all companies
    }
}
