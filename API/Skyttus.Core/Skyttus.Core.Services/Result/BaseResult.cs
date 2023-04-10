namespace Skyttus.Core.Services.Result
{
    public abstract class BaseResult
    {
        public abstract int StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
    }

    public abstract class BaseResult<T> : BaseResult
    {
        public T? Value { get; protected set; }
    }
}
