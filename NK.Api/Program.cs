using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NK.Infrastructure;
using NK.Repository;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///We are adding these lines of code in the program.cs file because it is the entry point of the application and the ConfigureServices method is where we configure the dependency injection container. By adding these lines of code, we are registering the implementations of various interfaces with the dependency injection container. This allows us to easily access and use these implementations throughout our application. For example, by registering the UserServices class with the IUserServices interface, we can easily inject an instance of IUserServices into our controllers or other classes that depend on it. This makes it easier to write clean, modular, and testable code.
builder.Services.AddTransient<IUserServices, UserServices>();
builder.Services.AddTransient<ITasksServices, TasksServices>();

builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<ITasksRepository, TasksRepository>();


// Memory Cache
builder.Services.AddMemoryCache();




// Configure JWT authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,

                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        });
builder.Services.AddSingleton<NK.Infrastructure.ExceptionHandlingMiddleware>();
 


var app = builder.Build();
// Global Exception Handling
// Register the custom middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
// Enable authentication
app.UseAuthentication();
// Enable authorization
app.UseAuthorization();
app.MapControllers();
app.Run();
