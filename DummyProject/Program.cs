using System;

namespace DummyProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Strategy Pattern Demo***\n");
            IChoice ic = null;
            Context cxt = new Context();
            //For simplicity, we are considering 2 user inputs only.
            for (int i = 1; i <= 2; i++)
            {
                Console.WriteLine("\nEnter ur choice(1 or 2)");

                string c = Console.ReadLine();
                if (c.Equals("1"))
                {
                    ic = new FirstChoice();
                }
                else
                {
                    ic = new SecondChoice();
                }

                cxt.SetChoice(ic);
                cxt.ShowChoice();
            }
            Console.ReadKey();
        }
    }    

    // IChoice.cs

    public interface IChoice
    {
        void MyChoice();
    }

    // FirstChoice.cs
    public class FirstChoice : IChoice
    {
        public void MyChoice()
        {
            Console.WriteLine("Traveling to Japan");
        }
    }

// SecondChoice.cs
    public class SecondChoice : IChoice
    {
        public void MyChoice()
        {
            Console.WriteLine("Traveling to India");
        }
    }

    public class Context
    {
        IChoice choice;
        /*It's our choice. We prefer to use a setter method instead of
       using a constructor. We can call this method whenever we want to
       change the "choice behavior" on the fly*/
        public void SetChoice(IChoice choice)
        {
            this.choice = choice;
        }
        /* This method will help us to delegate the particular
        object's choice behavior/characteristic*/
        public void ShowChoice()
        {
            this.choice.MyChoice();
        }
    }   
}
