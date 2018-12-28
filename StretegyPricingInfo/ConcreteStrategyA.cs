namespace StrategyPricingInfo
{
    internal class ConcreteStrategyA : IExecuteStrategy
    {
        public void Execute(PricingInfo pricingInfo)
        {
            pricingInfo.Executions.Add("Called ConcreteStrategyA.Execute()");
        }
    }
}