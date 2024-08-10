using Microsoft.AspNetCore.Mvc;
using StockApp.Models.Products;
using StockApp.Models.Users;
using StockApp.Services;

namespace StockApp.Controllers
{
    public class ProductController : Controller
    {
		private readonly ProductService _productService;
		public ProductController(ProductService productService)
		{
			_productService = productService;
		}
		public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllProducts());
        }

		public async Task<IActionResult> Create()
		{
			return View(new RegisterProductViewModel());
		}

		[HttpPost]
		public async Task<IActionResult> Create(RegisterProductViewModel vm)
		{
			if (!ModelState.IsValid)
			{
				return View(vm);
			}

			await _productService.Create(vm);

			return RedirectToRoute(new { controller = "Product", action = "Index" });
		}
	}
}
