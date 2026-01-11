using System.Collections.Generic;

namespace ProjetoNotas.Domain.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string Grade { get; set; }

        public ICollection<User>? Users { get; set; } = new List<User>();
        public ICollection<MyTask>? MyTasks { get; set; } = new List<MyTask>();
    }
}
