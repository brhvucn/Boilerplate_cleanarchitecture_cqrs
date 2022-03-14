using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centisoft.Application.Features.Company.Dto
{
    public class CompanyDto
    {        
        public CompanyDto(int id, string name, string street, string city, string zip, string email)
        {
            Id = id;   
            Name = name;
            Street = street;
            City = city;
            Email = email;
            ZipCode = zip;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string City { get; private set; }
        public string ZipCode { get; private set; }
        public string Email { get; private set; }
    }
}
