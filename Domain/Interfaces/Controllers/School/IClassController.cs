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
    public interface IClassController
    {
        Task<IActionResult> GetClassByIdAsync([FromRoute] int id);
        Task<IActionResult> AddClassAsync([FromBody] CreateClassViewModel model);
        Task<IActionResult> UpdateClassAsync([FromRoute] int id, [FromBody] Class classentity);
        Task<IActionResult> DeleteClassAsync([FromRoute] int id);
    }
}