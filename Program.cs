using ITSA_Delon_Jarrod_naidoo.Data;
using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Logic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// Configuration
builder.Configuration.AddJsonFile("appsettings.json");

// Services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IAdmin, Admin>();

// Database
var connectionString = builder.Configuration.GetConnectionString("DBConnection")
    ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

builder.Services.AddDbContext<ITSADbContext>(options =>
    options.UseSqlServer(connectionString));

// Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(12);
        options.SlidingExpiration = false;
    });

var app = builder.Build();

// Ensure the database is created and seeded
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ITSADbContext>();
        context.Database.Migrate(); // Apply any pending migrations
        context.SeedData(); // Seed initial data
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occurred while migrating the database: " + ex.Message);
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
