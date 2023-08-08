using Microsoft.AspNetCore.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
	public class PropertyController : Controller
	{
		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Property model)
		{
			return RedirectToAction("Index", "Home");
		}
	}
}
