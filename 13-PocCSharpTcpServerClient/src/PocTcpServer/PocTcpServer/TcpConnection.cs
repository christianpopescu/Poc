using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

//namespace PocTcpServer
//{
    internal class TcpConnection
    {
        public TcpClient TheTcpClient;

        public NetworkStream TheStream;

        public TcpConnection(TcpClient theTcpClient)
        {
            TheTcpClient = theTcpClient;
            TheTcpClient.LingerState = new LingerOption(true, 10);
            TheTcpClient.NoDelay = true;
            TheStream = theTcpClient.GetStream();
        }

         ~TcpConnection()
        {
            TheTcpClient.Close();
            TheStream.Close();
        }
    }
//}
