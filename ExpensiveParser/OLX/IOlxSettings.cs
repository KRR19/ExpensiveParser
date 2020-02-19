using System;
using System.Collections.Generic;
using System.Text;
using ExpensiveParser.Parser;

namespace ExpensiveParser.OLX
{
    public interface IOlxSettings : IParserSettings
    {
        string Category { get; set; }
        string Sections { get; set; }
        string Filter { get; set; }
        int LoadCount { get; set; }
    }
}
