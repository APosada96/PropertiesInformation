using PropertiesInformation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Dtos
{
    public class PropertyListDto
    {
        public int IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double Price { get; set; }
        public string? Code { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
       
        public List<PropertyImage>? PropertyImages { get; set; }
        public List<PropertyTrace>? PropertyTraces { get; set; }
    }
}
