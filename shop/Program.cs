using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using shop.Data;
using shop.Plugins.EFCore;
using shop.UseCases;
using shop.UseCases.Interfaces;
using shop.UseCases.pluginInterfaces;
using Shop.Plugins.EFCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContext<shopContext>(options =>
{
    options.UseInMemoryDatabase("shop");
});

builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ILoadProductsUseCase, LoadProductsUseCase>();
builder.Services.AddTransient<IUpdateProductUseCase, UpdateProductUseCase>();


builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IAddOrderUseCase, AddOrderUseCase>();
builder.Services.AddTransient<ILoadOrderUseCase, LoadOrderUseCase>();

var app = builder.Build();

var scope = app.Services.CreateScope();
var ShopContext = scope.ServiceProvider.GetRequiredService<shopContext>();
ShopContext.Database.EnsureDeleted();
ShopContext.Database.EnsureCreated();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
