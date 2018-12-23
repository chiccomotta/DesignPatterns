using System;

namespace GenericCommandPattern
{
    /*** Command Pattern con interfaccia Command di tipo ICommand<T> dove T è il tipo del payload ***/
    class Program
    {
        static void Main(string[] args)
        {
            ICommand<PersonInfo>[] commands =
            {
                new RegisterPersonCommand(),
                new UnregisterPersonCommand()
            };

            var person = new PersonInfo()
            {
                FirstName = "Cristiano",
                LastName = "Motta",
                Id = 1
            };

            foreach (var command in commands)
            {
                Console.WriteLine($"Executing command {command.ToString()}");
                command.Execute(person);
            }

            Console.ReadKey();
        }
    }

    public class PersonInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }

    public interface ICommand<in T>
    {
        bool Execute(T data);
    }

    public class RegisterPersonCommand : ICommand<PersonInfo>
    {
        public bool Execute(PersonInfo personInfo)
        {
            Console.WriteLine($"Person {personInfo.ToString()} Registered succesfully");
            return true;
        }
    }

    public class UnregisterPersonCommand : ICommand<PersonInfo>
    {  
        public bool Execute(PersonInfo personInfo)
        {
            Console.WriteLine($"Person {personInfo.ToString()} Unregistered succesfully");
            return true;
        }
    }
}
