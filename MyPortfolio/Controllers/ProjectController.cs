using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository _projectRepo;        
        private readonly IWebHostEnvironment _env;
        private readonly PortfolioDb context;

        public ProjectController(IProjectRepository projectRepo, IAboutMeRepository aboutMe, IWebHostEnvironment env, PortfolioDb portfolioDb)
        {
            _projectRepo = projectRepo;          
            _env = env;
            context = portfolioDb;
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
            project.Image = await _projectRepo.UploadedProjectAsync(project.UploadedFile);

            await _projectRepo.AddAsync(project);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
            if (project == null)
                return NotFound();

            return View(project);
        }

        [HttpPost]           
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if (id != project.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Загружаем существующий проект из базы
                var existingProject = await _projectRepo.GetByIdAsync(id);
                if (existingProject == null)
                    return NotFound();

                // Обновляем текстовые поля
                existingProject.Name = project.Name;
                existingProject.Description = project.Description;
                existingProject.Link = project.Link;

                // Только если выбрано новое изображение — обновляем
                if (project.UploadedFile != null)
                {
                    existingProject.Image = await _projectRepo.UploadedProjectAsync(project.UploadedFile);
                }

                // Сохраняем изменения
                await _projectRepo.UpdateAsync(existingProject);
                return RedirectToAction("Index");
            }

            // если валидация не прошла — возвращаем данные обратно в форму
            var projectFromDb = await _projectRepo.GetByIdAsync(id);
            return View(projectFromDb);
        }

       

        public async Task<IActionResult> Delete(int id)
        {
            var project = await _projectRepo.GetByIdAsync(id);
           

            await _projectRepo.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Search(string Name)
        {
            var results = await _projectRepo.SearchByNameAsync(Name);
            return View(results);
        }

    }
}
