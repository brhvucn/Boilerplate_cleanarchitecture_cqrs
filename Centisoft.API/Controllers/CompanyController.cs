using AutoMapper;
using Centisoft.Application.Features.Company.Dto;
using Centisoft.Application.Features.Company.Queries.GetAllCompanies;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Centisoft.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private IMapper mapper;
        private IMediator mediator;
        public CompanyController(IMapper mapper, IMediator mediator)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<CompanyDto>> GetCompanies()
        {
            GetAllCompaniesQuery query = new GetAllCompaniesQuery();
            return await this.mediator.Send(query);
        }
    }
}
