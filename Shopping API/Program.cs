using Microsoft.AspNetCore.OData;
using Newtonsoft.Json;
using Shopping.Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Add services to the container.

services.AddDbContexts(configuration);
services.AddRepositories(configuration);
services.AddApplicationServices(configuration);
services.AddMediatR(configuration);

services.AddCors();
services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    )
    .AddOData(options => {
        var oDataEdmProvider = new ODataEdmProvider();

        options.AddRouteComponents("odata", oDataEdmProvider.GetEdmModel());
        options.Select().Filter().OrderBy();
     });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

app.UseODataRouteDebug();
app.UseODataQueryRequest();
app.UseODataBatching();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
