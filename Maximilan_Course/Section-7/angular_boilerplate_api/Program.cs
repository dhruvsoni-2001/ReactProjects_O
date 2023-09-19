using BoilerPlate.Constants;
using BoilerPlate.CustomHandlers;
using BoilerPlate.DbConnector;
using BoilerPlate.Middleware;
using BoilerPlate.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<DatabaseExecutor>();
// Add services to the container.
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddAutoMapper(typeof(CustomMapperHandler).Assembly);
builder.Services.AddScoped<DatabaseExecutor>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IModuleRepository, ModuleRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
builder.Services.AddScoped<ICMSRepository, CMSRepository>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddSingleton(new JsonSerializerSettings()
{
    ContractResolver = new CamelCasePropertyNamesContractResolver()
});

builder.Services.AddTransient<ITokenService, TokenService>();

var key = Encoding.ASCII.GetBytes(Constants.JWTKey);
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(x => x
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers().RequireAuthorization();
app.UseMiddleware<CommonResponseMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.Run();