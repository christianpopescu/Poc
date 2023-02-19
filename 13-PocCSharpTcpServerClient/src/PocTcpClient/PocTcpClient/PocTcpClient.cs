using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Net.Sockets;
using System.Text;


record PocTcpOptions
{
    public string? Hostname { get; init; }
    public int ServerPort { get; init; }
}
class PocTcpClient
{
    private readonly string _hostname;
    private readonly int _serverPort;
    private readonly ILogger _logger;

    public PocTcpClient(IOptions<PocTcpOptions> options, ILogger<PocTcpClient> logger)
    {
        _hostname = options.Value.Hostname ?? "localhost";
        _serverPort = options.Value.ServerPort;
        _logger = logger;
    }

    public async Task SendAndReceiveAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            Memory<byte> buffer = new byte[4096].AsMemory();
            Memory<byte> bufferIn = new byte[4096].AsMemory();
            string? line;
            bool repeat = true;
            TcpClient client = new();
            await client.ConnectAsync(_hostname, _serverPort, cancellationToken);
            using var stream = client.GetStream();
            while (repeat)
            {
                Console.WriteLine(@"Press <enter> to request answer from server, ""exit"" to exit");
                line = Console.ReadLine();
                if (line?.Equals("exit", StringComparison.CurrentCultureIgnoreCase) == true)
                {
                    repeat = false;
                }
                else
                {

                    buffer = Encoding.UTF8.GetBytes(line).AsMemory();
                    await stream.WriteAsync(buffer, cancellationToken);
                    //Thread.Sleep(30000);
                    int bytesRead = await stream.ReadAsync(bufferIn, cancellationToken);
                    string answer = Encoding.UTF8.GetString(bufferIn.Span[..bytesRead]);
                    bufferIn.Span[..bytesRead].Clear();
                    Console.WriteLine(answer);
                    Console.WriteLine();
                }
            };
        }
        catch (SocketException ex)
        {
            _logger.LogError(ex, ex.Message);
        }

        Console.WriteLine("so long, and thanks for all the fish");
    }
}

