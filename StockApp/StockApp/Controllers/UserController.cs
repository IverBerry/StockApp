using Microsoft.AspNetCore.Mvc;
using StockApp.Models.Products;
using StockApp.Models.Users;
using StockApp.Services;

namespace StockApp.Controllers
{
    public class UserController : Controller
    {

        private readonly UserService _userService;
        public UserController(UserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {

            return View(await _userService.GetAllUsers());
        }

		public async Task<IActionResult> Create()
		{
			return View(new RegisterUserViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(RegisterUserViewModel vm)
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

			return RedirectToRoute(new { controller = "User", action = "Index" });
		}

		public async Task<IActionResult> Update(int Id)
		{
			return View(await _userService.GetUpdateViewModelById(Id));
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateUserViewModel vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}
			await _userService.Update(vm);

			return RedirectToRoute(new { controller = "User", action = "Index" });
		}

		public async Task<IActionResult> Delete(int Id)
		{
			return View(Id);
		}

		[HttpPost]
		public async Task<IActionResult> DeletePost(int Id)
		{

			await _userService.Delete(Id);

			return RedirectToRoute(new { controller = "User", action = "Index" });
		}
	}
}
