using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Dtos
{
    public class PropertyDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double Price { get; set; }
        public string? Code { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
    }
}
