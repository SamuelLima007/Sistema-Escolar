// userController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;

using ProjetoNotas.ViewModels;

namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]


    public class UserController : ControllerBase, IUserController
    {
        private readonly IUserService _userService;
        private readonly IAccountService _accountService;

        public UserController(IUserService userService, IAccountService accountService)
        {
            _userService = userService;
            _accountService = accountService;
        }

        [HttpPost("v1/login")]
        public async Task<ActionResult> Login([FromBody] CreateUserViewModel model)
        {
            var token = await _accountService.ValidateLogin(model.Email, model.Password, model.Role);
            if (token != null)
            {
                return Ok(token);

            }
            return BadRequest();
        }

        [HttpGet("v1/getuser/{id}")]
        public async Task<ActionResult<User>> GetUserByIdAsync(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("v1/adduser")]
        public async Task<ActionResult<User>> AddUserAsync([FromBody] CreateUserViewModel model)
        {

            try
            {
                await _userService.AddUserAsync(model);
                return Ok();
            }
            catch
            {
                Console.WriteLine("----------------");

                Console.WriteLine(model.Email);


                Console.WriteLine("----------------");

                return BadRequest();
            }

        }
        [HttpPut("v1/updateuser/{id}")]
        public async Task<ActionResult<bool>> UpdateUserAsync(int id, [FromBody] CreateUserViewModel user)
        {
            var Updated = await _userService.UpdateUserAsync(id, user);
            if (Updated == false) return NotFound();

            return NoContent();
        }

        [HttpDelete("v1/deleteuser/{id}")]
        public async Task<ActionResult<bool>> DeleteUserAsync(int id)
        {
            var Deleted = await _userService.DeleteUserAsync(id);
            if (Deleted == false) return NotFound();

            return NoContent();
        }
    }
}