using Serilog;
using WaterlooProject.Client;
using WaterlooProject.Services;
using WaterlooProject.Shared.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Application Services
builder.Services.AddScoped<IGoogleSearchService, GoogleSearchService>();

// Client Injections
builder.Services.AddHttpClient<IGoogleSearchClient, GoogleSearchClient>();
builder.Services.AddHttpClient<IBingSearchClient, BingSearchClient>();


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
