using System.ComponentModel.DataAnnotations;

namespace StockApp.Models.Users
{
    public class LoginUserViewModel
    {

        [Required(ErrorMessage = "Tiene que ingresar el username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Tiene que ingresar la Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }

    }
}
