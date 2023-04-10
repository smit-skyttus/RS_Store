using Microsoft.AspNetCore.Mvc;

namespace InfiGrowth.API.Infrastructure
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string module, string action)
        : base(typeof(CustomAuthenticationFilter))
        {
            Arguments = new object[] { module, action };
        }
    }
}
