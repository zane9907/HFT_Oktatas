using Ora_06.Data;
using Ora_06.Logic;
using Ora_06.Models;
using Ora_06.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddSingleton<CompanyDbContext>();

builder.Services.AddSingleton<IRepository<Worker>, WorkerRepository>();
builder.Services.AddSingleton<IRepository<Company>, CompanyRepository>();
builder.Services.AddSingleton<IRepository<Country>, CountryRepository>();

builder.Services.AddSingleton<ILogic<Worker>, WorkerLogic>();
builder.Services.AddSingleton<ILogic<Company>, CompanyLogic>();
builder.Services.AddSingleton<ILogic<Country>, CountryLogic>();



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

app.UseAuthorization();

app.MapControllers();

app.Run();
