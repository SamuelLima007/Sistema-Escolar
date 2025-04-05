using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjetoNotas;
using ProjetoNotas;
using ProjetoNotas.Application.Services;
using ProjetoNotas.Controllers;
using ProjetoNotas.Controllers.School;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
using ProjetoNotas.Domain.Interfaces.Controllers.School;
using ProjetoNotas.Domain.Interfaces.Repositoryes.School;
using ProjetoNotas.Domain.Interfaces.Services.School;
using ProjetoNotas.Domain.Repository;
using ProjetoNotas.InfraStructure.Interfaces;
using ProjetoNotas.Repository;
using ProjetoNotas.WebUi.Controllers;
using ProjetoNotas.WebUi.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);
void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var key = Encoding.ASCII.GetBytes(Configuration.ApiKey);

    builder.Services.AddAuthentication(x =>
     {
         x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
         x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
     }).AddJwtBearer(options =>
         {
             options.TokenValidationParameters = new TokenValidationParameters
             {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(key),
                 ValidateIssuer = false,
                 ValidateAudience = false
             };
         });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<EscolaDataContext>();
  
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();

    builder.Services.AddScoped<ITeacherService, TeacherService>();
    builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
    
    builder.Services.AddScoped<IClassService, ClassService>();
    builder.Services.AddScoped<IClassRepository, ClassRepository>();

    builder.Services.AddScoped<IAdministratorService, AdministratorService>();
    builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();

    builder.Services.AddScoped<ISubjectService, SubjectService>();
    builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
    
    builder.Services.AddScoped<IMyTaskService, MyTaskService>();
    builder.Services.AddScoped<IMyTaskRepository, MyTaskRepository>();

    builder.Services.AddScoped<IAccountService, AccountService>();
    builder.Services.AddScoped<IAccountRepository, AccountRepository>();
    
    builder.Services.AddScoped<ITokenService, TokenService>();
   
    builder.Services.AddRazorPages();
    builder.Services.AddControllersWithViews();

    builder.Services.AddCors(options =>
       {
           options.AddPolicy("CorsPolicy",
               builder => builder.AllowAnyOrigin()
                                 .AllowAnyMethod()
                                 .AllowAnyHeader());
       });
}

void ConfigureMvc(WebApplicationBuilder builder)
{

    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

    builder.Services.AddHttpClient();
}

var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Run();