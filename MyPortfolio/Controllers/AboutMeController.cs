
using System.IO;
using System.IO.Pipes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPortfolio;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;

public class AboutMeController : Controller
{
    private readonly IAboutMeRepository _repo;
    private readonly PortfolioDb portfolioDb;
    private readonly IWebHostEnvironment _env;

    public AboutMeController(IAboutMeRepository repo,PortfolioDb portfolio, IWebHostEnvironment env)
    {
        _repo = repo;
        portfolioDb = portfolio;
       _env = env;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _repo.GetAsync();
        return View(model);
    }

    public IActionResult Add() => View();

    [HttpPost]
    public async Task<IActionResult> Add(AboutMe model)
    {  
        model.PotoPath = await _repo.SaveUploadedFileAsync(model.UploadedFile);

        await _repo.AddAsync(model);
        return RedirectToAction("Index");   
    }

    

    public async Task<IActionResult> Edit(int id)
    {        
        var model = await _repo.GetByIdAsync(id);
        if(model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, AboutMe model)
    {
        
        if (id  != model.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            model.PotoPath = await _repo.SaveUploadedFileAsync(model.UploadedFile);
            await _repo.EditAsync(model);
            return RedirectToAction(nameof(Index));
        }

        return View(model);
    }

    public IActionResult Delete(int id)
    {
        _repo.DeleteAsync(id);
        return RedirectToAction(nameof(Index));

    }

    public async Task<IActionResult> Search(string query)
    {
        var results = await _repo.SearchAsync(query);
        return View("SearchResults", results);
    }
}