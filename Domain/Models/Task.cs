using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Models;

namespace ProjetoNotas.Domain.Models
{
    public class MyTask
    {
        public int MyTaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int Subject_Id { get; set; }

        public Subject Subject { get; set; }

        public int Class_Id { get; set; }
       
       public Class Class { get; set; }

       

    }
}