using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Application.Mappings.Property
{
    /// <summary>
    /// <see cref="PropertyProfile"/>
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    [ExcludeFromCodeCoverage]
    internal class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            //CreateMap<PropertyProfile, PropertyProfileDto>().ReverseMap();
        }
    }
}
