using MyPortfolio.Models;

namespace MyPortfolio.Interfaces
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllAsync();
        Task<Project> GetByIdAsync(int id);
        Task AddAsync(Project project);
        Task UpdateAsync(Project project);
        Task DeleteAsync(int id);
        Task<List<Project>> SearchByCreatorAsync(string creatorName);

    }
}
