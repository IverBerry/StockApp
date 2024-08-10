using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Users
{
	public class UpdateUserViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Debe ingresar el nombre")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Debe ingresar el apellido")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Debe ingresar su telefono")]
		public string Phone { get; set; }

		[Required(ErrorMessage = "Debe ingresar el nombre de usuario")]
		public string UserName { get; set; }

		[Required(ErrorMessage = "Debe ingresar el email")]
		public string Email { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
