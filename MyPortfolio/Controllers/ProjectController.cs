using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepo;
        private readonly IAboutMeRepository aboutMeRepository; // для получения текущего пользователя

        public ProjectController(IProjectRepository projectRepo, IAboutMeRepository aboutMe)
        {
            _projectRepo = projectRepo;
            aboutMeRepository = aboutMe;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _projectRepo.GetAllAsync();
            return View(projects);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Project project)
        {
            var userId = aboutMeRepository.GetCurrentUserId();
            project.AboutMeId = userId;

            await _projectRepo.AddAsync(project);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project.AboutMeId != aboutMeRepository.GetCurrentUserId())  // здесь надо думать
                return Forbid();

            return View(project);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Project project)
        {
            if (project.AboutMeId != aboutMeRepository.GetCurrentUserId())
                return Forbid();

            await _projectRepo.UpdateAsync(project);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project.AboutMeId != aboutMeRepository.GetByIdAsync())
                return Forbid();

            await _projectRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search(string creatorName)
        {
            var results = await _projectRepo.SearchByCreatorAsync(creatorName);
            return View("Index", results);
        }

    }
}
