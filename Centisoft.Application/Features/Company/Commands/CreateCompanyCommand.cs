using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Commands
{
    public class CreateCompanyCommand : ICommand
    {
        public CreateCompanyCommand(string name, string street, string city, string zipcode, string email)
        {
            Name = name;
            Street = street;
            City = city;
            ZipCode = zipcode;
            Email = email;
        }
        public string Name { get; }
        public string Street { get; }
        public string City { get; }
        public string ZipCode { get; }
        public string Email { get; }        
    }
}
