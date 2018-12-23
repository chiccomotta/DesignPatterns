using System;

namespace CommandPattern
{
    /* Command Pattern
     
     Il pattern Command (noto anche come Action o Transaction) permette di inoltrare richieste ad oggetti 
     senza conoscere assolutamente nulla dell’operazione da eseguire o del destinatario della richiesta. 
     Questo è possibile per il fatto che il pattern in questione tratta la richiesta come un oggetto differente 
     rispetto sia al richiedente che all’oggetto destinatario. 
     
     Questo oggetto specifica l’azione da svolgere sul destinatario, sfruttandone i comportamenti in modo tale da 
     poter portare a termine la richiesta.

     Il pattern Command permette quindi di incapsulare una richiesta in un oggetto permettendo al client 
     di inoltrare richieste di varia natura, anche in funzione di destinatari diversi. 
     
     Il pattern in questione può essere applicato:
        
        - per parametrizzare gli oggetti rispetto ad una azione da compiere
        - per specificare, accodare ed eseguire svariate richieste in tempi diversi, anche trasferendo 
          un comando da un contesto di esecuzione ad un altro;

        - per consentire l’annullamento delle operazioni eseguite (undo, rollback), mantenendo preventivamente lo stato 
          per annullare gli effetti dei comandi stessi.
     */

    class Program
    {
        static void Main(string[] args)
        {
            ICommand[] commands =
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

    public interface ICommand
    {
        bool Execute(PersonInfo personInfo);
    }

    public class RegisterPersonCommand : ICommand
    {
        public virtual bool Execute(PersonInfo personInfo)
        {
            Console.WriteLine($"Person {personInfo.ToString()} Registered succesfully");
            return true;
        }
    }

    public class UnregisterPersonCommand : ICommand
    {
        public virtual bool Execute(PersonInfo personInfo)
        {
            Console.WriteLine($"Person {personInfo.ToString()} Unregistered succesfully");
            return true;
        }
    }
}
