using Business;
using Business.Interfaces;
using Data;
using Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BitrixJsonExporter;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        
        var services = new ServiceCollection();
        ConfigureServices(services);

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var form = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form);
        }
        

    }

    private static void ConfigureServices(ServiceCollection services)
    {
        services
            .AddScoped<Form1>()
            .AddScoped<IExporter, Exporter>()
            .AddHttpClient()
            .AddScoped<IHttpService,HttpService>()
            .AddScoped<ITasksService, TasksService>();
    }
}