using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Owner
    {
       [Key]
        public int IdOwner { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Photo { get; set; }
        public DateTime BirthDay { get; set; }
        public ICollection<Property>? Properties { get; set; }

    }
}
