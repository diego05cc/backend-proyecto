using backend_proyecto.Context;
using backend_proyecto.Repositories;
using Microsoft.EntityFrameworkCore;
using backend_proyecto.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var Conect = builder.Configuration.GetConnectionString("conection");
builder.Services.AddDbContext<TimeTrackingContext>(options => options.UseSqlServer(Conect));

builder.Services.AddScoped<IEmployedRepository,EmployedRepository>();
builder.Services.AddScoped<IEmployedservices, Employedservices>();
builder.Services.AddScoped<IEmployedProjectRepository,EmployedProjectRepository>();
builder.Services.AddScoped<IEmployedprojectservices, Employedprojectservices>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IProjectservices, Projectservices>();
builder.Services.AddScoped<IRegisteroftimeRepository,RegisteroftimeRepository>();
builder.Services.AddScoped<IRegisteroftimeservices,Registeroftimeservices>();
builder.Services.AddScoped<ITasksRepository, TasksRepository>();
builder.Services.AddScoped<ITaskservices, Taskservices>();


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
