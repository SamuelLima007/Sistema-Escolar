using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.Models
{
    public class User
    {
        public string  Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

    public virtual string Role { get; set; }

          
    }
}