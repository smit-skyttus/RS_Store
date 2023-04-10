namespace Skyttus.Core.Services.Response
{
    public class ErrorResponse
    {
        public string Type { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; } = string.Empty;
    }
}
