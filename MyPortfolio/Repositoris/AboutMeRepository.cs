// Repositories/AboutMeRepository.cs
using Microsoft.EntityFrameworkCore;
using MyPortfolio;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

public class AboutMeRepository : IAboutMeRepository
{
    private readonly PortfolioDb _context;
    private readonly IAboutMeRepository _aboutMeRepository;
    private readonly IWebHostEnvironment _env;
    public AboutMeRepository(PortfolioDb context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
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

  
   public async Task<string> SaveUploadedFileAsync(IFormFile file)
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
   
}