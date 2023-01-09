using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{

// Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddScoped<IBreakfastService,breakfastService>();
}   
var app = builder.Build();
{
// Configure the HTTP request pipeline.

    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
