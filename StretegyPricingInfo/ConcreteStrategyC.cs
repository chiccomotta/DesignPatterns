namespace StrategyPricingInfo
{
    internal class ConcreteStrategyC : IExecuteStrategy
    {       
        public void Execute(PricingInfo pricingInfo)
        {
            pricingInfo.Executions.Add("Called ConcreteStrategyC.ApplyStrategies()");
        }
    }
}