using AppMultas.Components;
using AppMultas.Contexto;
using AppMultas.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<VeiculoController>();
builder.Services.AddScoped<MultaController>();

string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexaoMySQL");
builder.Services.AddDbContextPool<ContextoBD>(options =>
options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
