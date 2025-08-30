using Microsoft.EntityFrameworkCore;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

namespace MyPortfolio.Repositoris
{
    public class ContactRepository : IContractRepository
    {
        private readonly PortfolioDb context;

        public ContactRepository(PortfolioDb portfolioDb)
        {
            this.context = portfolioDb;
        }

        public async Task AddAsync(Contact contact)
        {
            context.Contacts.Add(contact);
            context.SaveChanges();
        }

        public void DeleteAsync(int id)
        {
           var contact = context.Contacts.FirstOrDefault(x => x.Id == id);
            if (contact != null)
            {
                context.Contacts.Remove(contact);
            }
            context.SaveChanges();
        }

        public async Task EditAsync(Contact contact)
        {
            context.Contacts.Update(contact);
            context.SaveChanges();
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await context.Contacts.ToListAsync();
        }

        public async Task<Contact?> GetAsync()
        {
            return await context.Contacts.FirstOrDefaultAsync();
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await context.Contacts.FirstOrDefaultAsync(about => about.Id == id);
        }
    }
}
