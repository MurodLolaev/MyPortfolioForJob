using MyPortfolio.Models;

namespace MyPortfolio.Interfaces
{
    public interface IAboutMeRepository
    {
        Task<AboutMe> GetAsync();
        Task<List<AboutMe>> GetAllAsync();
        Task<AboutMe> GetByIdAsync(int id);
        Task AddAsync(AboutMe aboutMe);     
        Task EditAsync(AboutMe aboutMe);
        void  DeleteAsync(int id);
        Task<List<AboutMe>> SearchAsync(string query);           
        Task<string> SaveUploadedFileAsync(IFormFile file);         

    }
}
