using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using PropertiesInformation.Domain.Interfaces.User;
using PropertiesInformation.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesInformation.Repositories.Repository
{
    public class UserRepository: IUserRepository
    {
        private readonly IConfiguration _configuration;
        private readonly PropertyDbContext _context;
        public UserRepository(IConfiguration _configuration, PropertyDbContext context)
        {
           this._configuration = _configuration;
            this._context = context;
        }

        public async Task<bool> ValidateUser(UserDto userDto)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userDto.UserName && x.Password == userDto.Password);
        }

        public async Task<GetTokenDto> GenerateToken(UserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]!);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.NameIdentifier, userDto.UserName!),
            new Claim(ClaimTypes.Role, "Admin"),
                  
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"], // Add this line
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var result = tokenHandler.WriteToken(token);
            return await Task.FromResult(new GetTokenDto { Token = result });
        }
    }
}
