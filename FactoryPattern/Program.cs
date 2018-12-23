using System;

namespace FactoryPattern
{
    /*  Factory Method Pattern

        Nella programmazione ad oggetti, il Factory Method è uno dei design pattern fondamentali per l'implementazione 
        del concetto di factory. Come altri pattern creazionali, esso indirizza il problema della creazione 
        di oggetti senza specificarne l'esatta classe. 
        
        Questo pattern raggiunge il suo scopo fornendo un'interfaccia per creare un oggetto, 
        ma lascia che le sottoclassi decidano quale oggetto istanziare.

        La creazione di un oggetto può, spesso, richiedere processi complessi la cui collocazione all'interno 
        della classe di composizione potrebbe non essere appropriata. 
        Esso può, inoltre, comportare la duplicazione di codice, richiedere informazioni non accessibili alla classe 
        di composizione, o non provvedere un sufficiente livello di astrazione. 
        Il factory method indirizza questi problemi definendo un metodo separato per la creazione degli oggetti; 
        tale metodo può essere ridefinito dalle sottoclassi per definire il tipo derivato di prodotto 
        che verrà effettivamente creato.
    */

    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
                new Shape[]
                {
                    ShapeCreator.CreateShape(ShapeType.Circle),
                    ShapeCreator.CreateShape(ShapeType.Rectangle)
                };

            foreach (Shape s in shapes)
                s.Draw();

            Console.ReadLine();
        }
    }

    public enum ShapeType
    {
        Rectangle = 1,
        Circle = 2
    }

    // Posso usare una interfaccia oppure una classe astratta
    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }

    public class ShapeCreator
    {
        public static Shape CreateShape(ShapeType type)
        {
            switch (type)
            {
                case ShapeType.Rectangle:
                    return new Rectangle();
                case ShapeType.Circle:
                    return new Circle();
                default:
                    throw new ArgumentException("type");
            }
        }
    }
}
