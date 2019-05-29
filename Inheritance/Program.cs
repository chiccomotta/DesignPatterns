using System;

namespace Inheritance
{
    class Program
    {
        public class BaseC
        {
            public static int x = 55;
            public static int y = 22;
        }

        public class DerivedC : BaseC
        {
            // Hide field 'x'.
            public new static int x = 100;

            static void Main()
            {
                // Display the new value of x:
                Console.WriteLine(x);

                // Display the hidden value of x:
                Console.WriteLine(BaseC.x);

                // Display the unhidden member y:
                Console.WriteLine(y);

                Console.ReadKey();
            }
        }
    }
}
