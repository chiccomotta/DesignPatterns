using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace StrategyPricingInfo
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Registro i servizi nel container
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILoggingService, LoggingService>()
                .AddSingleton(typeof(Context))
                .BuildServiceProvider();

            Context context;

            var strategies = new List<IExecuteStrategy>()
            {
                new ConcreteStrategyA(),
                new ConcreteStrategyB(),
                new ConcreteStrategyC()
            };

            // One context following three different strategies
            context = serviceProvider.GetService<Context>();
            var pricingInfo = context.ApplyStrategies(strategies);

            // Debug
            pricingInfo.Executions.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }

    public interface ILoggingService
    {
        void Log(string message);
    }

    public class LoggingService : ILoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
