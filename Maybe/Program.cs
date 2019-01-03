using System;
using System.Net;

namespace Maybe
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test
            Maybe<Foo> foo = FindFoo(1);
            Console.WriteLine(foo.HasValue());
            Console.WriteLine(foo.Value);

            foo = FindFoo(0);
            Console.WriteLine(foo.HasValue());
            // Console.WriteLine(foo.Value);  // this throws an error

            // Maybe Case extension
            var fooId = foo.Case(x => x.Id, () => 0);
            Console.WriteLine($"fooId: {fooId}");

            // Maybe AsMaybe extension
            var foo2 = new Foo(2).AsMaybe();
            Console.WriteLine($"foo2: {foo2.Value}");

            var foo3 = FooNull();
            Console.WriteLine($"foo3 HasValue: {foo3.AsMaybe().HasValue()}");
            
            Console.ReadKey();
        }

        public static Maybe<Foo> FindFoo(int id)
        {
            if (id == 0)
            {
                return new None<Foo>();
            }

            return new Some<Foo>(new Foo(1));
        }

        public static object FooNull()
        {
            return null;
        }
    }
}
