using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Dtos
{
    public class PropertyImageDto
    {
        public IFormFile? File { get; set; }

        public int IdProperty { get; set; }
        public bool Enabled { get; set; }
    }
}
