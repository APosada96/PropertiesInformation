using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using PropertiesInformation.Domain.Interfaces.Properties;
using PropertiesInformation.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Repositories.Repository
{
  
    public class PropertyRepository: IPropertyRepository
    {
        private readonly PropertyDbContext _context;
        private readonly IMapper _mapper;
        public PropertyRepository(PropertyDbContext context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<PropertyListDto>> Get()
        {
            var properties =await _context.Properties.Include(x => x.PropertyTraces).
                                                      Include(x => x.PropertyImages)
                                                      .AsNoTracking()
                                                      .OrderBy(x => x.Name).AsSingleQuery().ToListAsync();
            return  _mapper.Map<List<PropertyListDto>>(properties);
        }

        public async Task<int> AddProperty(PropertyDto propertyDto)
        {
            try
            {
                var owner = await _context.Owners.FirstOrDefaultAsync(x => x.IdOwner == propertyDto.IdOwner);

                if (owner is null) throw new ArgumentNullException($"The Owner {propertyDto.IdOwner} not exist.");

                var property = _mapper.Map<Property>(propertyDto);
                property.IdOwner = owner.IdOwner;
                _context.Properties.Add(property);
                await _context.SaveChangesAsync();
                return property.IdProperty;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }

        public async Task<int> UpdateProperty(PropertyUpdateDto propertyDto)
        {
            try
            {
                var property = await _context.Properties.FirstOrDefaultAsync(x => x.IdProperty == propertyDto.IdProperty);

                if (property is null) throw new ArgumentNullException($"The property {propertyDto.IdOwner} not exist.");

                var owner = await _context.Owners.FirstOrDefaultAsync(x => x.IdOwner == propertyDto.IdOwner);

                if (owner is null) throw new ArgumentNullException($"The Owner {propertyDto.IdOwner} not exist.");

                property.Name = propertyDto.Name;
                property.Address = propertyDto.Address;
                property.Year = propertyDto.Year;
                property.Price = propertyDto.Price;
                property.Code = propertyDto.Code;
                property.Name = propertyDto.Name;

                await _context.SaveChangesAsync();
                return property.IdProperty;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
