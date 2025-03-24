using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjetoScores.Models;

namespace ProjetoScores.ViewModels
{
    public class CreateTeacherViewModel
    {
        [Required(ErrorMessage = "O name é obrigatório")]
        [MinLength(1, ErrorMessage = "O name deve ter no mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "O name deve ter no máximo 100 caracteres")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "A Age é obrigatória")]
        [MinLength(1, ErrorMessage = "A Age deve ter no mínimo 1 caractere")]
        [MaxLength(3, ErrorMessage = "A Age deve ter no máximo 3 caracteres")]
        public int Age { get; set; }
        [Required(ErrorMessage = "O email é obrigatório")]
        [MinLength(1, ErrorMessage = "O email deve ter no mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "A password é obrigatória")]
        [MinLength(6, ErrorMessage = "A password deve ter no mínimo 6 caractere")]
        [MaxLength(100, ErrorMessage = "A password deve ter no máximo 100 caracteres")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "A class é obrigatória")]
        public List<Class> Class { get; set; } = new List<Class>();
        public string? Roles { get; set; }
    }
}