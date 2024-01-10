using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {1} deve ter pelo menos {2} caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = " Confirm PassWord")]
        [Compare("PassWord", ErrorMessage = "The password e a confirmação de password não são iguais.")]
        public string ConfirmPassWord { get; set; }

    }
}
