
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;
using MyPortfolio;
using MyPortfolio.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

[Area("Admin")]
[Authorize]
public class AboutController : Controller
{
    private readonly PortfolioDb _context;
    private readonly IWebHostEnvironment _env;
    private readonly IAboutMeRepository _repo;
   

    public AboutController(PortfolioDb context, IWebHostEnvironment env, IAboutMeRepository aboutMeRepository)
    {
        _context = context;
        _env = env;
        _repo = aboutMeRepository;
       
    }
   
    public async Task<IActionResult> Index()
    {
        var model = await _repo.GetAsync();         
        return View(model ?? new AboutMe());
    }

    public IActionResult Add() => View();

    [HttpPost]
    public async Task<IActionResult> Add(AboutMe model)
    {
        model.PotoPath = await _repo.SaveUploadedFileAsync(model.UploadedFile);

        await _repo.AddAsync(model);
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        var about = _context.AboutMe.FirstOrDefault();
        return View(about);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AboutMe model, IFormFile photo)
    {
        
        var existing = await _context.AboutMe
    .AsNoTracking()
    .FirstOrDefaultAsync(x => x.Id == model.Id);
        if (existing == null) 
            return NotFound();
        existing.FullName = model.FullName;
        existing.Bio = model.Bio;
        existing.Skills = model.Skills;
        existing.Contacts = model.Contacts;
        existing.Hobbies = model.Hobbies;


        if (photo != null)
        {
            var path = Path.Combine(_env.WebRootPath, "images", photo.FileName);
            using var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream);
            model.UploadedFile = photo;//"/images/" + photo.FileName;
            existing.PotoPath = "/images/" + path;

        }
        else
        {
            model.PotoPath = existing.PotoPath;
        }

        _context.Update(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(int id)
    {
        _repo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));

    }
}