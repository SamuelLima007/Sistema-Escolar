using System;
using Backend.Domain.ViewModels;

namespace ProjetoNotas.Domain.Models
{
    public class AcademicPeriod
    {
        public int Id { get; set; }
        public string Year { get; set; }
        public int Unit { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }

        public bool IsWithinPeriod()
        {
            var today = DateTime.UtcNow.Date;
            return today >= StartDate.Date && today <= EndDate.Date;
        }

        public void Update(CreateAcademicViewModel model)
        {
            if (model != null)
            {
                
                Active = (bool)model.Active;
            }
            
        }
    }
}