using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Enums;


namespace ProjetoNotas.ViewModels
{
    public class CreateUserViewModel
    {

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int ClassId { get; set; }
        public UserType Role { get; set; }

    }
}



