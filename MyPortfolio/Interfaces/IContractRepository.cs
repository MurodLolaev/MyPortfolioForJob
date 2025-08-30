using MyPortfolio.Models;

namespace MyPortfolio.Interfaces
{
    public interface IContractRepository
    {         
        Task<List<Contact>> GetAllAsync();
        Task<Contact> GetByIdAsync(int id);
        Task AddAsync(Contact contact);
        Task EditAsync(Contact contact);
        void DeleteAsync(int id);
        Task<Contact?> GetAsync();
    }
}
