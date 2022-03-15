using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands.CreateCompany
{
    public class CreateCompanyValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Email).EmailAddress();
            RuleFor(x=>x.Street).NotEmpty();
            RuleFor(x=>x.City).NotEmpty();
            RuleFor(x=>x.ZipCode).NotEmpty();
        }
    }
}
