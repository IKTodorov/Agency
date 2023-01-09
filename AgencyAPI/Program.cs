using AgencyData.DBContext;
using AgencyServices.Services;
using AgencyServices.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AgencyContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IJourneyService, JourneyService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IBusService, BusService>();
builder.Services.AddScoped<ITrainService, TrainService>();
builder.Services.AddScoped<IAirplaneService, AirplaneService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
