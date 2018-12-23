using System;
using System.Linq;

namespace ObserverPattern
{
    /* Observer

       Il pattern Observer (noto anche col nome Publish-Subscribe) permette di definire una dipendenza uno a molti fra oggetti,
       in modo tale che se un oggetto cambia il suo stato interno, ciascuno degli oggetti dipendenti da esso viene notificato 
       e aggiornato automaticamente. 
       L’Observer nasce dall’esigenza di mantenere un alto livello di consistenza fra classi correlate, 
       senza peraltro produrre situazioni di forte dipendenza e accoppiamento elevato.

       Il pattern Observer si presta ad essere utilizzato in diversi casi. Ad esempio, quando un’astrazione presenta due 
       diversi aspetti tra loro dipendenti, è possibile definire due classi in cui incapsulare questi aspetti in modo tale 
       da poterli utilizzare in maniera indipendente. In questo scenario occorre comunque prevedere un meccanismo 
       di comunicazione che permetta di mantenere la consistenza tra le istanze delle due classi 
       e il pattern Observer fornisce una soluzione elegante al problema senza generare accoppiamento. 
       Un’altra situazione tipica di utilizzo si ha quando la modifica dello stato di un oggetto 
       (per esempio, un controllo dell’interfaccia utente) implica un cambiamento dello stato di altri oggetti correlati, 
       a prescindere dal loro numero (per esempio, altri controlli). In questo caso la modifica dello stato dell’oggetto 
       (detto anche Publisher) si deve propagare agli oggetti correlati (detti anche Subscriber) 
       in modo tale che essi possano aggiornare il loro stato interno di conseguenza.
    
       I partecipanti di questo pattern sono:

       Subject (delegate Subject.Notify)
       Conosce i suoi Observer. Fornisce l’interfaccia per associare e rimuovere oggetti Observer.

       Observer 
       fornisce l’interfaccia di notifica per gli oggetti a cui devono essere segnalati i cambiamenti di stato di Subject.

       ConcreteSubject (Subject)
       Contiene lo stato monitorato dagli Observer a cui viene inviata la notifica.

       ConcreteObserver (Observer)
       Mantiene un riferimento ad un oggetto ConcreteSubject. Contiene le informazioni da mantenere sincronizzate 
       con lo stato del Subject. Implementa il metodo di gestione della notifica da eseguire allo scopo di mantenere 
       sincronizzati gli stati degli oggetti.

       Il meccanismo per inviare notifiche nell’ambito del .NET Framework è fornito in modo nativo dai tipi delegate 
       e dagli eventi. Una classe che funge da Publisher (classe Subject) espone in generale sulla sua interfaccia 
       una serie di eventi corrispondenti ad un tipo particolare di delegate. 
       Le classi Subscriber (classe Observer) sottoscrivono l’evento e ad esso associano un metodo interno 
       (comunemente detto event handler) che deve rispettare la firma definita dal tipo delegate associato all’evento. 
       L’event handler viene chiamato nel momento in cui il Publisher inoltra ai suoi Subscriber la notifica, 
       rendendo possibile in questo modo l’esecuzione di codice in ciascun Subscriber al variare dello stato interno 
       del Publisher.       
    */

    class Program
    {
        static void Main(string[] args)
        {        
            Subject s = new Subject();

            Observer o1 = new Observer(s);
            Observer o2 = new Observer(s);

            s.DoSomething();
            Console.ReadLine();            
        }
    }

    public class Subject
    {
        public delegate void Notify(string message);
        public event Notify OnNotify;

        public void DoSomething()
        {
            if (OnNotify != null)
            {
                Console.WriteLine("Subject fires event");
                OnNotify("Hello");
            }
        }
    }

    public class Observer
    {
        private int IdObserver { get; set; }
        
        public Observer(Subject s)
        {            
            s.OnNotify += new Subject.Notify(EventHandler);
            IdObserver = new Random().Next();
        }
      
        public void EventHandler(string message)
        {
            Console.WriteLine($"Observer {this.IdObserver} was called by subject, message is {message}", this);
        }
    }    
}
