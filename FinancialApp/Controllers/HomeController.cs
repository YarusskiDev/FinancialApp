using FinancialApp.Models;
using FinancialApp.ViewModels;
using FinancialAppInfrastructure.Data.ApplicationContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinancialApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login( LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);

            }
            return null;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var newUser = new AppUser()
                {
                    Name = register.Name,
                    Email = register.Email,
                    UserName = register.Email
                };

                var userCreated = await _userManager.CreateAsync(newUser, register.PassWord);
                if (userCreated.Succeeded)
                {
                    await _signInManager.SignInAsync(newUser,isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(register);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}