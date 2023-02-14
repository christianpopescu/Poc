using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
//using PocTcpServer;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var settings = context.Configuration;
        services.Configure<PocTcpServerOptions>(settings.GetSection("PocTcpServer"));
        services.AddTransient<PocTcpServer>();
    })
    .Build();

Console.WriteLine("Running");