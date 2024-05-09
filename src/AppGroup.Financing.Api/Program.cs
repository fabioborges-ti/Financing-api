using AppGroup.Financing.API;
using AppGroup.Financing.API.Core.Middlewares;
using AppGroup.Financing.Infraesture.Database.Context;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;

try
{
    var builder = WebApplication.CreateBuilder(args);

    var startup = new Startup(builder.Configuration);

    startup.ConfigureServices(builder.Services);

    var app = builder.Build();

    #region MIGRATIONS

    using var scope = app.Services.CreateScope();

    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    db.Database.Migrate();

    #endregion

    app.UseMiddleware<ErrorHandlerMiddleware>();

    var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

    startup.Configure(app, provider);

    app.Run();
}
catch (Exception ex)
{
    //Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    //Log.Information("Server Shutting down...");
    //Log.CloseAndFlush();
}