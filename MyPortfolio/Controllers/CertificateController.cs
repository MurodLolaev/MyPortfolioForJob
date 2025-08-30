using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Interfaces;

namespace MyPortfolio.Controllers
{
    public class CertificateController : Controller
    {
        private readonly ICertificateRepository _certificateRepository;

        public CertificateController(ICertificateRepository certificateRepository)
        {
            _certificateRepository = certificateRepository;
        }

        public async Task<IActionResult> Index()
        {
            var certs = await _certificateRepository.GetAllAsync();
            return View(certs);
        }

    }
}
