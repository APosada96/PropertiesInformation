using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Interfaces.Owner;

namespace PropertiesInformation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;
        public OwnersController(IOwnerRepository ownerRepository)
        {
            this._ownerRepository = ownerRepository;     
        }

        [HttpPost("AddOwner")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(OwnerDto ownerDto)
        {
            try
            {

                return Ok(await _ownerRepository.AddOwner(ownerDto));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeleteOwner")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                return Ok(await _ownerRepository.DeleteOwner(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
