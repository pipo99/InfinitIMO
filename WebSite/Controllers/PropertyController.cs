using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSite.Models;
using WebSite.Services;

namespace WebSite.Controllers
{
	public class PropertyController : Controller
	{
        private readonly PropertyService _propertyService;

        public PropertyController(PropertyService propertyService)
        {
            this._propertyService = propertyService;
        }

        public IActionResult Create()
		{
            var model = new Property();
            return View(model);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var property = await _propertyService.GetPropertyByIdAsync(id);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }


        [HttpPost]
		public async Task<IActionResult> Create(Property property)
		{
            if (ModelState.IsValid)
            {
                var resCreate = await _propertyService.Create(property);

                return RedirectToAction("Index", "Home");
            }

            return View(property);
		}
	}
}
