using AutoMapper;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Utilities.Automapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PropertyImageDto, PropertyImage>();
            CreateMap<PropertyImage, PropertyImageDto>();
            CreateMap<PropertyDto, Property>();
            CreateMap<Property, PropertyDto>();
            CreateMap<Owner, OwnerDto>();
            CreateMap<OwnerDto, Owner>();
            CreateMap<Property, PropertyListDto>();
            CreateMap<PropertyListDto, Property>();
            CreateMap<PropertyTrace, PropertyTraceDto>();
            CreateMap<PropertyTraceDto, PropertyTrace>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
