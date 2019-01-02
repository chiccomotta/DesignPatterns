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

            // Same reference
            Console.WriteLine(object.ReferenceEquals(existingDocument, sameDocument));

            // Modifico l'oggetto creandone uno nuovo con l'extension method With che
            // restituisce un nuovo oggetto basato sulle stesse proprietà più quella modificata
            var newDocument =
                existingDocument     
                    .WithIdentifier("text_2")
                    .WithContent(existingDocument.Content + " Thank you");
            
            // Not the same reference
            Console.WriteLine(object.ReferenceEquals(existingDocument, newDocument));

            Console.WriteLine($"{newDocument.Identifier} , {newDocument.Content}");
            Console.ReadKey();
        }
    }
}
