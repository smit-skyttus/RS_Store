namespace InfiGrowth.Models
{
    public class RowModel
    {
        public RowModel()
        {
            Cells = new List<ExcelCell>();
        }
        public int RowNumber { get; set; }

        public bool IsSplitter { get; set; }

        public List<ExcelCell> Cells { get; set; }
    }

    public class ExcelCell
    {
        public int ColumnNumber { get; set; }

        public dynamic? Value { get; set; }
    }
}
