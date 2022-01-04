using eCommerce.Application;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace eCommerce.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    public int UserId
    {
        get
        {
            return GetUserId();
        }
    }

    public ClaimsIdentity UserIdentity
    {
        get
        {
            return GetUserIdentity();
        }
    }

    public bool HasClaim(string claimName)
    {
        return GetUserIdentity().Claims.Any(x => x.Type == claimName);
    }

    public Claim GetUserClaim(string claimType)
    {
        var result = GetUserIdentity();

        return result.Claims.FirstOrDefault(x => x.Type == claimType);
    }

    public string GetUserClaimValue(string claimName)
    {
        var result = GetUserIdentity().Claims.FirstOrDefault(x => x.Type == claimName);

        return result != null ? (result?.Value) : string.Empty;
    }

    public IEnumerable<Claim> GetUserClaims()
    {
        var result = GetUserIdentity();

        return result.Claims;
    }

    private static ClaimsIdentity GetUserIdentity()
    {
        return new HttpContextAccessor().HttpContext.User.Identity as ClaimsIdentity;
    }

    private static int GetUserId()
    {
        var result = Convert.ToInt32(GetUserIdentity().FindFirst(ClaimTypes.NameIdentifier)?.Value);

        if (result == null)
            result = default(int);

        return result;
    }
}
