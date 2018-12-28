using System;
using System.Collections.Generic;

namespace StrategyPricingInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            Context context;
            var pricingInfo = new PricingInfo()
            {
                Executions = new List<string>()
            };

            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA(), pricingInfo);
            context.Execute();

            context = new Context(new ConcreteStrategyB(), pricingInfo);
            context.Execute();

            context = new Context(new ConcreteStrategyC(), pricingInfo);
            context.Execute();

            // Debug
            pricingInfo.Executions.ForEach(Console.WriteLine);

            Console.ReadKey();
        }
    }

    public class Context
    {
        private readonly IExecuteStrategy Strategy;
        private readonly PricingInfo PricingInfo;

        public Context(IExecuteStrategy strategy, PricingInfo pricingInfo)
        {
            this.Strategy = strategy;
            this.PricingInfo = pricingInfo;
        }

        public void Execute()
        {
            Strategy.Execute(PricingInfo);
        }
    }
}
