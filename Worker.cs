namespace zeebeWorker;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    public Worker(ILogger<Worker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var mode = Environment.GetEnvironmentVariable("ZEEBE_WORKER_MODE");
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("==> Zeebe worker is running at: {time} {mode}", DateTimeOffset.Now, mode);
            await Task.Delay(1000, stoppingToken);
        }
    }
}
