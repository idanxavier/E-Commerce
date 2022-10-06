using ECommerceProductAPI.Domain;
using ECommerceProductAPI.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MySqlConnector;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
ConfigurationManager configuration = builder.Configuration;
string mySqlConnection = configuration.GetConnectionString("Database");

services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddDbContextPool<MySQLContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));
services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MySQLContext>()
    .AddDefaultTokenProviders();
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

services.AddScoped<IProductService, ProductService>();
services.AddScoped<ProductRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()) 
{
    var service = scope.ServiceProvider;

    var context = service.GetRequiredService<MySQLContext>();
    if (context.Database.GetPendingMigrations().Any())
        context.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(p => {
    p.AllowAnyMethod();
    p.AllowAnyHeader();
    p.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
