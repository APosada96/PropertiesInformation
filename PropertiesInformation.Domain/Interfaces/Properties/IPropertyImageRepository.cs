using PropertiesInformation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Interfaces.Properties
{
    public interface IPropertyImageRepository
    {
        Task<string> AddImage(PropertyImageDto propertyImageDto);

        Task<int> DeleteFile(int id);
    }
}
