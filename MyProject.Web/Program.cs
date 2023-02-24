using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//21. we no longer use the 'ApplicationDbContext' in 'MyProject.Web.Data' but the 'MyProjectDbContext' in 'MyProject.DAL'
//using MyProject.Web.Data; //21
using MyProject.DAL;

//22. change the refernece from the 'User' in 'MyProject.Web.Model' to the 'User' in 'MyProject.BL.Entities'
//using MyProject.Web.Models;   //22
using MyProject.BL.Entities;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//21. change from 'ApplicationDbContext' to 'MyProjectDbContext'
builder.Services.AddDbContext<MyProjectDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//6. change 'IdentityUser' to 'User' and add some changes
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyProjectDbContext>()
    .AddDefaultUI() //6
    .AddDefaultTokenProviders();    //6

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();   //6

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
