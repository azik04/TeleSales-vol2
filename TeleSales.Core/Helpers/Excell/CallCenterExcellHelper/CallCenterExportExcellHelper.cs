using OfficeOpenXml;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Helpers.Excell.CallCenterExcellHelper;

public class CallCenterExportExcellHelper
{
    public async Task<byte[]> ExcellExportAsync(List<CallCenters> callCenters)
    {
        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Calls");

                var headers = new[]
                {
                    "Kanal", "Zəngin vaxtı", "VÖEN", "Region", "Ad, Soyad", "Əlaqə", "Operator",
                    "Müraciətin növü", "Qısa məzmun", "Müraciətin təfərrüatları",
                    "Yönləndirmə(Olub/Olmuyub)", "Yönləndirmə(İdarə)", "Şöbənin adı",
                    "Yönləndirmə(kimə)", "Zəngin nəticəsi", "Əlavə qeyd"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }

                for (int row = 0; row < callCenters.Count; row++)
                {
                    var call = callCenters[row];

                    worksheet.Cells[row + 2, 1].Value = call.Channel?.Name;
                    worksheet.Cells[row + 2, 2].Value = call.CreateAt.ToString("g"); 
                    worksheet.Cells[row + 2, 3].Value = call.VOEN;
                    worksheet.Cells[row + 2, 4].Value = call.Region?.Name;
                    worksheet.Cells[row + 2, 5].Value = call.FullName;
                    worksheet.Cells[row + 2, 6].Value = call.Phone;
                    worksheet.Cells[row + 2, 7].Value = call?.FullName;
                    worksheet.Cells[row + 2, 8].Value = call.ApplicationType?.Name;
                    worksheet.Cells[row + 2, 9].Value = call.ShortContent;
                    worksheet.Cells[row + 2, 10].Value = call.DetailsContent;
                    worksheet.Cells[row + 2, 11].Value = call.EmployerId;
                    worksheet.Cells[row + 2, 12].Value = call.AdministrationId; 
                    worksheet.Cells[row + 2, 13].Value = call.Department?.Name;
                    worksheet.Cells[row + 2, 14].Value = call.Conclusion;
                    worksheet.Cells[row + 2, 15].Value = call.Addition;
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
