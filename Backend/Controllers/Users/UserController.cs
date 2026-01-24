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
        private readonly IAccountService _accountService;

        public UserController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [AllowAnonymous]
        [HttpPost("v1/login")]
        public async Task<ActionResult> Login([FromBody] UserLoginViewModel model)
        {
            var token = await _accountService.ValidateLogin(model.Email, model.Password);
            if (token != null)
            {
                return Ok(token);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync([FromRoute] int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] CreateUserViewModel model)
        {
            try
            {
                await _userService.AddUserAsync(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> UpdateUserAsync([FromRoute] int id, [FromBody] CreateUserViewModel user)
        {
            try
            {
                await _userService.UpdateUserAsync(id, user);
                return Ok();
            }
            catch
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUserAsync(int id)
        {
            var Deleted = await _userService.DeleteUserAsync(id);
            if (Deleted == false) return NotFound();
            return Ok();
        }
    }
}