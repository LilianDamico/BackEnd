using System.ComponentModel.DataAnnotations;

namespace BackEnd.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "Senhas devem ser idênticas")]
        public string ConfirmPassword { get; set; }
    }
}
