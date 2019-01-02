using System;

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
    }
}
