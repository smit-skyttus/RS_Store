using InfiGrowth.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace InfiGrowth.Services.Helpers
{
    public class ExcelEPRowReader : DirectFileReader
    {
        public override async Task<List<T>> Read<T>(IFormFile file)
        {
            try
            {
                using MemoryStream memoryStream = new();
                await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                //Lets open the existing excel file and read through its content . Open the excel using openxml sdk
                using ExcelPackage package = new(memoryStream);
                var worksheet = package.Workbook.Worksheets[0];

                var rowCount = worksheet.Dimension?.Rows;
                var colCount = worksheet.Dimension?.Columns;
                List<T> excelRows = new();
                if (!rowCount.HasValue || !colCount.HasValue)
                {
                    return excelRows;
                }
                for (int row = 1; row <= rowCount.Value; row++)
                {
                    T excelRow = new();
                    excelRow.RowNumber = row;

                    for (int col = 1; col <= colCount.Value; col++)
                    {
                        ExcelCell cell = new();
                        cell.ColumnNumber = col;
                        cell.Value = worksheet.Cells[row, col].Value;
                        excelRow.Cells.Add(cell);
                    }
                    excelRows.Add(excelRow);
                }
                return excelRows;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
