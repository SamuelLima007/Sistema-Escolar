using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Domain.Interfaces.Services.School;
using Backend.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers.School
{

    [ApiController]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("periods")]
    public class AcademicPeriodController : ControllerBase
    {
        private readonly IAcademicPeriodService _academicperiodService;

        public AcademicPeriodController(IAcademicPeriodService academicperiodService)
        {
            _academicperiodService = academicperiodService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllAcademicPeriods()
        {
            try
            {
                var response = await _academicperiodService.GetAllAcademicPeriods();
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }

            catch (Exception ex)
            {
                return BadRequest("Falha interna no servidor" + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAcademicPeriodByIdAsync(int id)
        {
            try
            {
                var response = await _academicperiodService.GetAcademicPeriodByIdAsync(id);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }

            catch (Exception ex)
            {
                return BadRequest("Falha interna no servidor" + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddClassAsync([FromBody] CreateAcademicViewModel model)
        {
            try
            {
                var response = await _academicperiodService.AddAcademicPeriodAsync(model);
                if (response.Data == null && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha interna no servidor" + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClassAsync(int id, CreateAcademicViewModel model)
        {
            try
            {
                var response = await _academicperiodService.UpdateAcademicPeriodAsync(id, model);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha interna no servidor" + ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteClassAsync(int id)
        {
            try
            {
                var response = await _academicperiodService.DeleteAcademicPeriodAsync(id);
                if (response.Data == null) return NotFound(response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest("Falha interna no servidor" + ex.Message);
            }
        }
    }
}