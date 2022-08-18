using LoginWorker;
using LoginWorker.Infra;
using LoginWorker.Service;
using Microsoft.EntityFrameworkCore;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        //EntityFramework
        services.AddSingleton<DbContextOptions<AppDbContext>>();
        services.AddSingleton<AppDbContext>();

        //Repository
        services.AddSingleton<LoginRepository>();

        //Services
        services.AddSingleton<LoginService>();

        //Application
        services.AddHostedService<Worker>();

        
    })
    .Build();

await host.RunAsync();
