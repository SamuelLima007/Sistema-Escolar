using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjetoNotas;
using ProjetoNotas.Controllers;
using ProjetoNotas.Data;
using ProjetoNotas.Domain.Interfaces;
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
    builder.Services.AddScoped<IAlunoController, AlunoController>();
    builder.Services.AddScoped<IProfessorController, ProfessorController>();
    builder.Services.AddScoped<IClasseController, ClasseController>();
    builder.Services.AddScoped<IAdministradorController, AdministradorController>();
    builder.Services.AddScoped<IDisciplinaController, DisciplinaController>();
    builder.Services.AddScoped<IAlunoService, AlunoService>();
    builder.Services.AddScoped<IProfessorService, ProfessorService>();
    builder.Services.AddScoped<IClasseService, ClasseService>();
    builder.Services.AddScoped<IAdministradorService, AdministradorService>();
    builder.Services.AddScoped<IDisciplinaService, DisciplinaService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();
    builder.Services.AddScoped<IProfessorRepository, ProfessorRepository>();
    builder.Services.AddScoped<IClasseRepository, ClasseRepository>();
    builder.Services.AddScoped<IAdministradorRepository, AdministradorRepository>();
    builder.Services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
    builder.Services.AddScoped<LoginRepository>();
    builder.Services.AddScoped<LoginController>();
    builder.Services.AddScoped<InicioViewController>();
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