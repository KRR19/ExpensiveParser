using ExpensiveParser.Besplatka;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml;

namespace ExpensiveParser.Save
{
    class SaveExcel : ISave
    {
        public void Save(List<BesplatkaDocumentModel> models)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("besplatka");
                worksheet.Cells[1,1].Style.Font.Bold = true;
                worksheet.Cells[1, 2].Style.Font.Bold = true;
                worksheet.Cells[1, 3].Style.Font.Bold = true;
                worksheet.Cells[1, 4].Style.Font.Bold = true;
                worksheet.Cells[1, 1].Value = "Headline";
                worksheet.Cells[1, 2].Value = "Seller";
                worksheet.Cells[1, 3].Value = "Price";
                worksheet.Cells[1, 4].Value = "Link";
                for (int adsIndex = 0; adsIndex < models.Count; adsIndex++)
                {
                    worksheet.Cells[adsIndex + 2, 1].Value = models[adsIndex].Headline;
                    worksheet.Cells[adsIndex + 2, 2].Value = models[adsIndex].SellerName;
                    worksheet.Cells[adsIndex + 2, 3].Value = models[adsIndex].Price;
                    worksheet.Cells[adsIndex + 2, 4].Value = models[adsIndex].Link;
                }
                FileInfo fileInfo = new FileInfo(@"besplatka.xlsx");
                excelPackage.SaveAs(fileInfo);
            }
        }
    }
}
