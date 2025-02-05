var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IStatisticsRepository, MockStatisticsRepository>();
builder.Services.AddScoped<IPlayerRepository, MockPlayerRepository>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
app.MapDefaultControllerRoute();
app.Run();
