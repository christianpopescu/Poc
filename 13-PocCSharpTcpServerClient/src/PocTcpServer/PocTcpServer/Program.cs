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

var logger = host.Services.GetRequiredService<ILoggerFactory>().CreateLogger("PocTcpServer");

CancellationTokenSource cancellationTokenSource = new();

Console.CancelKeyPress += (sender, e) =>
{
    logger.LogInformation("cancellation initiated by the user");
    cancellationTokenSource.Cancel();
};

try
{
    var service = host.Services.GetRequiredService<PocTcpServer>();
    
    await service.RunServerAsync(cancellationTokenSource.Token);

}
catch (Exception ex)
{
    logger.LogError(ex, ex.Message);
    Environment.Exit(-1);
}
Console.ReadLine();