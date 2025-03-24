using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoScores.ViewModels
{
    public class CreateClassViewModel
    {
        [Required(ErrorMessage = "A serie é obrigatória")]
        public string? Grade { get; set; }
        [Required(ErrorMessage = "A turma é obrigatória")]
        public string? Section { get; set; }
    }
}