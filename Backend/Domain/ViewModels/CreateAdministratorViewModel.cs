using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Enums;

namespace ProjetoNotas.Domain.ViewModels
{
    public class CreateAdministratorViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Roles { get; set; } = "admin";
        public UserType UserType { get; set; } = UserType.Administrator;
    }
}