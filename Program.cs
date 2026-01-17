using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using studentMangementSystem.Data;
using studentMangementSystem.Models;
using studentMangementSystem.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));




builder.Services.AddScoped<StudentMangement>();
builder.Services.AddScoped<SubjectServices>();
builder.Services.AddScoped<DepartmentService>();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();
app.UseSession();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


//if (!context.Admins.Any())
//{
//    context.Admins.Add(new Admin
//    {
//        Email = "admin@system.com",
//        PasswordHash = PasswordHasher.Hash("Admin123!")
//    });

//    context.SaveChanges();
//}


using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider
        .GetRequiredService<AppDbContext>();

    if (!context.Admin.Any())
    {
        context.Admin.Add(new Admin
        {
            Email = "admin@system.com",
            PasswordHash = PasswordHasher.Hash("Admin123!")
        });

        context.SaveChanges();
    }
}




app.Run();
