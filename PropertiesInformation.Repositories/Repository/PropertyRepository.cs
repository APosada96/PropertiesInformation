using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using PropertiesInformation.Domain.Interfaces.Properties;
using PropertiesInformation.Infrastructure.DBContext;


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

        public async Task<List<PropertyListDto>> Get(PropertyDto propertyDto)
        {
            if (await ValidateProperties(propertyDto) == 0)
            {
                var queryAll =await _context.Properties
                           .Include(c => c.PropertyImages)
                           .Include(c => c.PropertyTraces)
                           .ToListAsync();

                return _mapper.Map<List<PropertyListDto>>(queryAll);
            }

            var query = _context.Properties
            .Include(c => c.PropertyImages)
            .Include(c => c.PropertyTraces)
            .Where(t => ((propertyDto.Name != null || !string.IsNullOrEmpty(propertyDto.Name)) && t.Name.Contains(propertyDto.Name))
                     || ((propertyDto.Address != null || !string.IsNullOrEmpty(propertyDto.Address)) && t.Address.Contains(propertyDto.Address))
                     || ((propertyDto.Price != null || propertyDto.Price != 0) && t.Price == propertyDto.Price)
                     || ((propertyDto.Code != null || !string.IsNullOrEmpty(propertyDto.Code)) && t.Code.Contains(propertyDto.Code))
                     || ((propertyDto.Year != null || propertyDto.Year != 0) && t.Year == propertyDto.Year)
                     || ((propertyDto.IdOwner != null || propertyDto.IdOwner != 0) && t.IdOwner == propertyDto.IdOwner));

            var result = query.ToList();

            return  _mapper.Map<List<PropertyListDto>>(result);
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

        public async Task<int> ChangePrice(ChangePriceDto changePriceDto)
        {
            try
            {
                var property = await _context.Properties.FirstOrDefaultAsync(x => x.IdProperty == changePriceDto.IdProperty);
                if (property is null) throw new ArgumentNullException($"The property {changePriceDto.IdProperty} not exist.");

                property.Price = changePriceDto.Price;
                await _context.SaveChangesAsync();
                return property.IdProperty;
            }
            catch (ArgumentNullException)
            {

                throw;
            }
          
        }

        private async Task<int> ValidateProperties(PropertyDto propertyDto)
        {
            int count = 0;
            if (propertyDto == null) return await Task.FromResult(0);

            var properties = propertyDto.GetType().GetProperties(); 

            foreach (var property in properties)
            { 
                var value = property.GetValue(propertyDto);
                if (value == null) continue;

                if (property.PropertyType == typeof(double) || property.PropertyType == typeof(int))
                {
                    if (Convert.ToInt16(value) != 0)
                    {
                        count++;
                        break;
                    }
                    continue;
                }
                if (value != null || !string.IsNullOrEmpty(value.ToString()))
                { 
                    count++;
                    break;
                }
            }

            return await Task.FromResult(count);
        }
    }
}
