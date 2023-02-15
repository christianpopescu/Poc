using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Net;
using System.Net.Sockets;
using System.Text;

//namespace PocTcpServer
//{
record PocTcpServerOptions
{
    public int Port { get; init; }
}

class PocTcpServer
{
    private readonly int _port;
    private readonly ILogger _logger;

    /// <summary>
    ///  Constructor used to insert options and logger
    /// </summary>
    /// <param name="options"></param>
    /// <param name="logger"></param>
    public PocTcpServer(IOptions<PocTcpServerOptions> options, ILogger<PocTcpServer> logger)
    {
        _port = options.Value.Port;
        _logger = logger;
    }

    public async Task RunServerAsync(CancellationToken cancellationToken = default)
    {
        TcpListener listener = new(IPAddress.Any, _port);
        _logger.LogInformation("Poc Tcp Server listener started on port {port}", _port);
        listener.Start();

        while (true)
        {
            cancellationToken.ThrowIfCancellationRequested();
            using TcpClient client = await listener.AcceptTcpClientAsync();
            _logger.LogInformation("Client connected with address and port: {port}", client.Client.RemoteEndPoint);
            string message = await ReadMessageAsync(client,cancellationToken);
            var _ = SendMessageAsync(client, message, cancellationToken);
        }
    }

    private async Task SendAnswerAsync(TcpClient client, CancellationToken cancellationToken = default)
    {
        try
        {
            client.LingerState = new LingerOption(true, 10);
            client.NoDelay = true;

            using var stream = client.GetStream(); // returns a stream that owns the socket
            string answer = "Answer from server";
            var buffer = Encoding.UTF8.GetBytes(answer).AsMemory();
            await stream.WriteAsync(buffer, cancellationToken);
        }
        catch (IOException ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        catch (SocketException ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    private async Task SendMessageAsync(TcpClient client, string message, CancellationToken cancellationToken = default)
    {
        try
        {
            client.LingerState = new LingerOption(true, 10);
            client.NoDelay = true;

            using var stream = client.GetStream(); // returns a stream that owns the socket
            var buffer = Encoding.UTF8.GetBytes(message).AsMemory();
            await stream.WriteAsync(buffer, cancellationToken);
        }
        catch (IOException ex)
        {
            _logger.LogError(ex, ex.Message);
        }
        catch (SocketException ex)
        {
            _logger.LogError(ex, ex.Message);
        }
    }

    private async Task<string> ReadMessageAsync(TcpClient client, CancellationToken cancellationToken = default)
    {
        try
        {
            Memory<byte> buffer = new byte[4096].AsMemory();
            client.LingerState = new LingerOption(true, 10);
            client.NoDelay = true;

            using var stream = client.GetStream(); // returns a stream that owns the socket
                                                   //var buffer = Encoding.UTF8.GetBytes(message).AsMemory();
                                                   //await stream.WriteAsync(buffer, cancellationToken);
            int bytesRead = await stream.ReadAsync(buffer, cancellationToken);
            string answer = Encoding.UTF8.GetString(buffer.Span[..bytesRead]);
            buffer.Span[..bytesRead].Clear();
            return answer;
        }
        catch (IOException ex)
        {
            _logger.LogError(ex, ex.Message);
            return "";
        }
        catch (SocketException ex)
        {
            _logger.LogError(ex, ex.Message);
            return "";
        }
    }

}

//}
