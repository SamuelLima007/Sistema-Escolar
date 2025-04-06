
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjetoNotas.Domain.Enums;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Models;
using ProjetoNotas.Domain.ViewModels;
using ProjetoNotas.Models;
using ProjetoNotas.ViewModels;


namespace ProjetoNotas.WebUi.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountservice;
        private readonly ITokenService _tokenservice;

        private readonly IStudentService _studentService;

        public AccountController(IAccountService accountservice, ITokenService tokenservice, IStudentService studentService)
        {
            _accountservice = accountservice;
            _tokenservice = tokenservice;
            _studentService = studentService;
        }

        [HttpGet("/")]
        public IActionResult Get()
        {
            return View("/Views/Home/Register.cshtml", new CreateStudentViewModel());
        }


        [HttpPost("/")]
        public async Task<IActionResult> Register([FromForm]CreateStudentViewModel model)
        {
            if (model != null)
            {
                
                if (await _accountservice.IsEmailRegisteredAsync(model.Email))
                   {
                       TempData["FailureMessage"] = "Erro: Email já cadastrado!";
                       return View("/Views/Home/Register.cshtml");
                    }
                await _studentService.AddStudentAsync(model);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                return View("/Views/Home/Register.cshtml");
            }

            TempData["FailureMessage"] = "Houve um erro no Cadastro!";
            return View("/Views/Home/Register.cshtml");
        }
          [HttpGet("Login")]
        public IActionResult Index()
        {
            return View("Views/LoginView/Login.cshtml", new UserLoginViewModel());
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAsync([FromForm]UserLoginViewModel user, UserType userType)
        {
    
                var User = await _accountservice.ValidateLogin<User>(user.Email, user.Password, userType);
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