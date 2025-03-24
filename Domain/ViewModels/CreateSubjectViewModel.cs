using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoScores.Domain.ViewModels
{
    public class CreateSubjectViewModel
    {
        [Required(ErrorMessage = "O name é obrigatório")]
        [MinLength(1, ErrorMessage = "O name deve ter no mínimo 1 caractere")]
        [MaxLength(100, ErrorMessage = "O name deve ter no máximo 100 caracteres")]
        public string Name { get; set; }
    }
}