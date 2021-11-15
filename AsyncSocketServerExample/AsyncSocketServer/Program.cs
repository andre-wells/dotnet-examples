// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;

Console.WriteLine("Hello, World!");

using var listenSocket = new Socket(SocketType.Stream, ProtocolType.Tcp);
listenSocket.Bind(new IPEndPoint(IPAddress.Loopback, 8080));

Console.WriteLine($"Listening on {listenSocket.LocalEndPoint}");

listenSocket.Listen();

while (true)
{
    // Wait for a new connection to arrive
    var connection = await listenSocket.AcceptAsync();
    Console.WriteLine("Accepting Connection... ");

    // We got a new connection spawn a task to so that we can echo the contents of the connection
    _ = Task.Run(async () =>
    {
        var buffer = new byte[4096];
        try
        {
            while (true)
            {
                Console.WriteLine("Recieving ... ");
                int read = await connection.ReceiveAsync(buffer, SocketFlags.None);
                if (read == 0)
                {
                    break;
                }
                Console.WriteLine("Sending ... ");
                await connection.SendAsync(buffer[..read], SocketFlags.None);
            }
        }
        finally
        {
            Console.WriteLine("Connection Closed.");
            connection.Dispose();
        }
    });
}