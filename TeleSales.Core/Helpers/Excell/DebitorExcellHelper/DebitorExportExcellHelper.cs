using OfficeOpenXml;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Helpers.Excell.DebitorExcellHelper;

public class DebitorExportExcellHelper
{
    public async Task<byte[]> ExcellExportAsync(List<Debitors> callCenters)
    {
        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Calls");

                var headers = new[]
                {
                    "Kanal", "Status", "VÖEN", "Fakturanın nömrəsi","Rayon", "Başlama Tarixi", 
                    "Bitmə Tarixi", "Kücə", "Mövzu", "Əlaqə Nömrəsi", "Reklam yayıcının adı", 
                    "Idarəçi","Neticə", "Qeyd",  "Debitor üzrə cəm borclar", "2018", "2019", "2020", 
                    "2021","2022", "2023", "2024-1","2024-2","2024-3","2024-4","2024-5","2024-6","2024-7",
                    "2024-8","2024-9","2024-10","2024-11","2024-12","2025-1","2025-2","2025-3"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }

                for (int row = 0; row < callCenters.Count; row++)
                {
                    var call = callCenters[row];

                    worksheet.Cells[row + 2, 1].Value = call.ChannelId;
                    worksheet.Cells[row + 2, 2].Value = call.Status.Name;
                    worksheet.Cells[row + 2, 3].Value = call.VOEN;
                    worksheet.Cells[row + 2, 4].Value = call.InvoiceNumber;
                    worksheet.Cells[row + 2, 5].Value = call.District;
                    worksheet.Cells[row + 2, 6].Value = call.PermissionStartDate?.ToString();
                    worksheet.Cells[row + 2, 7].Value = call.PermissionEndDate?.ToString();
                    worksheet.Cells[row + 2, 8].Value = call.Street;
                    worksheet.Cells[row + 2, 9].Value = call.Subject;
                    worksheet.Cells[row + 2, 11].Value = call.LegalName;
                    worksheet.Cells[row + 2, 10].Value = call.Phone;
                    worksheet.Cells[row + 2, 12].Value = call.User.FullName;
                    worksheet.Cells[row + 2, 13].Value = call.Result?.Name.ToString();
                    worksheet.Cells[row + 2, 14].Value = call.Note;

                    worksheet.Cells[row + 2, 15].Value = call.TotalDebt;
                    worksheet.Cells[row + 2, 16].Value = call.Year2018;
                    worksheet.Cells[row + 2, 17].Value = call.Year2019;
                    worksheet.Cells[row + 2, 18].Value = call.Year2020;
                    worksheet.Cells[row + 2, 19].Value = call.Year2021;
                    worksheet.Cells[row + 2, 20].Value = call.Year2022;
                    worksheet.Cells[row + 2, 21].Value = call.Year2023;
                    worksheet.Cells[row + 2, 22].Value = call.Month1_2024;
                    worksheet.Cells[row + 2, 23].Value = call.Month2_2024;
                    worksheet.Cells[row + 2, 24].Value = call.Month3_2024;
                    worksheet.Cells[row + 2, 25].Value = call.Month4_2024;
                    worksheet.Cells[row + 2, 26].Value = call.Month5_2024;
                    worksheet.Cells[row + 2, 27].Value = call.Month6_2024;
                    worksheet.Cells[row + 2, 28].Value = call.Month7_2024;
                    worksheet.Cells[row + 2, 29].Value = call.Month8_2024;
                    worksheet.Cells[row + 2, 30].Value = call.Month9_2024;
                    worksheet.Cells[row + 2, 31].Value = call.Month10_2024;
                    worksheet.Cells[row + 2, 32].Value = call.Month11_2024;
                    worksheet.Cells[row + 2, 33].Value = call.Month12_2024;
                    worksheet.Cells[row + 2, 34].Value = call.Month1_2025;
                    worksheet.Cells[row + 2, 35].Value = call.Month2_2025;
                    worksheet.Cells[row + 2, 36].Value = call.Month3_2025;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                return package.GetAsByteArray();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred during Excel export.", ex);
        }
    }
}
