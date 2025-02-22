using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.Globalization;
using TeleSales.Core.Helpers.Excell.DebitorExcellHelper;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Context;
using TeleSales.DataProvider.Entities.Main;
using TeleSales.DataProvider.Entities.Rel;

namespace TeleSales.Core.Helpers.Excell.EmployerExcellHelper;

public class EmpoyerImportExcellHelper
{
    private readonly ApplicationDbContext _db;
    private readonly DebitorErrorExcelFile _error;
    public EmpoyerImportExcellHelper(DebitorErrorExcelFile error, ApplicationDbContext db)
    {
        _db = db;
        _error = error;
    }

    public async Task<FileResponse<List<Employers>>> ImportFromExcelAsync(Stream excelFileStream)
    {
        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var callsList = new List<Employers>();
            var errorRows = new List<List<object>>();

            using (var package = new ExcelPackage(excelFileStream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int startRow = 2;
                int endRow = worksheet.Dimension.End.Row;
                int totalColumns = worksheet.Dimension.End.Column;

                for (int row = startRow; row <= endRow; row++)
                {
                    var errors = new List<string>();
                    var rowData = new List<object>();

                    try
                    {
                        var administration = worksheet.Cells[row, 3].Text;
                        
                        var administrationId = await _db.Administrations.SingleOrDefaultAsync(x => x.Name == administration);

                        if (administrationId == null)
                            administrationId = null;

                        var department = worksheet.Cells[row, 4].Text;
                        
                        var departmentId = await _db.Departments.SingleOrDefaultAsync(x => x.AdministrationId == administrationId.id && x.Name == department);
                        
                        if (departmentId == null)
                            departmentId = null;
                        
                        var call = new Employers
                        {
                            FullName = worksheet.Cells[row, 1].Text,
                            Email = worksheet.Cells[row, 2].Text,
                            DepartmentId = departmentId.id,
                            Position = worksheet.Cells[row, 5].Text,
                           
                        };

                        callsList.Add(call);
                    }
                    catch (Exception ex)
                    {
                        errors.Add($"Unexpected error: {ex.Message}");
                    }

                    if (errors.Any())
                    {
                        for (int col = 1; col <= totalColumns; col++)
                        {
                            rowData.Add(worksheet.Cells[row, col].Text);
                        }
                        rowData.Add(string.Join("; ", errors));
                        errorRows.Add(rowData);
                    }
                }
            }

            if (errorRows.Any())
            {
                byte[] errorFileBytes = _error.GenerateErrorExcelFile(errorRows);
                return new FileResponse<List<Employers>>(null, false, "Some rows contain errors. See attached error file.", errorFileBytes);
            }

            return new FileResponse<List<Employers>>(callsList, true, "Import successful.");
        }
        catch (Exception ex)
        {
            return new FileResponse<List<Employers>>(null, false, $"An error occurred during import: {ex.Message}");
        }
    }
    /// <summary>
    /// Parses a date string into DateOnly, handling errors.
    /// </summary>
    private DateOnly? ParseDateOnly(string dateText, int row, List<string> errors)
    {
        if (DateTime.TryParseExact(dateText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
        {
            return DateOnly.FromDateTime(parsedDate);
        }
        else
        {
            errors.Add($"Invalid date format: {dateText}");
            return null;
        }
    }

    /// <summary>
    /// Tries to parse a long value, handling errors.
    /// </summary>
    private long? TryParseLong(string text, int row, List<string> errors)
    {
        if (string.IsNullOrEmpty(text) || !long.TryParse(text, out var value))
        {
            errors.Add($"Invalid number format: {text}");
            return null;
        }
        return value;
    }

    /// <summary>
    /// Tries to parse a decimal value, handling errors.
    /// </summary>
    private decimal? TryParseDecimal(string text, int row, List<string> errors)
    {
        if (string.IsNullOrEmpty(text) || !decimal.TryParse(text, out var value))
        {
            errors.Add($"Invalid number format: {text}");
            return null;
        }
        return value;
    }
}
