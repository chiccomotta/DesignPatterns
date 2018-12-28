using System.Collections.Generic;

namespace StrategyPricingInfo
{
    public class Context
    {
        private readonly PricingInfo PricingInfo;
        private ILoggingService Logger;

        public Context(ILoggingService logger)
        {
            this.Logger = logger;
            this.PricingInfo = new PricingInfo()
            {
                Executions = new List<string>()
            };
        }
        
        public PricingInfo ApplyStrategies(List<IExecuteStrategy> strategies)
        {
            Logger.Log("Applying strategies...");
            strategies.ForEach(s => s.Execute(PricingInfo));
            return PricingInfo;
        }
    }
}