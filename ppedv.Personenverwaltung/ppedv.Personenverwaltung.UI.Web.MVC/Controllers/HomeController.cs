using Microsoft.AspNetCore.Mvc;
using ppedv.Personenverwaltung.UI.Web.MVC.Models;
using System.Diagnostics;

namespace ppedv.Personenverwaltung.UI.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var zahlen = new int[] { 12, 33, 656, 78345534 };
            return View(zahlen);
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