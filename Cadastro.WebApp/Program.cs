using Cadastro.Application.Handlers.CommandHandlers.ClienteCommandHandler;
using Cadastro.Core.Repositories.Command;
using Cadastro.Core.Repositories.Query;
using Cadastro.Infrastructure.Data;
using Cadastro.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Access/Login";
        option.ExpireTimeSpan = TimeSpan.FromMinutes(20);

    });


builder.Services.AddAutoMapper(typeof(StartupBase));
builder.Services.AddScoped<IDbConector, DbConnector>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateClienteHandler).Assembly));
builder.Services.AddTransient<IClienteQueryRepository, ClienteQueryRepository>();
builder.Services.AddTransient<IClienteCommandRepository, ClienteCommandRepository>();
builder.Services.AddTransient<ILogradouroQueryRepository, LogradouroQueryRepository>();
builder.Services.AddTransient<ILogradouroCommandRepository, LogradouroCommandRepository>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();


builder.Services.AddCors(p => p.AddPolicy("policy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("policy");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
