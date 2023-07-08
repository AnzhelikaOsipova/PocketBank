using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace PocketBank.User.WebApi.Common.DependencyInjection
{
    public static class LoggingDI
    {
        public static void AddLogging(this ILoggingBuilder loggingBuilder, IConfiguration configuration) 
        {
            var loggerConfig = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            loggingBuilder.ClearProviders();
            loggingBuilder.AddSerilog(loggerConfig);
        }
    }
}
