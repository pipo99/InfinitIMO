using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
	public class PropertyController : Controller
	{
		public IActionResult Create()
		{
            var model = new Property();
            return View(model);
        }

		[HttpPost]
		public IActionResult Create(Property model)
		{
			return RedirectToAction("Index", "Home");
		}
	}
}
