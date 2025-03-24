using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ProjetoNotas;
using ProjetoScores;
using ProjetoScores.Controllers;
using ProjetoScores.Data;
using ProjetoScores.Domain.Interfaces;
using ProjetoScores.InfraStructure.Interfaces;
using ProjetoScores.Repository;
using ProjetoScores.WebUi.Controllers;
using ProjetoScores.WebUi.Services;
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
    builder.Services.AddScoped<IStudentController, StudentController>();
    builder.Services.AddScoped<ITeacherController, TeacherController>();
    builder.Services.AddScoped<IClassController, ClassController>();
    builder.Services.AddScoped<IAdministratorController, AdministratorController>();
    builder.Services.AddScoped<ISubjectController, SubjectController>();
    builder.Services.AddScoped<IStudentService, StudentService>();
    builder.Services.AddScoped<ITeacherService, TeacherService>();
    builder.Services.AddScoped<IClassService, ClassService>();
    builder.Services.AddScoped<IAdministratorService, AdministratorService>();
    builder.Services.AddScoped<ISubjectService, SubjectService>();
    builder.Services.AddScoped<ITokenService, TokenService>();
    builder.Services.AddScoped<IStudentRepository, StudentRepository>();
    builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
    builder.Services.AddScoped<IClassRepository, ClassRepository>();
    builder.Services.AddScoped<IAdministratorRepository, AdministratorRepository>();
    builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
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