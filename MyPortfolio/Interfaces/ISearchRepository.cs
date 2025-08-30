using MyPortfolio.Models;

namespace MyPortfolio.Interfaces
{
    public interface ISearchRepository
    {
        IEnumerable<Project> GetAll();
        IEnumerable<Project> SearchByTitle(string name);

    }
}
