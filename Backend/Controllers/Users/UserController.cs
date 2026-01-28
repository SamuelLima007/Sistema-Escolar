// userController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.ViewModels;

namespace ProjetoNotas.WebUi.Conaollers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.RouteAttribute("users")]
    //[Authorize(Roles = "School_Admin, Super_Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync([FromRoute] int id)
        {
            try
            {
                var response = await _userService.GetUserByIdAsync(id);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] CreateUserViewModel model)
        {
            try
            {
                var response = await _userService.AddUserAsync(model);
                if (response.Data.Name == model.Name && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateUserAsync([FromRoute] int id, [FromBody] CreateUserViewModel model)
        {
            try
            {
                var response = await _userService.UpdateUserAsync(id, model);
                if (response.Data == null) return NotFound(response);
                else if (response.Data.Email == model.Email && response.Result == false) return Conflict(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserAsync(int id)
        {
            try
            {
                var response = await _userService.DeleteUserAsync(id);
                if (response.Data == null && response.Result == false) return NotFound(response);
                return Ok(response);
            }
            catch
            {
                return BadRequest("Falha interna no servidor");
            }
        }
    }
}