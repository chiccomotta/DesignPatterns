using System;
using System.Collections.Generic;
using System.Text;

namespace Immutability
{
    public class TextDocument
    {
        public string Identifier { get; }
        public string Content { get; }

        public TextDocument(string identifier, string content)
        {
            Identifier = identifier;
            Content = content;
        }

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
