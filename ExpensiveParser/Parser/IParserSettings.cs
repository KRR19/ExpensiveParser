using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensiveParser.Parser
{
    public interface IParserSettings
    {
        string BaseUrl { get; set; }
    }
}
