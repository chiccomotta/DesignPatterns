using System;
using System.Collections;

// ReSharper disable All

namespace StrategyPattern
{
    /* Strategy Pattern
        
       Il pattern Strategy permette di definire una famiglia di algoritmi, di incapsularli e renderli intercambiabili fra loro. 
       Questo pattern consente agli algoritmi di variare in modo indipendente rispetto al loro contesto di utilizzo, 
       fornendo un basso accoppiamento tra le classi partecipanti del pattern e una alta coesione funzionale 
       delle diverse strategie di implementazione.
       
       Participants

       The classes and objects participating in this pattern are:

       - Strategy  (IStrategy)
         declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined 
         by a ConcreteStrategy
       
       - ConcreteStrategy  (ConcreteStrategyA, ConcreteStrategyB, ConcreteStrategyC)
         implements the algorithm using the Strategy interface
       
       - Context  (Context)
         is configured with a ConcreteStrategy object
         maintains a reference to a Strategy object
         may define an interface that lets Strategy access its data.
    */

    class Program
    {
        static void Main(string[] args)
        {
            Context context;

            // Three contexts following different strategies
            context = new Context(new ConcreteStrategyA());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyB());
            context.ContextInterface();

            context = new Context(new ConcreteStrategyC());
            context.ContextInterface();
            
            Console.ReadKey();
        }
    }

    public interface IStrategy
    {
        void AlgorithmInterface();
    }

    class ConcreteStrategyA : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyA.AlgorithmInterface()");
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyB.AlgorithmInterface()");
        }
    }
    
    class ConcreteStrategyC : IStrategy
    {
        public void AlgorithmInterface()
        {
            Console.WriteLine("Called ConcreteStrategyC.AlgorithmInterface()");
        }
    }

    class Context
    {
        private IStrategy strategy;

        public Context(IStrategy _strategy)
        {
            this.strategy = _strategy;
        }

        public void ContextInterface()
        {
            strategy.AlgorithmInterface();
        }
    }
}
   
