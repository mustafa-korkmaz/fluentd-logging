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

        while (true)
        {
            Thread.Sleep(5000);
            Random rnd = new Random();
            LogLevel logLevel = (LogLevel)rnd.Next(0,5);
            logger.Log(logLevel,$"Just a {logLevel:G} log recorded at {DateTime.UtcNow.ToLongTimeString()}");
        }
    }
}