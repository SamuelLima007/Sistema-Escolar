using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;

namespace ProjetoNotas.Domain.Interfaces
{
    public interface ISubjectController
    {
        Task<ActionResult<Subject>> GetSubjectByIdAsync(int id);
        Task<ActionResult<Subject>> AddSubjectAsync(CreateSubjectViewModel model);
        Task<ActionResult<bool>> UpdateSubjectAsync(int id, CreateSubjectViewModel Subject);
        Task<ActionResult<bool>> DeleteSubjectAsync(int id);
    }
}