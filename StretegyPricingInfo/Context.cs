namespace StrategyPricingInfo
{
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