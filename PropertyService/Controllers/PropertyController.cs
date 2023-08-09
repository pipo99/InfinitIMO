using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PropertyService.Models; 


namespace PropertyService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : ControllerBase
    {
        private readonly PropertyService.Services.PropertyService _propertyService;

        public PropertyController(PropertyService.Services.PropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <remarks>
        /// This API method returns a list of all available properties.
        /// </remarks>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<Property>>> GetProperties()
        {
            var properties = await _propertyService.GetPropertiesAsync();

            return Ok(properties);
        }

        /// <summary>
        /// Get By ID
        /// </summary>
        /// <remarks>
        /// This API method returns details of a property based on its ID.
        /// </remarks>
        /// <param name="id">The ID of the property.</param>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Property>> GetProperty(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);
            if (property == null)
            {
                return NotFound();
            }
            return Ok(property);
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <remarks>
        /// This API method allows creating a new property.
        /// </remarks>
        /// <param name="property">The information of the new property to be created.</param>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> CreateProperty(Property property)
        {
            await _propertyService.CreatePropertyAsync(property);
            return CreatedAtAction(nameof(GetProperty), new { id = property.Id }, property);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <remarks>
        /// This API method allows updating information of an existing property based on its ID.
        /// </remarks>
        /// <param name="id">The ID of the property to be updated.</param>
        /// <param name="property">The new information of the property.</param>
        [Produces("application/json")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProperty(int id, Property property)
        {
            if (id != property.Id)
            {
                return BadRequest();
            }

            await _propertyService.UpdatePropertyAsync(property);

            return NoContent();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <remarks>
        /// This API method allows deleting a property based on its ID.
        /// </remarks>
        /// <param name="id">The ID of the property to be deleted.</param>
        [Produces("application/json")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProperty(int id)
        {
            await _propertyService.DeletePropertyAsync(id);
            return NoContent();
        }
    }
}
