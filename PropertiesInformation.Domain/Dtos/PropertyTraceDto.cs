using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Dtos
{
    public class PropertyTraceDto
    {
        public DateTime DateSale { get; set; }
        public string? Name { get; set; }
        public double Value { get; set; }
        public double Tax { get; set; }
        public int IdProperty { get; set; }
    }
}
