using System.Collections.Generic;

namespace ProjetoNotas.Domain.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        public ICollection<MyTask>? MyTasks { get; set; } = new List<MyTask>();

        public ICollection<User> Students { get; set; } = new List<User>();
        //public ICollection<User> Teachers { get; set; } = new List<User>();
    }
}
