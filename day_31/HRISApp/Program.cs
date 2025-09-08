using HRISApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Repos;
using Repos.Repos;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var conn = builder.Configuration.GetConnectionString("RepoContext") ?? throw new InvalidOperationException("Connection string 'RepoContext' not found.");
builder.Services.AddDbContext<RepoContext>(options =>
    options.UseSqlServer(conn));
builder.Services.AddScoped<IDept, Dept>();
builder.Services.AddScoped<DepartmentService, DepartmentService>();

// Generic Repository Pattern
builder.Services.AddScoped<IRepogeneric<Models.Department>, Repogeneric<Models.Department>>();
//builder.Services.AddScoped<IRepogeneric<Models.Employee>, Repogeneric<Models.Employee>>();
builder.Services.AddScoped<IServiceClass<Department>, IServiceClass<Department>>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
