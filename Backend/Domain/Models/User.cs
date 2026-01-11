using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Score> Scores { get; set; } = new List<Score>();
    }
}
