using ExpensiveParser.Besplatka;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExpensiveParser.Save
{
    public interface ISave
    {
        public void Save(List<BesplatkaDocumentModel> models);
    }
}
