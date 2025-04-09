using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.InfraStructure.Interfaces
{
    public interface ITeacherController
    {
        public Task<IActionResult> GetTeacherAsync([FromRoute] int id);
        Task<IActionResult> AddTeacherAsync([FromBody] CreateTeacherViewModel model, int id);
        Task<IActionResult> UpdateTeacherAsync([FromRoute] int id, [FromBody] CreateTeacherViewModel teacher);
        Task<IActionResult> DeleteTeacherAsync([FromRoute] int id);
    }
}