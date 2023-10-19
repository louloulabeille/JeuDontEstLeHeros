
using JeuDontEstLeHeros.Instension.App;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JeuDontEstLeHeros.Core.Models.Identity;
using JeuDontEstLeHeros.Core.Infrastructure.Database;
using JeuDontEstLeHeros.Instension.Builder;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("IdentityHeros") ?? throw new InvalidOperationException("Connection string 'IdentityHeros' not found.");

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContextInstension(builder.Configuration);

builder.Services.AddDefaultIdentity<HerosIdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<HerosIdentityDbContext>();
builder.Services.AddRepoDataScopedInstension();
builder.Services.AddAuthenficationGoogleInstension(builder.Configuration); // -> authentification + google

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
app.UseAuthentication();
app.UseAuthorization();

/*app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

// m�thode d'instension pour ajout de route
app.AddMapControllerRouteInstensions();
app.MapRazorPages();

app.Run();
