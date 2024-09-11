using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class PropertyImage
    {
        [Key]
        public int IdPropertyImage { get; set; }
        public string? File { get; set; }
        public bool Enabled { get; set; }
        public int IdProperty { get; set; }
        [JsonIgnore]
        public Property? Property { get; set; }
    }
}
