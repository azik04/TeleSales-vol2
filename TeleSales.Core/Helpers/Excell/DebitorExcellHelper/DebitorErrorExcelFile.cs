using OfficeOpenXml;

namespace TeleSales.Core.Helpers.Excell.DebitorExcellHelper;

public class DebitorErrorExcelFile
{
    public byte[] GenerateErrorExcelFile(List<List<object>> errorRows)
    {
        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Error Report");

            worksheet.Cells[1, 1].Value = "Row Data (Original)";
            worksheet.Cells[1, errorRows[0].Count].Value = "Error Message";

            for (int i = 0; i < errorRows.Count; i++)
            {
                for (int j = 0; j < errorRows[i].Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = errorRows[i][j];
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            return package.GetAsByteArray();
        }
    }
}
