using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebSite.Models;
using WebSite.Services;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly PropertyService _propertyService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index()
        {
            List<Property> properties  = await _propertyService.GetPropertiesAsync();
            return View(properties);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}