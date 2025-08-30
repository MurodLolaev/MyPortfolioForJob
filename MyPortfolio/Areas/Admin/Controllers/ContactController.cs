
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Models;

using MyPortfolio.Models;
using MyPortfolio;
using MyPortfolio.Interfaces;
using MyPortfolio.Repositoris;
using Microsoft.AspNetCore.Authorization;

[Area("Admin")]
[Authorize]
public class ContactController : Controller
{
    private readonly PortfolioDb _context;
    private readonly IWebHostEnvironment _env;    
    private readonly IContractRepository contactRepository;

    public ContactController(PortfolioDb context, IWebHostEnvironment env, IContractRepository contract)
    {
        _context = context;
        _env = env;
        contactRepository = contract;
    }
  
    public async Task<IActionResult> Index()
    {
        var model = await contactRepository.GetAsync();
        return View(model);
    }

    public IActionResult Add() => View();

    [HttpPost]
    public async Task<IActionResult> Add(Contact contact)
    {
        await contactRepository.AddAsync(contact);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Edit(int id)
    {
        var model = await contactRepository.GetByIdAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Contact contact)
    {

        if (id != contact.Id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            await contactRepository.EditAsync(contact);
            return RedirectToAction(nameof(Index));
        }

        return View(contact);
    }

    public IActionResult Delete(int id)
    {
        contactRepository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));

    }

}