using API.Context;
using API.Repository.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
var services = builder.Services;
services.AddDbContext<Db_context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("APISqlServer"));
});
services.AddScoped<UsersRepository>();
services.AddScoped<SquareRepository>();

services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = false,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero

    };
});
services.AddCors(e =>
{

    e.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    //                e.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:44309/TestCors"));

});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
/*services.AddSwaggerGen(c => c.SwaggerDoc(name: "User", new OpenApiInfo { Title = "The rectangular User Login API Documentations", Version = "1.1" }));  //version must same with branch prod versions
*/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseCors(options =>
          options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
          //options.WithOrigins("https://localhost:44309")
          );
app.UseAuthorization();
app.UseCors(options =>
           options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
           //options.WithOrigins("https://localhost:44309")
           );

app.MapControllers();

app.Run();
