using System.ComponentModel.DataAnnotations;

namespace BackEnd.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido!")]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(20, ErrorMessage = "A senha deve ter no mínimo 10 caracteres.", MinimumLength = 10)]
        public string Password { get; set; }
    }
}
