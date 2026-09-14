using System.Reflection;
using FlightBooking.Services.FlightServices;
using FlightBooking.Settings;
using Microsoft.Extensions.Options;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);

// 1. .env dosyasındaki ortam değişkenlerini yükle
Env.Load();

// 2. .env veya appsettings.json üzerindeki değerleri oku
var connectionString = Environment.GetEnvironmentVariable("MONGODB_URI") 
    ?? builder.Configuration["DatabaseSettingsKey:ConnectionString"];

var databaseName = Environment.GetEnvironmentVariable("MONGODB_DATABASE") 
    ?? builder.Configuration["DatabaseSettingsKey:DatabaseName"];

var collectionName = Environment.GetEnvironmentVariable("MONGODB_COLLECTION") 
    ?? builder.Configuration["DatabaseSettingsKey:FlightCollectionName"];

// 3. IDatabaseSettings nesnesini oluşturup AddSingleton/AddScoped ile kaydet
var databaseSettings = new DatabaseSettings
{
    ConnectionString = connectionString!,
    DatabaseName = databaseName!,
    FlightCollectionName = collectionName!
};

builder.Services.AddSingleton<IDatabaseSettings>(databaseSettings);
builder.Services.AddScoped<IFlightService, FlightService>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddControllersWithViews();

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

app.MapStaticAssets();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
