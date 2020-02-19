using System;
using System.Collections.Generic;
using System.Text;
using ExpensiveParser.OLX;

namespace ExpensiveParser.Parser
{
    public interface IParser<T> where  T : class
    {
        T Parse(OlxDocumentModel olxDocumentModel);
    }
}
