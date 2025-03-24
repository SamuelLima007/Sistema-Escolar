using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoScores.Domain.Models
{
    public class User
    {
        public string Name { get; set; }

        public string? FotoPerfil { get; set; }
        

        [EmailAddress]
        public string Email { get; set; }

        [MinLength(8, ErrorMessage = "A Password deve conter no minímo 8 caracteres")]

        public string Password { get; set; }

        public virtual string Role { get; set; }


    }
}