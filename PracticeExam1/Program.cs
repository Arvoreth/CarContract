using Microsoft.EntityFrameworkCore;
using PracticeExam1;
using PracticeExam1.Domain.Repositories;
using PracticeExam1.Infrastructure.MySqlRepositories;
using PracticeExam1.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddControllers();

var connectionStrings = builder.Configuration.GetConnectionString("mySqlDb");
builder.Services.AddDbContext<MySqlDbContext>();

builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();

var app = builder.Build();

var factory = app.Services.GetRequiredService<IServiceScopeFactory>();
using var scope = factory.CreateScope();
using var context = scope.ServiceProvider.GetRequiredService<MySqlDbContext>();
Seeder.FillMockData(context);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();

app.MapHub<ProcessHub>("/processHub"); 

app.UseStaticFiles();

app.Run();
