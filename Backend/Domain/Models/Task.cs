using System;
using Backend.Domain.Enums;

namespace ProjetoNotas.Domain.Models
{
    public class MyTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int Unit { get; set; }

        public decimal score { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public TaskType Type { get; set; }

        public int SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public int ClassId { get; set; }
        public Class? Class { get; set; }

       public int TeacherId { get; set; }
       public User? Teacher { get; set; }


        
    }
}
