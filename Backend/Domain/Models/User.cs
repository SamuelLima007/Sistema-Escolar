using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Domain.Models;
using ProjetoNotas.Domain.Enums;

namespace ProjetoNotas.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? FotoPerfil { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }
        public UserType Role { get; set; }

        public int? ClassId { get; set; }
           public Class Class { get; set; } 

        public ICollection<MyTask>? MyTasks { get; set; } = new List<MyTask>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Class>? Classes { get; set; } = new List<Class>();
        public ICollection<SubmittedTask>? SubmittedTasks { get; set; } = new List<SubmittedTask>();


        public void Update(string? newPassword, string? newEmail, string? newName)
        {
            if (newPassword != null)
            {
                Password = newPassword;
            }

            if (newEmail != null)
            {
                Email = newEmail;
            }

            if (newName != null)
            {
                Name = newName;
            }
        }



    }
}
