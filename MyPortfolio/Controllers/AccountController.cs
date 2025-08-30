using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyPortfolio.Interfaces;
using MyPortfolio.Models;
using MyPortfolio.Repositoris;

namespace MyPortfolio.Controllers
{
    //[Area("Admin")]
    public class AccountController : Controller
    {          
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> user, SignInManager<User> signInManager)
        {             
            _userManager = user;
            this.signInManager = signInManager;
        }

        public IActionResult Login(string returnUrl)
        {
            return View(new Login() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            var result = signInManager.PasswordSignInAsync(login.UserName, login.Password, login.Remember, false).Result;
            if (result.Succeeded)
            {
                return Redirect(login.ReturnUrl ?? "/Home");
            }
            else
            {
                ModelState.AddModelError("", "Неправилный парол");
            }
            return View(login);
            
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        public IActionResult Register(string returnUrl)
        {
            return View(new Register() { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.UserName == register.Password)
            {
                ModelState.AddModelError("", "Логин и пароль не должны совпадать!");
            }
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    //Email = register.Email,
                    UserName = register.UserName
                    
                };
                var result = _userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    signInManager.SignInAsync(user, false).Wait();
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }

            }
            return View(register);
            /*if(ModelState.IsValid)
            {
                userManager.Add(new UserAccount
                {                     
                    Name = register.UserName,
                    Password = register.Password
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return RedirectToAction(nameof(Register));*/
        }
    }
}
