using SerieAFantasyGame.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStatisticsRepository, MockStatisticsRepository>();
builder.Services.AddScoped<IPlayerRepository, MockPlayerRepository>();
builder.Services.AddDbContext<SerieAFantasyGameDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:SerieAFantasyGameDbContextConnection"]));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.UseStaticFiles();
app.MapDefaultControllerRoute();
app.Run();
