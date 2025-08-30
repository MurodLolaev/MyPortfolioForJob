using MyPortfolio.Models;

namespace MyPortfolio.Interfaces
{
    public interface ICertificateRepository
    {
        Task<IEnumerable<Certificate>> GetAllAsync();
        Task<Certificate> GetByIdAsync(int id);
        Task AddAsync(Certificate certificate);
        Task UpdateAsync(Certificate certificate);
        Task DeleteAsync(int id);
        Task<string?> UploadCertAsync(IFormFile? uploadedFile);
    }
}
