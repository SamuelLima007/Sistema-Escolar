using System.Collections.Generic;

namespace ProjetoNotas.Domain.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<MyTask> MyTasks { get; set; } = new List<MyTask>();
    }
}
