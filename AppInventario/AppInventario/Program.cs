using AppInventario.Components;
using AppInventario.Contexto;
using AppInventario.Services;
using Microsoft.EntityFrameworkCore;
using AppInventario.Components.Account;
using AppInventario.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<PessoaService>();
builder.Services.AddScoped<PropriedadeService>();

string mySqlConexao = builder.Configuration.GetConnectionString("BaseConexao");
builder.Services.AddDbContextPool<ContextoBD>(options =>
options.UseMySql(mySqlConexao, ServerVersion.AutoDetect(mySqlConexao)));

string mySqlConexaoData = builder.Configuration.GetConnectionString("BaseConexao");
builder.Services.AddDbContextPool<AppInventarioContext>(options =>
options.UseMySql(mySqlConexaoData, ServerVersion.AutoDetect(mySqlConexaoData)));

builder.Services.AddCascadingAuthenticationState();

builder.Services.AddScoped<IdentityUserAccessor>();

builder.Services.AddScoped<IdentityRedirectManager>();

builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddIdentityCore<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AppInventarioContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<IdentityUser>, IdentityNoOpEmailSender>();

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

app.MapAdditionalIdentityEndpoints();;

app.Run();
