using SerieAFantasyGame.Models;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStatisticsRepository, MockStatisticsRepository>();
builder.Services.AddScoped<IPlayerRepository, MockPlayerRepository>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
