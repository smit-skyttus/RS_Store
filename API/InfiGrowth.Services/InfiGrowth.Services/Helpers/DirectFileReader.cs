using InfiGrowth.Models;
using Microsoft.AspNetCore.Http;

namespace InfiGrowth.Services.Helpers
{
    public abstract class DirectFileReader
    {
        public abstract Task<List<T>> Read<T>(IFormFile fromFile)
            where T : RowModel, new();
    }
}
