using System;

namespace FactoryPattern
{
    /*  Factory Method Pattern

        Nella programmazione ad oggetti, il Factory Method è uno dei design pattern fondamentali per l'implementazione 
        del concetto di factory. Come altri pattern creazionali, esso indirizza il problema della creazione 
        di oggetti senza specificarne l'esatta classe. 
        
        Questo pattern raggiunge il suo scopo fornendo un'interfaccia per creare un oggetto, 
        ma lascia che le sottoclassi decidano quale oggetto istanziare.
        
        L'utilizzo di questo pattern implica la creazione di una classe factory che gestirà la creazione di oggetti classi che
        imlementano la stessa astrazione (interfaccia). Ciò significa che, se c'è un'interfaccia definita per diverse sottoclassi,
        la classe Factory può creare qualsiasi di queste sottoclassi a seconda della logica passata alla factory.

        Facciamo un esempio: creiamo una factory chiamata BurgerFactory che prenderà in input il parametro typeOfBurger 
        (per esempio Pollo o Manzo). Il Burgerfactory deciderà quale tipo di oggetto Burger dovrà creare. 
        Supponiamo di avere un'interfaccia chiamata IBurger che sia il ChickenBurger sia il BeefBurger implementano, allora la classe
        BurgerFactory restituirà un oggetto di tipo IBurger. 
        Il client non è a conoscenza di quale oggetto IBurger verrà creato e restituito; in questo modo riusciamo ad isolare 
        il client dallo specifico oggetto ritornato aumentando la flessibilità e il riutilizzo del codice.            
    */

    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
                new Shape[]
                {
                    ShapeCreator.CreateShape(ShapeType.Circle),
                    ShapeCreator.CreateShape(ShapeType.Rectangle),
                    ShapeCreator.CreateShape(ShapeType.Square)
                };

            foreach (Shape s in shapes)
                s.Draw();

            Console.ReadLine();
        }
    }

    public enum ShapeType
    {
        Rectangle = 1,
        Circle = 2,
        Square = 3
    }

    // Posso usare un'interfaccia oppure una classe astratta
    public abstract class Shape
    {
        public abstract void Draw();
    }

    public class Square : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Square");
        }
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
                case ShapeType.Square:
                    return new Square();
                default:
                    throw new ArgumentException("type");
            }
        }
    }
}
