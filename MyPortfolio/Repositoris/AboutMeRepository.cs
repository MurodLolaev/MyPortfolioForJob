// Repositories/AboutMeRepository.cs
using Microsoft.EntityFrameworkCore;
using MyPortfolio;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

public class AboutMeRepository : IAboutMeRepository
{
    private readonly PortfolioDb _context;
    private readonly IAboutMeRepository _aboutMeRepository;
    public AboutMeRepository(PortfolioDb context)
    {
        _context = context;
    }

    public async Task<AboutMe> GetAsync()
    {
        return await _context.AboutMe.FirstOrDefaultAsync();
    }

    public async Task<List<AboutMe>> GetAllAsync()
    {
        return await _context.AboutMe.ToListAsync();
    }

    async Task<AboutMe> IAboutMeRepository.GetByIdAsync(int id)
    {
        return await _context.AboutMe.FirstOrDefaultAsync(about => about.Id == id);
    }

    public async Task AddAsync(AboutMe aboutMe)
    {
        _context.AboutMe.Add(aboutMe);
        await _context.SaveChangesAsync();
    }

    public async Task EditAsync(AboutMe aboutMe)
    {
        _context.AboutMe.Update(aboutMe);
        await _context.SaveChangesAsync();
    }

    public void DeleteAsync(int id)
    {
       var aboutMe = _context.AboutMe.FirstOrDefault(about => about.Id == id);
        _context.AboutMe.Remove(aboutMe);
        _context.SaveChanges();
        
    }

    public async Task<List<AboutMe>> SearchAsync(string query)
    {
        return await _context.AboutMe
            .Where(a => a.FullName.Contains(query) || a.Bio.Contains(query))
            .ToListAsync();
    }

   
}