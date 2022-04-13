using Logging_in_ASPNETCORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Logging_in_ASPNETCORE.Controllers
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
            var personal = new Personal
            {
                Id = 1,
                NameSurname = "Duhan Kösali",
                Age = 31
            };

            var personal2 = new Personal
            {
                Id = 2,
                NameSurname = "Batuhan Kösali",
                Age = 35
            };

            _logger.LogInformation("Bu ilk logum");
            _logger.LogError("Kullanıcı hatası {@personal}", personal);
            _logger.LogInformation("Kullanıcı doğrulandı {@personal2}", personal2);   
            return View();
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