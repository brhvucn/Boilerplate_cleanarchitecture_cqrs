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
        public CompanyDto() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Email { get; set; }
    }
}
