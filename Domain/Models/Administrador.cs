using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.Models
{
    public class Administrador : User
    {
     
        public int AdministradorId { get; set; }
   
        public override string Role => "Admin";
        
   
    }
}