namespace InfiGrowth.Models.Models
{
    public class SearchResult<T>
    {
        public int? PageSize { get; set; }
        public int? PageNumber { get; set; }
        public int TotalRecords { get; set; }
        public IEnumerable<T>? Results { get; set; }
    }
}
