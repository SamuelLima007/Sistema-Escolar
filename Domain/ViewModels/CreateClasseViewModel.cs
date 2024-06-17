using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.ViewModels
{
    public class CreateClasseViewModel
    {
        [Required(ErrorMessage = "A serie é obrigatória")]
        public string? Serie { get; set; }

        [Required(ErrorMessage = "A turma é obrigatória")]
        public string? Turma { get; set; }

    }
}