using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PortfolioDb _portfolioDb;
        private readonly IAboutMeRepository _aboutMeRepository;

        public HomeController(ILogger<HomeController> logger, PortfolioDb portfolioDb, IAboutMeRepository aboutMeRepository)
        {
            _logger = logger;
            _portfolioDb = portfolioDb;
            _aboutMeRepository = aboutMeRepository;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Загружена главная страница портфолио");

            var model = await _aboutMeRepository.GetAsync();
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            _aboutMeRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));

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
