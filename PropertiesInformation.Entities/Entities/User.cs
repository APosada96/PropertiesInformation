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
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
