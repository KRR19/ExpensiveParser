using ExpensiveParser.Besplatka;
using System;
using System.Collections.Generic;
using System.IO;

namespace ExpensiveParser.Save
{
    class SaveExel : ISave
    {
        public void Save(List<BesplatkaDocumentModel> models)
        {
            using (FileStream fileStream = new FileStream("besplatca.txt", FileMode.OpenOrCreate))
            {
                foreach (BesplatkaDocumentModel model in models)
                {
                    byte[] line = System.Text.Encoding.Default.GetBytes($"{model.Headline}\t{model.SellerName}\t{model.Price}\t{model.Link}\n");
                    fileStream.Write(line, 0, line.Length);
                }
            }
        }
    }
}
