using System.Security.Claims;

namespace WebApiEntityFramework.Services.User
{
    public class User: IUser
    {
        private readonly HttpContext _httpContext;

        public User(IHttpContextAccessor accessor)        {
            _httpContext = accessor.HttpContext;
        }

        public string? Id => _httpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
