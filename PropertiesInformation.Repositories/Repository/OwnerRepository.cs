using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using PropertiesInformation.Domain.Interfaces.Owner;
using PropertiesInformation.Domain.Interfaces.Storage;
using PropertiesInformation.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Repositories.Repository
{
    public class OwnerRepository:IOwnerRepository
    {
        private readonly PropertyDbContext _context;
        private static readonly string container = "Owner";
        private readonly IFileStorageRepository _fileStorage;
        private readonly IMapper _mapper;
        public OwnerRepository(PropertyDbContext context, IFileStorageRepository _fileStorage, IMapper mapper)
        {
            this._context = context;
            this._fileStorage = _fileStorage;
            this._mapper = mapper;
        }

        public async Task<int> AddOwner(OwnerDto ownerDto)
        {
            try
            {
                var Owner = _mapper.Map<Owner>(ownerDto);
                if (ownerDto.Photo is not null)
                {
                    var url = await _fileStorage.Store(container, ownerDto.Photo);
                    Owner.Photo = url;
                }

                _context.Owners.Add(Owner);
                await _context.SaveChangesAsync();
                return Owner.IdOwner!;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }

        }

        public async Task<int> DeleteOwner(int id)
        {
            try
            {
                var owner = await _context.Owners.FirstOrDefaultAsync(x => x.IdOwner == id);

                if (owner == null) throw new ArgumentNullException($"The Owner {id} not exist.");

                _context.Owners.Remove(owner);
                await _context.SaveChangesAsync();
                return owner.IdOwner!;
            }
            catch (ArgumentNullException)
            {
                throw;
            }
           
        }
        private bool OwnerExists(int id)
        {
            return _context.Owners.Any(e => e.IdOwner == id);
        }
    }
}
