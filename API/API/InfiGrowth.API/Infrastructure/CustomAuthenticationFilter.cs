using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace InfiGrowth.API.Infrastructure
{
    public class CustomAuthenticationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string _module;
        private readonly string _action;

        public CustomAuthenticationFilter(string module, string action)
               =>(_module, _action) = (module, action);

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User.Claims.ToList();
            foreach (var item in user)
            {
                if (item.Type.Contains("claims/role") && item.Issuer== "LOCAL AUTHORITY")
                {
                    var data=item.Value;
                    if (data.Split("/")[0]==_module && data.Split("/")[1]==_action && data.Split("/")[2]!="True")
                    {
                        context.Result=new UnauthorizedObjectResult(new { message = "Unauthorized User!" });
                    }
                }
            }
        }
    }
}
