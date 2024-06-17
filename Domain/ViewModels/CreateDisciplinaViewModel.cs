using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.ViewModels
{
    public class CreateDisciplinaViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MinLength(1, ErrorMessage = "O nome deve ter no mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }
    }
}