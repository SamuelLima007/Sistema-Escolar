using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Data;

namespace ProjetoNotas.Domain.Interfaces.Controllers.School
{
    public interface IMyTaskController
    {
       Task<ActionResult<MyTask>> GetMyTaskByIdAsync(int id);
        Task<ActionResult> AddMyTaskAsync([FromBody] CreateMyTaskViewModel model);
        Task<ActionResult> UpdateMyTaskAsync(int id, [FromBody] CreateMyTaskViewModel mytask);
        Task<ActionResult> DeleteMyTaskAsync(int id);
    }
    }
