using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Products
{
	public class RegisterProductViewModel
	{
		[Required(ErrorMessage = "Debe ingresar el nombre")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Debe ingresar la marca")]
		public string Brand { get; set; }

		[Required(ErrorMessage = "Debe ingresar la categoria")]
		public string Category { get; set; }

		[Required(ErrorMessage = "Debe ingresar el precio")]
		public double Price { get; set; }

		[Required(ErrorMessage = "Debe ingresar la cantidad en stock")]
		public int Stock { get; set; }

		public bool HasError { get; set; }
		public string? Error { get; set; }
	}
}
