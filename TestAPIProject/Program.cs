using Microsoft.EntityFrameworkCore;
using Serilog;
using TestAPIProject.Data;
using WebApi.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//yesle chai routing dinxa
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//ya chai exception handel

//dependecy injection of DbContext
builder.Services.AddDbContext<APIDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
////logging ko lagi 
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();
var app = builder.Build();

app.UseSerilogRequestLogging();
// Configure the HTTP request pipeline.swagger used for running
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ErrorHandlerMiddleware>();
app.MapControllers();

app.Run();

