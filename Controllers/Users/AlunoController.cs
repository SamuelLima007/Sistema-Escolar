// AlunoController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoNotas.Attributes;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]


    [ApiKey]
    public class AlunoController : ControllerBase, IAlunoController
    {
        private readonly IAlunoService _alunoService;

        public AlunoController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }


        [HttpGet("v1/getaluno/{id}")]

        public async Task<ActionResult<Aluno>> GetAlunoByIdAsync(int id)
        {
            var aluno = await _alunoService.GetAlunoByIdAsync(id);
            if (aluno == null)
            {
                return NotFound();
            }
            return Ok(aluno);
        }

        [HttpPost("v1/addaluno")]
        public async Task<ActionResult<Aluno>> AddAlunoAsync([FromServices] EscolaDataContext context, [FromBody] CreateAlunoViewModel model)
        {

            var aluno = await _alunoService.AddAlunoAsync(model);
            return Ok();
        }


        [HttpPut("v1/updatealuno/{id}")]
        public async Task<ActionResult<bool>> UpdateAlunoAsync(int id, [FromBody] Aluno aluno)
        {
            if (!await _alunoService.UpdateAlunoAsync(id, aluno))
            {
                return NotFound();
            }
            return Ok(true);
        }

        [HttpDelete("v1/deletealuno/{id}")]
        public async Task<ActionResult<bool>> DeleteAlunoAsync(int id)
        {
            if (!await _alunoService.DeleteAlunoAsync(id))
            {
                return NotFound();
            }
            return Ok(true);
        }
    }
}