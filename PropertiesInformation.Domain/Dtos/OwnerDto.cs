using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Dtos
{
    public class OwnerDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public IFormFile? Photo { get; set; }
        public DateTime BirthDay { get; set; }
    }
}
