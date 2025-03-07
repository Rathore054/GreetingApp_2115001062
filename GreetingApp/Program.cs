
using NLog;
using NLog.Web;
using NLog.Config;
using BuisnessLayer.Interface;
using BuisnessLayer.Service;
using RepositeryLayer.Interface;
using RepositeryLayer.Service;
using Microsoft.EntityFrameworkCore;
using RepositeryLayer.Context;


var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
LogManager.Configuration= new XmlLoggingConfiguration("C:\\Users\\Udit\\source\\repos\\GreetingApp\\Nlog.Config");
logger.Info("Application is starting...");

try
{
    var builder = WebApplication.CreateBuilder(args);



    // Add NLog as logging provider
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 41))));

    // Add services to the container
    builder.Services.AddControllers();
    builder.Services.AddSwaggerGen();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddScoped<IGreetingAppBL, GreetingAppBL>();
    builder.Services.AddScoped<IGreetingAppRL, GreetingAppRL>();
    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Configure the HTTP request pipeline
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();


}
catch (Exception ex)
{
    logger.Error(ex, "Application startup failed.");
    throw;
}
finally
{
    LogManager.Shutdown(); // Ensures all logs are flushed before exit
}
