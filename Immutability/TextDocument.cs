using System;
using System.Collections.Generic;
using System.Text;

namespace Immutability
{
    /* Make your data objects immutable
        This means that once a data object is created, its contents will never change.
        In C#, we can do this by making all properties read-only and providing a constructor to allow 
        the initialization of these properties.
    
        Modifying immutable data objects
        Immutable data objects cannot be modified. If we need to have a modified version of a data object, 
        we have to create another one that has the same data, except for the part that we want to change. 
        For example, if we want to append “Thank you” to the content of a document, 
        we would create a new document.        
     */

    public class TextDocument
    {
        public TextDocument(string identifier, string content)
        {
            Identifier = identifier;
            Content = content;
        }

        public string Identifier { get; }
        public string Content { get; }

        public TextDocument WithIdentifier(string newValue)
        {
            return new TextDocument(identifier: newValue, content: Content);
        }

        public TextDocument WithContent(string newValue)
        {
            return new TextDocument(identifier: Identifier, content: newValue);
        }
    }
}
