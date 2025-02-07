using OfficeOpenXml;
using TeleSales.Core.Response;
using TeleSales.DataProvider.Entities.Main;
using System.Globalization;

namespace TeleSales.Core.Helpers.Excell.DebitorExcellHelper;

public class DebitorImportExcellHelper
{
    private readonly DebitorErrorExcelFile _error;
    public DebitorImportExcellHelper(DebitorErrorExcelFile error)
    {
        _error = error;
    }

    public async Task<BaseResponse<List<Debitors>>> ImportFromExcelAsync(Stream excelFileStream, long kanalId)
    {
        try
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var callsList = new List<Debitors>();
            var errorRows = new List<List<object>>();

            using (var package = new ExcelPackage(excelFileStream))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int startRow = 4;
                int endRow = worksheet.Dimension.End.Row;
                int totalColumns = worksheet.Dimension.End.Column;

                for (int row = startRow; row <= endRow; row++)
                {
                    var errors = new List<string>();
                    var rowData = new List<object>();

                    try
                    {
                        var call = new Debitors
                        {
                            VOEN = worksheet.Cells[row, 3].Text,
                            InvoiceNumber = (long)TryParseLong(worksheet.Cells[row, 4].Text, row, errors),
                            District = worksheet.Cells[row, 5].Text,
                            PermissionStartDate = ParseDateOnly(worksheet.Cells[row, 6].Text, row, errors),
                            PermissionEndDate = ParseDateOnly(worksheet.Cells[row, 7].Text, row, errors),
                            Street = worksheet.Cells[row, 8].Text,
                            Subject = worksheet.Cells[row, 9].Text,
                            Phone = worksheet.Cells[row, 10].Text,
                            LegalName = worksheet.Cells[row, 11].Text,
                            TotalDebt = TryParseDecimal(worksheet.Cells[row, 12].Text, row, errors),
                            Year2018 = TryParseDecimal(worksheet.Cells[row, 13].Text, row, errors),
                            Year2019 = TryParseDecimal(worksheet.Cells[row, 14].Text, row, errors),
                            Year2020 = TryParseDecimal(worksheet.Cells[row, 15].Text, row, errors),
                            Year2021 = TryParseDecimal(worksheet.Cells[row, 16].Text, row, errors),
                            Year2022 = TryParseDecimal(worksheet.Cells[row, 17].Text, row, errors),
                            Year2023 = TryParseDecimal(worksheet.Cells[row, 18].Text, row, errors),
                            Month1_2024 = TryParseDecimal(worksheet.Cells[row, 19].Text, row, errors),
                            Month2_2024 = TryParseDecimal(worksheet.Cells[row, 20].Text, row, errors),
                            Month3_2024 = TryParseDecimal(worksheet.Cells[row, 21].Text, row, errors),
                            Month4_2024 = TryParseDecimal(worksheet.Cells[row, 22].Text, row, errors),
                            Month5_2024 = TryParseDecimal(worksheet.Cells[row, 23].Text, row, errors),
                            Month6_2024 = TryParseDecimal(worksheet.Cells[row, 24].Text, row, errors),
                            Month7_2024 = TryParseDecimal(worksheet.Cells[row, 25].Text, row, errors),
                            Month8_2024 = TryParseDecimal(worksheet.Cells[row, 26].Text, row, errors),
                            Month9_2024 = TryParseDecimal(worksheet.Cells[row, 27].Text, row, errors),
                            Month10_2024 = TryParseDecimal(worksheet.Cells[row, 28].Text, row, errors),
                            Month11_2024 = TryParseDecimal(worksheet.Cells[row, 29].Text, row, errors),
                            Month12_2024 = TryParseDecimal(worksheet.Cells[row, 30].Text, row, errors),
                            Month1_2025 = TryParseDecimal(worksheet.Cells[row, 31].Text, row, errors),
                            Month2_2025 = TryParseDecimal(worksheet.Cells[row, 32].Text, row, errors),
                            Month3_2025 = TryParseDecimal(worksheet.Cells[row, 33].Text, row, errors),
                            ChannelId = kanalId,
                            StatusId = 1,
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
                return new BaseResponse<List<Debitors>>(null, false, "Some rows contain errors. See attached error file.");
            }

            return new BaseResponse<List<Debitors>>(callsList, true, "Import successful.");
        }
        catch (Exception ex)
        {
            return new BaseResponse<List<Debitors>>(null, false, $"An error occurred during import: {ex.Message}");
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
