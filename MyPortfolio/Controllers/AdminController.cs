
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;

using MyPortfolio.Models;
using MyPortfolio;

public class AdminController : Controller
{
    private readonly PortfolioDb _context;
    private readonly IWebHostEnvironment _env;

    public AdminController(PortfolioDb context, IWebHostEnvironment env)
    {
        _context = context;
        _env = env;
    }

    public IActionResult Edit()
    {
        var about = _context.AboutMe.FirstOrDefault();
        return View(about);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(AboutMe model, IFormFile photo)
    {
        if (photo != null)
        {
            var path = Path.Combine(_env.WebRootPath, "images", photo.FileName);
            using var stream = new FileStream(path, FileMode.Create);
            await photo.CopyToAsync(stream);
            model.PhotoPath = "/images/" + photo.FileName;
        }

        _context.Update(model);
        await _context.SaveChangesAsync();
        return RedirectToAction("Edit");
    }
}