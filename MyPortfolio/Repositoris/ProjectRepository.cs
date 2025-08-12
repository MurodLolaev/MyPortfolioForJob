using Microsoft.EntityFrameworkCore;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Repositoris
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PortfolioDb _context;

        public ProjectRepository(PortfolioDb context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetAllAsync() =>
            await _context.Projects.Include(p => p.Creator).ToListAsync();

        public async Task<Project> GetByIdAsync(int id) =>
            await _context.Projects.Include(p => p.Creator).FirstOrDefaultAsync(p => p.Id == id);

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

        public async Task<List<Project>> SearchByCreatorAsync(string creatorName) =>
            await _context.Projects
                .Include(p => p.Creator)
                .Where(p => p.Creator.RoleName.Contains(creatorName))
                .ToListAsync();

    }
}
