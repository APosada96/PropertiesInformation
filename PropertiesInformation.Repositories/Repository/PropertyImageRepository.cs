using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using PropertiesInformation.Domain.Interfaces.Properties;
using PropertiesInformation.Domain.Interfaces.Storage;
using PropertiesInformation.Infrastructure.DBContext;


namespace PropertiesInformation.Repositories.Repository
{
    public class PropertyImageRepository: IPropertyImageRepository
    {
        private readonly PropertyDbContext _context;
        private static readonly string container = "FeatureProperty";
        private readonly IFileStorageRepository _fileStorage;
        private readonly IMapper _mapper;
        public PropertyImageRepository(PropertyDbContext context, IFileStorageRepository _fileStorage, IMapper mapper)
        {
            this._context = context;
            this._fileStorage = _fileStorage;
            this._mapper = mapper;  
        }

        public async Task<string> AddImage(PropertyImageDto propertyImageDto)
        {
            try
            {
                var property = await _context.Properties.FirstOrDefaultAsync(x => x.IdProperty == propertyImageDto.IdProperty);

                if (property is null) throw new ArgumentNullException($"The Property {propertyImageDto.IdProperty} not exist.");

                var propertyImage = _mapper.Map<PropertyImage>(propertyImageDto);
                if (propertyImageDto.File is not null)
                {
                    var url = await _fileStorage.Store(container, propertyImageDto.File);
                    propertyImage.File = url;
                }

                propertyImage.IdProperty = propertyImageDto.IdProperty;
                _context.PropertyImages.Add(propertyImage);
                await _context.SaveChangesAsync();
                return propertyImage.File!;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            
        }

        public async Task<int> DeleteFile(int id)
        {
            try
            {
                var image = await _context.PropertyImages.FirstOrDefaultAsync(x => x.IdPropertyImage == id);

                if (image == null) throw new ArgumentNullException($"The Owner {id} not exist.");

                _context.PropertyImages.Remove(image);
                await _context.SaveChangesAsync();
                return image.IdPropertyImage!;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
        }
    }
}
