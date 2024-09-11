using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PropertiesInformation.Domain.Dtos;
using PropertiesInformation.Domain.Entities;
using PropertiesInformation.Domain.Interfaces.Properties;
using PropertiesInformation.Infrastructure.DBContext;

namespace PropertiesInformation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PropertyImagesController : ControllerBase
    {
        private readonly IPropertyImageRepository _propertyImageRepository;
        public PropertyImagesController(PropertyDbContext context, IPropertyImageRepository propertyImageRepository)
        {
            this._propertyImageRepository = propertyImageRepository;
        }

      
        [HttpPost("AddFile")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PostPropertyImage(PropertyImageDto propertyImageDto)
        {
            try
            {
                return Ok(await _propertyImageRepository.AddImage(propertyImageDto));
               
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("DeleteFile")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {

                return Ok(await _propertyImageRepository.DeleteFile(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
