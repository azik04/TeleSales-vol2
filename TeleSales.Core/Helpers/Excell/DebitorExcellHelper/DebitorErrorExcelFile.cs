using OfficeOpenXml;

namespace TeleSales.Core.Helpers.Excell.DebitorExcellHelper;

public class DebitorErrorExcelFile
{
    public byte[] GenerateErrorExcelFile(List<List<object>> errorRows)
    {
        var headers = new[]
        {
            "İnzibatiyə gedənlər", "Operator-Şəbəkə", "VÖEN", "Fakturanın nömrəsi", "Rayon", "Başlama Tarixi",
            "Bitmə Tarixi", "Kücə", "Mövzu", "Əlaqə Nömrəsi", "Reklam yayıcının adı",
            "Debitor üzrə cəm borclar", "2018", "2019", "2020","2021", "2022",
            "2023", "2024-1", "2024-2", "2024-3", "2024-4", "2024-5", "2024-6", "2024-7",
            "2024-8", "2024-9", "2024-10", "2024-11", "2024-12", "2025-1", "2025-2", "2025-3"
        };

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Error Report");

            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = headers[i];
            }

            if (errorRows.Count == 0) return package.GetAsByteArray();

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
