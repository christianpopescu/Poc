using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PocTcpServer
{
    record PocTcpServerOptions
    {
        public int Port { get; init; }
    }
    internal class PocTcpServer
    {
        private readonly int _port;
        private readonly ILogger _logger;
    }
}
