using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<StoreDbContext>(opts =>
{
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});
builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();

app.UseStaticFiles();

// Routing
app.MapControllerRoute("catpage",
    "{category}/Page{productPage:int}",
    new {Controller = "Home", action = "Index"});

app.MapControllerRoute("page",
    "Page{productPage:int}",
    new {Controller = "Home", action = "Index", productPage = 1});

app.MapControllerRoute("category",
    "{category}",
    new {Controller = "Home", action = "Index", productPage = 1});

app.MapControllerRoute("pagination",
    "Product/Page{productPage}",
    new {Controller = "Home", action = "Index", productPage = 1});
//End Routing
app.MapDefaultControllerRoute();
SeedData.Ensurepopulated(app);
app.Run();