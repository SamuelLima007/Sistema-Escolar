using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoScores.Domain.ViewModels
{
    public class UserLoginViewModel
    {

        public string Name { get; set; }
        
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A password é obrigatória")]
        public string Password { get; set; }
    }
}