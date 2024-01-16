using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TrentoMeteo.Models;

namespace TrentoMeteo.Controllers
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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult VisualizzaPrevisioni()
        {
            // Carica i dati da qualche parte, ad esempio da un servizio o da un database
            MeteoViewModel model = CaricaDatiMeteo();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
