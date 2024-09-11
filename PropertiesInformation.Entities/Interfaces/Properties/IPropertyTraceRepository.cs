using PropertiesInformation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Interfaces.Properties
{
    public interface  IPropertyTraceRepository
    {
        Task<int> AddPropertyTrace(PropertyTraceDto propertyTrace);
        Task<int> DeletePropertyTrace(int id);
    }
}
