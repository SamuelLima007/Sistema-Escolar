using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.ViewModels
{
    public class CreateClassViewModel
    {
        public string? Grade { get; set; }
        public string? Section { get; set; }
    }
}