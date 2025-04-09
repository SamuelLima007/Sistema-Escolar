using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.Models
{
    public class Administrator : User
    {
        public int AdministratorId { get; set; }
        public override string Role => "Admin";
    }
}