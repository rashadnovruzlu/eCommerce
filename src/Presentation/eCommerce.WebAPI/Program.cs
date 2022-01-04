using eCommerce.Application;
using eCommerce.Persistence;
using eCommerce.Infrastructure;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
// Add services to the container.

builder.Services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddPersistence(builder.Configuration);
services.AddInfrastructure(builder.Configuration);
services.AddCore();
services.AddVersionedApiExplorer(o =>
{
    o.GroupNameFormat = "'v'VVV";
    o.SubstituteApiVersionInUrl = true;
});

services.AddApiVersioning(config =>
{
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
    config.ReportApiVersions = true;
});
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
