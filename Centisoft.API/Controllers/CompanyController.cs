using AutoMapper;
using Centisoft.API.Utilities;
using Centisoft.Application.Features.Company.Dto;
using Centisoft.Application.Features.Company.Queries.GetAllCompanies;
using Centisoft.Application.Features.Company.Queries.GetCompany;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centisoft.API.Controllers
{
    [Route("api/companies")]
    [ApiController]
    public class CompanyController : BaseController
    {
        private IMapper mapper;
        private IMediator mediator;
        public CompanyController(IMapper mapper, IMediator mediator)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<CompanyDto>>> GetCompanies()
        {
            GetAllCompaniesQuery query = new GetAllCompaniesQuery();
            var result = await this.mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var result = await this.mediator.Send(new GetCompanyQuery(id));
            return Ok(result);
        }
    }
}
