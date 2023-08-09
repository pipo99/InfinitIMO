using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;
using WebSite.Services;

namespace WebSite.Controllers
{
    public class InquiryController : Controller
    {
        private readonly InquiryService _inquiryService;


        public InquiryController(InquiryService inquiryService)
        {
            this._inquiryService = inquiryService;
        }


        public async Task<IActionResult> List()
        {
            List <Inquiry> inquirys= await _inquiryService.GetInquiriesAsync();

            if (inquirys == null)
            {
                return NotFound();
            }

            return View(inquirys);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var inquiry = await _inquiryService.GetInquiryByIdAsync(id);

            if (inquiry == null)
            {
                return NotFound();
            }

            return View(inquiry);
        }


        [HttpPost]
        public async Task<IActionResult> Create(Inquiry inquiry)
        {
            inquiry.Date = DateTime.Now;

            var resCreate = await _inquiryService.Create(inquiry);

            return RedirectToAction("Index", "Home");
        }
    }
}
