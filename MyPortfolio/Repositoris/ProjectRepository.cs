using Microsoft.EntityFrameworkCore;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Repositoris
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PortfolioDb _context;
        private readonly IWebHostEnvironment _env;

        public ProjectRepository(PortfolioDb context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<List<Project>> GetAllAsync() =>
            await _context.Projects.ToListAsync();

        public async Task<Project> GetByIdAsync(int id) =>
            await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

        public async Task AddAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project != null)
            {
                _context.Projects.Remove(project);
                await _context.SaveChangesAsync();
            }
        }
       

        public async Task<string> UploadedProjectAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return null;

            var fileName = Path.GetFileName(file.FileName);
            var path = Path.Combine(_env.WebRootPath, "images", fileName);

            // Удалить, если файл уже существует
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/images/" + fileName;
        }

        public async Task<List<Project>> SearchByNameAsync(string name)
        {
            return await _context.Projects
           .Where(x => x.Name.Contains(name.ToLower()))
           .ToListAsync();

        }
       
    }
}
