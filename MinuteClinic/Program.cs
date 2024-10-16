using Microsoft.EntityFrameworkCore;
using MinuteClinic.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MinuteClinicContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MinuteClinicContext")));


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


// map route for Admin area

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// map route for default area
app.MapControllerRoute(
    name: "main",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");



app.Run();