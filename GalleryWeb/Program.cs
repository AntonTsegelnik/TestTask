
using GalleryWeb.Services;
using GalleryWeb.Services.IImageServices;
using Data.Sql;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Data.Sql.Repositories;
using Data.Interface.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IImageService>(
    diContainer => new ImageService(diContainer.GetService<IImageRepository>()));
builder.Services.AddScoped<ICommentService>(
    diContainer => new CommentService(diContainer.GetService<IImageRepository>(),diContainer.GetService<ICommentRepository>()));



//builder.Services.AddSingleton<IImageRepository>(diContainer => new ImageRepositoryFake());
builder.Services.AddScoped<IImageRepository>(diContainer => new ImageRepository(diContainer.GetService<WebContext>()));
builder.Services.AddScoped<ICommentRepository>(diContainer => new CommentRepository(diContainer.GetService<WebContext>()));


var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);



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
