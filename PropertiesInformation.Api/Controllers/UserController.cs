using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Interfaces.User;

namespace PropertiesInformation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
           this._userRepository = userRepository;
        }

        [HttpPost("GetToken")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Token([FromBody] UserDto userDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                if (!await _userRepository.ValidateUser(userDto))
                {
                    return Unauthorized();
                }

                return Ok(await _userRepository.GenerateToken(userDto));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
