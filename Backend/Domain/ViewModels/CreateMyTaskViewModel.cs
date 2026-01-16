using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNotas.Domain.ViewModels
{
    public class CreateMyTaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime? CreationDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public int Score { get; set; }

        public int Classid { get; set; }

        public int SubjectId { get; set; }

        public int? TeacherId { get; set; }
    }
}