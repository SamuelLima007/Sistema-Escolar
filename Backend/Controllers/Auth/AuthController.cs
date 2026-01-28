using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.ViewModels;

namespace Backend.Controllers.Auth
{
    [Route("Auth")]
    public class AuthController : Controller
    {

         private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("v1/login")]
        public async Task<ActionResult> Login([FromBody] UserLoginViewModel model)
        {
            try
            {
                var token = await _authService.ValidateLogin(model.Email, model.Password);
                if (token != null)
                {
                    return Ok(token);
                }
                return BadRequest();
            }
            catch
            {
                return BadRequest();
            }
        }

    
    }
}