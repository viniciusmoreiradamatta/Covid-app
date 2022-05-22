using CovidService.Application.Interfaces;
using CovidService.Application.Services;
using CovidService.Data.Context;
using CovidService.Data.Repository;
using CovidService.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddDbContext<CovidContext>(op =>
    op.UseSqlServer(builder.Configuration.GetConnectionString("mssqlCnn")));

builder.Services.AddScoped<ICovidAppService, CovidAppService>();

builder.Services.AddScoped<ICovidRepository, CovidRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();