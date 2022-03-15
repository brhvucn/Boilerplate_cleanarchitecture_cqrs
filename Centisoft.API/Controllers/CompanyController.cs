using AutoMapper;
using Centisoft.API.Utilities;
using Centisoft.Application;
using Centisoft.Application.Features.Company.Commands.CreateCompany;
using Centisoft.Application.Features.Company.Commands.DeleteCompany;
using Centisoft.Application.Features.Company.Dto;
using Centisoft.Application.Features.Company.Queries.GetAllCompanies;
using Centisoft.Application.Features.Company.Queries.GetCompany;
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
        private IDispatcher dispatcher;
        public CompanyController(IMapper mapper, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            GetAllCompaniesQuery query = new GetAllCompaniesQuery();
            var result = await this.dispatcher.Dispatch(query);
            return FromResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> SaveCompany(CreateCompanyRequest companyRequest)
        {
            CreateCompanyCommand command = new CreateCompanyCommand(
                companyRequest.Name,
                companyRequest.Street,
                companyRequest.City,
                companyRequest.ZipCode,
                companyRequest.Email);           
            var result = await this.dispatcher.Dispatch(command);
            return FromResult(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCompany(int id)
        {
            var result = await this.dispatcher.Dispatch(new GetCompanyQuery(id));
            return FromResult(result);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            var result = await this.dispatcher.Dispatch(new DeleteCompanyCommand(id));
            return FromResult(result);
        }
    }
}
