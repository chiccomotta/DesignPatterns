using System;

namespace Immutability
{
    // https://www.dotnetcurry.com/patterns-practices/1429/data-objects-csharp-fsharp

    class Program
    {
        static void Main(string[] args)
        {
            // Original Object
            var existingDocument = new TextDocument("text_1", "Hello Wordl!");
            var sameDocument = existingDocument;

            // Same sreference
            Console.WriteLine(object.ReferenceEquals(existingDocument, sameDocument));

            // Modifico l'oggetto creandone uno nuovo con l'extension method With
            var newDocument =
                existingDocument     
                    .WithIdentifier("text_2")
                    .WithContent(existingDocument.Content + Environment.NewLine + "Thank you");

            Console.WriteLine(object.ReferenceEquals(existingDocument, newDocument));

            Console.WriteLine($"{newDocument.Identifier} , {newDocument.Content}");
            Console.ReadKey();
        }
    }
}
