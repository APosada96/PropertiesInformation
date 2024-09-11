using PropertiesInformation.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Domain.Interfaces.User
{
    public interface IUserRepository
    {
        Task<GetTokenDto> GenerateToken(UserDto userDto);

        Task<bool> ValidateUser(UserDto userDto);
    }
}
