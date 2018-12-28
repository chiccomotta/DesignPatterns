namespace StrategyPricingInfo
{
    internal class ConcreteStrategyB : IExecuteStrategy
    {
        public void Execute(PricingInfo pricingInfo)
        {
            pricingInfo.Executions.Add("Called ConcreteStrategyB.ApplyStrategies()");
        }
    }
}