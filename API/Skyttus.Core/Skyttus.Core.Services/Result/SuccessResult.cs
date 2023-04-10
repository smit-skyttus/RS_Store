namespace Skyttus.Core.Services.Result
{
    public class SuccessResult<T> : BaseResult<T>
    {
        public SuccessResult()
        {

        }
        public SuccessResult(T value)
        {
            Value = value;
        }
        public override int StatusCode { get; set; } = 200;
    }
}
