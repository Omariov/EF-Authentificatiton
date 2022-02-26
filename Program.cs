using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using test.Pages.Admin;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
.AddCookie(options => { options.LoginPath = "/Login"; });

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<EtudianrDbContexte>();
builder.Services.AddDbContext<EtudianrDbContexte>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("mydb")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
