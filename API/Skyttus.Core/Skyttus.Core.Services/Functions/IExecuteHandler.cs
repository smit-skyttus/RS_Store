using Skyttus.Core.Services.Result;

namespace Skyttus.Core.Services.Functions
{
    public interface IExecuteHandler<TInput, THandler> where THandler : IExecuteHandler<TInput, THandler>
    {
        Task<BaseResult> ExecuteAsync(TInput data, string token);
    }
}
