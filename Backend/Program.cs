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
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

ConfigureAuthentication(builder);
ConfigureMvc(builder);
ConfigureServices(builder);
void ConfigureAuthentication(WebApplicationBuilder builder)
{
    var apikey = Environment.GetEnvironmentVariable("API_KEY");
    var key = Encoding.ASCII.GetBytes(apikey);

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



    builder.Services.AddScoped<IClassService, ClassService>();
    builder.Services.AddScoped<IClassRepository, ClassRepository>();

    builder.Services.AddScoped<IUserService, UserService>();
    builder.Services.AddScoped<IUserRepository, UserRepository>();

    builder.Services.AddScoped<ISubjectService, SubjectService>();
    builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();

    builder.Services.AddScoped<IMyTaskService, MyTaskService>();
    builder.Services.AddScoped<IMyTaskRepository, MyTaskRepository>();

    builder.Services.AddScoped<IAccountService, AccountService>();
    builder.Services.AddScoped<IAccountRepository, AccountRepository>();

    builder.Services.AddScoped<ITokenService, TokenService>();

    builder.Services
    .AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter()
        );
    });




    builder.Services.AddCors(options =>
       {
           options.AddPolicy("AllowAll",
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
app.UseCors("AllowAll");
app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Run();