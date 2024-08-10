using Microsoft.AspNetCore.Mvc;
using StockApp.Models.Users;
using StockApp.Services;
using System.Diagnostics;

namespace StockApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserService _userService;
        public HomeController(UserService userService) 
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            return View(new LoginUserViewModel());
        }


        [HttpPost]
        public async Task<IActionResult> Index(LoginUserViewModel vm)
        {
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			vm = await _userService.Login(vm);

            if (vm.HasError)
            {
                return View(vm);
            }

            return RedirectToRoute(new { controller = "Home", action = "HomePage" });
        }

        public async Task<IActionResult> Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserViewModel vm)
        {
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			vm = await _userService.Register(vm);

            if (vm.HasError)
            {
                return View(vm);
            }

            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        public async Task<IActionResult> HomePage()
        {
            return View();
        }



    }
}
