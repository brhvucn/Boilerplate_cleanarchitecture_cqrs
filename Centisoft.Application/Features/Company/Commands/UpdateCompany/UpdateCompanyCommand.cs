using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : ICommand
    {
        public UpdateCompanyCommand(int companyId, string name, string street, string city, string zipcode, string email)
        {
            CompanyId = companyId;
            Name = name;
            Street = street;
            City = city;
            ZipCode = zipcode;
            Email = email;
        }
        public int CompanyId { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Email { get; private set; }
    }
}
