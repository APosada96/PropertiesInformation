using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Interfaces.Owner;
using PropertiesInformation.Domain.Interfaces.Properties;

namespace PropertiesInformation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyTraceController : ControllerBase
    {
        private readonly IPropertyTraceRepository _PropertyTraceRepository;
        public PropertyTraceController(IPropertyTraceRepository PropertyTraceRepository)
        {
            this._PropertyTraceRepository = PropertyTraceRepository;
        }

        [HttpPost("AddPropertyTrace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post([FromBody]PropertyTraceDto propertyTraceDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                return Ok(await _PropertyTraceRepository.AddPropertyTrace(propertyTraceDto));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeletePropertyTrace")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                return Ok(await _PropertyTraceRepository.DeletePropertyTrace(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
