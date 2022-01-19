using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.OData;
using Newtonsoft.Json;
using Shopping.Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

#region DI Setup


services.AddHangfireServer();
services.AddHangfire(config =>
                config.UsePostgreSqlStorage(configuration.GetConnectionString("ShoppingList")));
services.AddDbContexts(configuration);
services.AddRepositories(configuration);
services.AddApplicationServices(configuration);
services.AddMediatR(configuration);

services.AddCors();
services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
    )
    .AddODataConfiguration(configuration);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

#endregion

#region Middleware Setup

var app = builder.Build();

app.UseHangfireDashboard();

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

#endregion