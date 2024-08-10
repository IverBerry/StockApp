using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Users
{
    public class RegisterUserViewModel
    {
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

        [Required(ErrorMessage = "Debe ingresar la contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas deben coincidir")]
        [Required(ErrorMessage = "Debe repetir la contraseña")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }

    }
}
