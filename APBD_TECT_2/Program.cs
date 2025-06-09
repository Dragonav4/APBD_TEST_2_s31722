using APBD_TECT_2.Data;
using APBD_TECT_2.Exceptions;
using APBD_TECT_2.Interfaces;
using APBD_TECT_2.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("Default")
    ));
builder.Services.AddControllers();
builder.Services.AddScoped<IRacerService, RacerService>();
builder.Services.AddScoped<ITrackRacesService, TrackRacesService>();
var app = builder.Build();

app.UseMiddleware<ApiExceptionMiddleware>();

app.MapControllers();
app.Run();