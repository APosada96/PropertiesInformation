using AutoMapper;
using PropertiesInformation.Application.Mappings.PropertyImages;
using PropertiesInformation.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Application.Mappings.PropertyTraces
{
    /// <summary>
    /// <see cref="PropertyTraceProfile"/>
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    [ExcludeFromCodeCoverage]
    internal class PropertyTraceProfile:Profile
    {
        public PropertyTraceProfile()
        {
            CreateMap<PropertyTrace, PropertyTraceProfileDto>().ReverseMap();
        }
    }
}
