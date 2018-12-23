using System;

namespace SingletonPattern
{
    /*
     Singleton
     
     Lo scopo del pattern Singleton è quello di assicurare che per una determinata classe esista un’unica istanza attiva, 
     fornendo un entry-point globale all’istanza stessa. 
     Questo pattern si può rivelare utile nel caso in cui si abbia la necessità di centralizzare informazioni e comportamenti 
     in un’unica entità condivisa da tutti i suoi utilizzatori. 

     La soluzione che più si adatta a risolvere la questione associata al pattern (unicità dell’istanza) 
     consiste nell’associare alla classe stessa la responsabilità di creare le proprie istanze. 
     
     In questo modo è la classe stessa che può assicurare che nessun’altra istanza possa essere creata, 
     intercettando e gestendo in modo centralizzato le richieste di creazione di nuove istanze.

     */

    class Program
    {
        static void Main(string[] args)
        {
            SingletonOne.Instance.DoSomething();
            SingletonThreadSafe.Instance.DoSomething();
            //Three.Instance.DoSomething();
            Console.ReadLine();
        }

        public sealed class SingletonOne
        {
            private static readonly SingletonOne instance = new SingletonOne();
            private SingletonOne() { }

            public static SingletonOne Instance
            {
                get { return instance; }
            }

            public void DoSomething()
            {
                Console.WriteLine("SingletonOne class");
            }
        }

        public sealed class SingletonThreadSafe
        {
            private static SingletonThreadSafe instance;
            private static object syncLock = new object();
            private SingletonThreadSafe() { }

            public static SingletonThreadSafe Instance
            {
                get
                {
                    if (instance == null)
                        lock (syncLock)
                        {
                            if (instance == null)
                                instance = new SingletonThreadSafe();
                        } // lock

                    return instance;
                }
            }

            public void DoSomething()
            {
                Console.WriteLine("SingletonThreadSafe");
            }
        }
    }
}
