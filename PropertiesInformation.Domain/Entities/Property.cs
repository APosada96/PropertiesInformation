using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PropertiesInformation.Domain.Entities
{
    [ExcludeFromCodeCoverage]
    public class Property
    {
        [Key]
        public int IdProperty { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public double Price { get; set; }
        public string? Code { get; set; }
        public int Year { get; set; }
        public int IdOwner { get; set; }
        public Owner? Owner { get; set; }
        public ICollection<PropertyImage>? PropertyImages { get; set; }
        public ICollection<PropertyTrace>? PropertyTraces { get; set; }
    }
}
