using Infrastructure.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace WebHost.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            IsAuthenticated = httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            if (IsAuthenticated)
            {
                UserId = int.Parse(httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
        }
        public int? UserId { get; }

        public bool IsAuthenticated { get; }
    }
}
