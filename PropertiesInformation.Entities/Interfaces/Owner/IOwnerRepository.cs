using PropertiesInformation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Interfaces.Owner
{
    public interface IOwnerRepository
    {
        Task<int> AddOwner(OwnerDto ownerDto);
        Task<int> DeleteOwner(int id);
    }
}
