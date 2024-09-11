using AutoMapper;
using PropertiesInformation.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Application.Mappings.Owners
{
    /// <summary>
    /// <see cref="OwnerProfile"/>
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    [ExcludeFromCodeCoverage]
    internal class OwnerProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OwnerProfile"/> class.
        /// </summary>
        public OwnerProfile()
        {
            CreateMap<Owner, OwnerDto>().ReverseMap();
        }
    }
}
