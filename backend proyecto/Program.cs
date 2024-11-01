using backend_proyecto.context;
using backend_proyecto.Repositories;
using backend_proyecto.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Conect = builder.Configuration.GetConnectionString("conection");
builder.Services.AddDbContext<TimeTrackingContext>(options => options.UseSqlServer(Conect));

builder.Services.AddScoped<IEmployedRepository,EmployedRepository>();
builder.Services.AddScoped<IEmployedservices,Employedservices>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



   app.UseSwagger();
   app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
