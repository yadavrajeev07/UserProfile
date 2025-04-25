using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using userprofileapp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<ILocationService, LocationService>();

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IMongoClient>(ServiceProvider =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDbConnection")));
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
