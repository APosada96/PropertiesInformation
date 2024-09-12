using PropertiesInformation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Interfaces.Properties
{
    public interface IPropertyRepository
    {
        Task<List<PropertyListDto>> Get(PropertyDto propertyDto);
        Task<int> AddProperty(PropertyDto propertyDto);

        Task<int> UpdateProperty(PropertyUpdateDto propertyDto);

        Task<int> ChangePrice(ChangePriceDto changePriceDto);
    }
}
