using Microsoft.EntityFrameworkCore;
using StockApp.Context;
using StockApp.Entities;
using StockApp.Models.Products;
using StockApp.Models.Users;

namespace StockApp.Services
{
	public class ProductService
	{
		private readonly ApplicationContext _dbContext;

		public ProductService(ApplicationContext dbContext)
		{
			_dbContext = dbContext;
		}


		public async Task<List<ProductViewModel>> GetAllProducts()
		{
			var products = await _dbContext.Products.ToListAsync();

			var productsvm = products.Select(product => new ProductViewModel
			{
				Id = product.Id,
				Name = product.Name,
				Brand = product.Brand,
				Category = product.Category,
				Price = product.Price,
				Stock = product.Stock,
			}).ToList();


			return productsvm;

		}
		public async Task<RegisterProductViewModel> Create(RegisterProductViewModel vm)
		{

			Product newproduct = new();
			newproduct.Name = vm.Name;
			newproduct.Brand = vm.Brand;
			newproduct.Category = vm.Category;
			newproduct.Price = vm.Price;
			newproduct.Stock = vm.Stock;

			_dbContext.Products.Add(newproduct);
			_dbContext.SaveChanges();

			return vm;

		}

		
	}
}
