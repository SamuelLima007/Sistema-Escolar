using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Enums;

namespace Backend.Domain.Models
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public UserType Role { get; set; }

        public int? ClassId { get; set; }

        public string? Class { get; set; }

        public int? Score1 { get; set; }

        public int? Score2 { get; set; }

        public int? Score3 { get; set; }

        public int? Score4 { get; set; }

    }
}