using H.Pipes;
using H.Pipes.Args;
using NamedPipesExample.Common;

namespace NamedPipesExample.Service;

public class NamedPipesServer : IAsyncDisposable
{
    const string PIPE_NAME = "samplepipe";

    private PipeServer<PipeMessage> server;

    public NamedPipesServer()
    {
        server = new PipeServer<PipeMessage>(PIPE_NAME);
    }

    public async Task InitializeAsync()
    {
        server.ClientConnected += async (o, args) => await OnClientConnectedAsync(args);
        server.ClientDisconnected += (o, args) => OnClientDisconnected(args);
        server.MessageReceived += (sender, args) => OnMessageReceived(args.Message);
        server.ExceptionOccurred += (o, args) => OnExceptionOccurred(args.Exception);


        await server.StartAsync();
    }


    private async Task OnClientConnectedAsync(ConnectionEventArgs<PipeMessage> args)
    {
        Console.WriteLine($"Client {args.Connection.Id} is now connected!");

        await args.Connection.WriteAsync(new PipeMessage
        {
            Action = ActionType.SendText,
            Text = "Hi from server"
        });
    }

    private void OnClientDisconnected(ConnectionEventArgs<PipeMessage> args)


    {
        Console.WriteLine($"Client {args.Connection.Id} disconnected");
    }

    private void OnMessageReceived(PipeMessage? message)
    {
        ArgumentNullException.ThrowIfNull(nameof(message));
        switch (message!.Action)
        {
            case ActionType.SendText:
                Console.WriteLine($"Text from client: {message.Text}");
                break;

            case ActionType.ShowTrayIcon:
                throw new NotImplementedException();

            case ActionType.HideTrayIcon:
                throw new NotImplementedException();

            default:
                Console.WriteLine($"Unknown Action Type: {message.Action}");
                break;
        }
    }

    private void OnExceptionOccurred(Exception ex)
    {
        Console.WriteLine($"Exception occured in pipe: {ex}");
    }

    #region Dispose Implementation

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore();
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        if (server is not null)
        {
            await server.DisposeAsync().ConfigureAwait(false);
        }
    }

    #endregion Dispose Implementation
}