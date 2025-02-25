using OfficeOpenXml;
using TeleSales.DataProvider.Entities.Main;

namespace TeleSales.Core.Helpers.Excell.UzadilmaExcellHelper;

public class ExportUzadilmaExcellHelper
{
    public async Task<byte[]> ExcellExportAsync(List<Uzadilmas> callCenters)
    {
        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Calls");

                var headers = new[]
                {
                    "ID", "Kanal ID", "Şöbə ID", "Şöbə Adı", "Rayon ID", "Rayon Adı", "Ünvan",
                    "Müraciət Nömrəsi", "Başlama Tarixi", "Bitmə Tarixi", "Yayici", "VÖEN", "Zona",
                    "Daşıyıcı Növü", "İcazə Müddəti", "Təyinat VÖEN", "Müraciət Sayı", "Daşıyıcı Sayı"
                };

                for (int i = 0; i < headers.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = headers[i];
                }

                for (int row = 0; row < callCenters.Count; row++)
                {
                    var call = callCenters[row];
                    worksheet.Cells[row + 2, 1].Value = call.id;
                    worksheet.Cells[row + 2, 2].Value = call.ChannelId;
                    worksheet.Cells[row + 2, 3].Value = call.DepartmentId;
                    //worksheet.Cells[row + 2, 4].Value = call.DepartmentName;
                    worksheet.Cells[row + 2, 5].Value = call.RegionId;
                    //worksheet.Cells[row + 2, 6].Value = call.RegionName;
                    worksheet.Cells[row + 2, 7].Value = call.Adress;
                    worksheet.Cells[row + 2, 8].Value = call.MuraciyetNomresi;
                    worksheet.Cells[row + 2, 9].Value = call.PermissionStartDate?.ToString("yyyy-MM-dd");
                    worksheet.Cells[row + 2, 10].Value = call.PermissionEndDate?.ToString("yyyy-MM-dd");
                    worksheet.Cells[row + 2, 11].Value = call.Yayici;
                    worksheet.Cells[row + 2, 12].Value = call.VOEN;
                    worksheet.Cells[row + 2, 13].Value = call.Zona;
                    worksheet.Cells[row + 2, 14].Value = call.DasiyiciNovu;
                    worksheet.Cells[row + 2, 15].Value = call.IcazeMuddeti;
                    worksheet.Cells[row + 2, 16].Value = call.TəyinatVöen;
                    worksheet.Cells[row + 2, 17].Value = call.MüraciətSayı;
                    worksheet.Cells[row + 2, 18].Value = call.DaşıyıcıSayı;
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
