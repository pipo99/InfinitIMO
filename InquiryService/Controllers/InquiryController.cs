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

        [HttpGet]
        public async Task<ActionResult<List<Inquiry>>> GetInquiries()
        {
            var properties = await _inquiryService.GetInquiriesAsync();
            return Ok(properties);
        }

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

        [HttpPost]
        public async Task<ActionResult> CreateInquiry(Inquiry inquiry)
        {
            await _inquiryService.CreateInquiryAsync(inquiry);
            return CreatedAtAction(nameof(GetInquiry), new { id = inquiry.Id }, inquiry);
        }
    }
}
