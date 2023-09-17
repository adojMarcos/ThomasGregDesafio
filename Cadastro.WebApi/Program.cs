using Cadastro.Core.Repositories.Query;
using Cadastro.Infrastructure.Data;
using Cadastro.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(StartupBase));
builder.Services.AddScoped<IDbConector, DbConnector>();
//builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateLicenseHandler).Assembly));
builder.Services.AddTransient<IClienteQueryRepository, ClienteQueryRepository>();
//builder.Services.AddTransient<ILinceseCommandRepository, LicensesCommandRepository>();
builder.Services.AddTransient<ILogradouroQueryRepository, LogradouroQueryRepository>();
//builder.Services.AddTransient<IClientCommandRepository, ClientCommandRepository>();


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
