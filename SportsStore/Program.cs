var builder = WebApplication.CreateBuilder();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();