using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Enums;
using ProjetoNotas.Domain.Models;

namespace Backend.Domain.Models
{
    public class Assessment
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public Unit unit { get; set; }
        public int TeacherId { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }


    }
}