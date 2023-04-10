namespace Skyttus.Core.Services.Extensions
{
    public static class BaseResultExtensions
    {
        //public static ObjectResult ToObjectResult(this BaseResult response, ILogger logger)
        //{
        //    if (response is ErrorResult errorResult)
        //    {
        //        logger.LogError(JsonConvert.SerializeObject(errorResult.Error));
        //        var errorResponse = new ErrorResponse() { Type = errorResult.Error.Type, ErrorMessage = errorResult.Error.ErrorMessage };
        //        return new ObjectResult(errorResponse)
        //        {
        //            StatusCode = response.StatusCode
        //        };
        //    }
        //    else
        //    {
        //        return new ObjectResult(response.StatusCode)
        //        {
        //            StatusCode = response.StatusCode
        //        };
        //    }
        //}
    }
}
