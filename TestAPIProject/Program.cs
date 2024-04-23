using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestAPIProject.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//yesle chai routing dinxa
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//dependecy injection of DbContext
builder.Services.AddDbContext<APIDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();


// Configure the HTTP request pipeline.swagger used for running
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
