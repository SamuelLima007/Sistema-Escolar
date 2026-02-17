using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Enums;

namespace Backend.Domain.Models.Responses
{
   public class MyTaskResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime? CreationDate { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public TaskType type { get; set; }
    public int ClassId { get; set; }
    public string SubjectName { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public decimal Score { get; set; }
}

}