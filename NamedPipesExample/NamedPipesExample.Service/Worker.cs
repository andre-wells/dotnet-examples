namespace NamedPipesExample.Service;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly NamedPipesServer _server;

    public Worker(ILogger<Worker> logger, NamedPipesServer server)
    {
        _logger = logger;
        _server = server;
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await _server.InitializeAsync();
        await base.StartAsync(cancellationToken);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
        while (!stoppingToken.IsCancellationRequested)
        {
            
        }
        return Task.CompletedTask;
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Stopping Worker ...");
        return base.StopAsync(cancellationToken);
    }
}
