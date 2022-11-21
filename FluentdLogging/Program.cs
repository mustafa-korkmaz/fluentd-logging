using Microsoft.Extensions.Logging;

class Program
{
    static void Main(string[] args)
    {
        using var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder
                .AddFilter("Microsoft", LogLevel.Warning)
                .AddFilter("System", LogLevel.Warning)
                .AddFilter("Program", LogLevel.Trace)
                .AddConsole();
        });

        ILogger logger = loggerFactory.CreateLogger<Program>();

        logger.LogTrace("A trace level log");

        logger.LogInformation("An information level log");

        Console.WriteLine("A Console.WriteLine log");
    }
}