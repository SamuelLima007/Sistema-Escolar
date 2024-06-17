using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Models;

namespace ProjetoNotas.ViewModels
{
    public class CreateProfessorViewModel
    {


        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(1, ErrorMessage = "O nome deve ter no mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string? Nome { get; set; }


        [Required(ErrorMessage = "A idade é obrigatória")]
        [MinLength(1, ErrorMessage = "A idade deve ter no mínimo 1 caractere")]
        [MaxLength(3, ErrorMessage = "A idade deve ter no máximo 3 caracteres")]

        public int Idade { get; set; }


        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [MinLength(1, ErrorMessage = "O e-mail deve ter no mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres")]
        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(6, ErrorMessage = "A senha deve ter no mínimo 6 caractere")]
        [MaxLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres")]

        public string? Senha { get; set; }


        [Required(ErrorMessage = "A classe é obrigatória")]
        public List<Classe> Classe { get; set; } = new List<Classe>();

        public string? Roles { get; set; }
    }

    
}