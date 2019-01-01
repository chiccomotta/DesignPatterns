using System;

namespace Maybe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test Maybe
            var foo = new Foo();
            var maybeFooNotNull = new Some<Foo>(foo);
            var maybeFooNull = new None<Foo>();

            Console.WriteLine(maybeFooNotNull.HasValue());
            Console.WriteLine(maybeFooNotNull.Value());
            Console.WriteLine(maybeFooNull.HasValue());

            Console.ReadKey();
        }
    }
}
