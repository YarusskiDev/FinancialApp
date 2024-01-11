using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinancialApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name= "Nome")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O {1} deve ter pelo menos {2} caracteres")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string PassWord { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = " Confirme o PassWord")]
        [Compare("PassWord", ErrorMessage = "The PassWord e a confirmação de PassWord não são iguais.")]
        public string ConfirmPassWord { get; set; }

    }
}
