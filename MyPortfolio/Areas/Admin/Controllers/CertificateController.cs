using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CertificateController : Controller
    {
        private readonly ICertificateRepository _certificateRepository;
        private readonly IWebHostEnvironment _env;

        public CertificateController(ICertificateRepository certificateRepository, IWebHostEnvironment env)
        {
            _certificateRepository = certificateRepository;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var certificates = await _certificateRepository.GetAllAsync();
            return View(certificates);
        }


        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Certificate model)
        {
            model.Image = await _certificateRepository.UploadCertAsync(model.UploadedFile);
            await _certificateRepository.AddAsync(model);
            return RedirectToAction("Index");             
        }

        // 📄 Показать форму редактирования
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var cert = await _certificateRepository.GetByIdAsync(id);
            if (cert == null) return NotFound();
            return View(cert);
        }

        // 💾 Сохранить изменения
        [HttpPost]
        public async Task<IActionResult> Edit(Certificate model)
        {
            var existing = await _certificateRepository.GetByIdAsync(model.Id);
            if (existing == null) return NotFound();

            existing.Name = model.Name;
            existing.Image = model.Image;
            existing.CreatedAt = model.CreatedAt;

            await _certificateRepository.UpdateAsync(existing);
            return RedirectToAction("Index");
        }

        // 🗑️ Удалить сертификат
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _certificateRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
