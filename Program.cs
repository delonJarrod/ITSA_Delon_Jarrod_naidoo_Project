using ITSA_Delon_Jarrod_naidoo.Interface;
using ITSA_Delon_Jarrod_naidoo.Logic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ITSA_Delon_Jarrod_naidoo.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DBConnection")
    ?? throw new InvalidOperationException("Connection string 'DBConnection' not found.");

// Services Configuration
builder.Services.AddDbContext<ITSADbContext>(options => options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAdmin, Admin>();


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
