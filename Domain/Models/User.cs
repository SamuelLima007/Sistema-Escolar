using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.Models
{
    public class User
    {
        public string Nome { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "A Senha deve conter no minímo 8 caracteres")]

        public string Senha { get; set; }

        public virtual string Role { get; set; }


    }
}