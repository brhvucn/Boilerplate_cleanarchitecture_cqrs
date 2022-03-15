using Centisoft.Domain.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands
{
    public class CreateCompanyRequest
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public class Validator : AbstractValidator<CreateCompanyRequest>
        {
            public Validator()
            {
                RuleFor(r => r.Email).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Email)).Code);
                RuleFor(r => r.Email).EmailAddress().WithMessage(Errors.General.UnexpectedValue(nameof(Email)).Code);
                RuleFor(r=>r.Name).NotEmpty().WithMessage(Errors.General.ValueIsRequired(nameof(Name)).Code);
                RuleFor(r=>r.Street).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(Street)).Code);
                RuleFor(r=>r.City).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(City)).Code);
                RuleFor(r=>r.ZipCode).NotEmpty().WithMessage(Errors.General.UnexpectedValue(nameof(ZipCode)).Code);
            }
        }
    }
}
