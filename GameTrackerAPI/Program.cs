using GameTracker.API.Services;
using GameTracker.API.Models;
using GameTracker.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserStorageEFRepo, UserStorageEFRepo>();

string connectionString = File.ReadAllText(@"C:\Users\U0K0JI\Training\SQLConnection.txt");
builder.Services.AddDbContext<GameTrackerContext>(options => options.UseSqlServer(connectionString));
//builder.Services.AddSqlServer<GameTrackerContext>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policy => policy.AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
