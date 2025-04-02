using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoScores.Domain.ViewModels
{
    public class CreateAdministratorViewModel
    {
        [Required(ErrorMessage = "O name é obrigatório")]
        [MinLength(1, ErrorMessage = "O name deve ter no mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "O name deve ter no máximo 100 caracteres")]
        public string? Name { get; set; }
        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caracteres")]
        [MaxLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres")]
        public string? Password { get; set; }
        public string? Roles { get; set; } = "admin";
    }
}