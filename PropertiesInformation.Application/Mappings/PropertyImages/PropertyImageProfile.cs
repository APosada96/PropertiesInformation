using AutoMapper;
using PropertiesInformation.Application.Mappings.Properties;
using PropertiesInformation.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Application.Mappings.PropertyImages
{
    /// <summary>
    /// <see cref="PropertyImageProfile"/>
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    [ExcludeFromCodeCoverage]
    internal class PropertyImageProfile: Profile
    {
        public PropertyImageProfile()
        {
            CreateMap<PropertyImage, PropertyImageProfileDto>().ReverseMap();
        }
    }
}
