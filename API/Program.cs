using API.Context;
using API.Repository.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
{
    options.SuppressModelStateInvalidFilter = true;
}).AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true;
});
var services = builder.Services;
services.AddDbContext<Db_context>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("APISqlServer"));
});
services.AddScoped<UsersRepository>();
services.AddScoped<SquareRepository>();
services.AddScoped<WeatherRepository>();
services.AddScoped<WetherDetailsRepository>();
services.AddScoped<CityRepository>();


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
else
{
    app.Urls.Add("http://*:4001"); // Ensure the application listens on the correct port
    // Ensure Swagger is available in production
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Square API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
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
