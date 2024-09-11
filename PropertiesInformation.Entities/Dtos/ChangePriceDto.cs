using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Dtos
{
    public class ChangePriceDto
    {
        public int IdProperty { get; set; }
        public double Price { get; set; }
    }
}
