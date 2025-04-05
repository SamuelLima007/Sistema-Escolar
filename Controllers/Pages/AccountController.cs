
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;


namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _Accountservice;
        private readonly ITokenService _tokenservice;

        public AccountController(IAccountService Accountservice, ITokenService tokenservice)
        {
            _Accountservice = Accountservice;
            _tokenservice = tokenservice;
        }

          [HttpGet("Login")]
        public IActionResult Index()
        {
            return View("Views/LoginView/Login.cshtml", new UserLoginViewModel());
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromForm]UserLoginViewModel user, UserType userType)
        {

                
                var User = await _Accountservice.ValidateLogin<User>(user.Email, user.Password, userType);
                if (User == null)
            {
                TempData["FailureMessage"] = "Erro: Usuario ou password estão incorretos!";
                 return View("Views/LoginView/Login.cshtml");
            }
                var token = _tokenservice.GenerateToken(User);
                Response.Cookies.Append("AuthToken", token, new CookieOptions
                 {
                    HttpOnly = true, 
                    Secure = true,   
                    Expires = DateTime.UtcNow.AddHours(2) 
                 });
                TempData["SuccessMessage"] = "Login realizado com sucesso!";
                return RedirectToAction("HomePage", "Home");
        }

        
    }
}