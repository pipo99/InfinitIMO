using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InquiryService.Models; 


namespace InquiryService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InquiryController : ControllerBase
    {
        private readonly InquiryService.Services.InquiryService _inquiryService;

        public InquiryController(InquiryService.Services.InquiryService inquiryService)
        {
            _inquiryService = inquiryService;
        }

        /// <summary>
        /// Get All
        /// </summary>
        /// <remarks>
        /// This API method returns a list of all available inquiries.
        /// </remarks>
        [Produces("application/json")]
        [HttpGet]
        public async Task<ActionResult<List<Inquiry>>> GetInquiries()
        {
            var properties = await _inquiryService.GetInquiriesAsync();
            return Ok(properties);
        }


        /// <summary>
        /// Get By ID
        /// </summary>
        /// <remarks>
        /// This API method returns details of an inquiry based on its ID.
        /// </remarks>
        /// <param name="id">The ID of the inquiry.</param>
        [Produces("application/json")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Inquiry>> GetInquiry(int id)
        {
            var property = await _inquiryService.GetInquiryByIdAsync(id);
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
        /// This API method allows creating a new inquiry.
        /// </remarks>
        /// <param name="inquiry">The information of the new inquiry to be created.</param>
        [Produces("application/json")]
        [HttpPost]
        public async Task<ActionResult> CreateInquiry(Inquiry inquiry)
        {
            await _inquiryService.CreateInquiryAsync(inquiry);
            return CreatedAtAction(nameof(GetInquiry), new { id = inquiry.Id }, inquiry);
        }
    }
}
