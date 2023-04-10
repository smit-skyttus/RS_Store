using Skyttus.Core.Services.Response;

namespace Skyttus.Core.Services.Result
{
    public class ErrorResult<T> : BaseResult<T>
    {
        public ErrorResult()
        {

        }
        public ErrorResult(ErrorResponse error)
        {
            Errors.Add(error);
        }
        public ErrorResult(int statusCode, ErrorResponse error)
        {
            StatusCode = statusCode;
            Errors.Add(error);
        }

        public ErrorResult(List<ErrorResponse> errors)
        {
            Errors.AddRange(errors);
        }

        public override int StatusCode { get; set; } = 500;

        public virtual List<ErrorResponse> Errors { get; } = new List<ErrorResponse>();
    }
}
