using Insurance.Application.Commands.Users;
using Insurance.Application.Interfaces;
using Insurance.Core.Interfaces;
using Insurance.Infrastructure.Persistence;
using Insurance.Infrastructure.Persistence.Repositories;
using Insurance.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<LoginCommandHandler>();
builder.Services.AddScoped<CreateUserCommandHandler>();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseInMemoryDatabase("InsuranceInMemoryDb"));
}
//else
//{
//    builder.Services.AddDbContext<ApplicationDbContext>(options =>
//        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//}
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
