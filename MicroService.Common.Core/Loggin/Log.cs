using System;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace MicroService.Common.Core.Loggin
{
    public static class Log
    {
        public static void ConfigureElasticSearachLog(string url)
        {
            var loggerConfig = new LoggerConfiguration().WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(url))
            {
                CustomFormatter = new ExceptionAsObjectJsonFormatter(renderMessage: true),
                FailureCallback = e => Console.WriteLine("Unable to submit event " + e.MessageTemplate),
                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog     |
                                   EmitEventFailureHandling.WriteToFailureSink |
                                   EmitEventFailureHandling.RaiseCallback,
            });

            var logger = loggerConfig.CreateLogger();
            Serilog.Log.Logger = logger;
        }
    }
}