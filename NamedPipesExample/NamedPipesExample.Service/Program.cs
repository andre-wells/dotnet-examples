using NamedPipesExample.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
        services.AddSingleton<NamedPipesServer>();
    })
    .Build();

await host.RunAsync();
