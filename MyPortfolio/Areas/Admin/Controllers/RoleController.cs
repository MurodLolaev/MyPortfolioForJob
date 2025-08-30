using Microsoft.AspNetCore.Mvc;

namespace MyPortfolio.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
