using System.Security.Claims;

namespace eCommerce.Application
{
    public interface ICurrentUserService
    {
        int UserId { get; }
        ClaimsIdentity UserIdentity { get; }

        bool HasClaim(string claimName);

        Claim GetUserClaim(string claimType);

        string GetUserClaimValue(string claimName);

        IEnumerable<Claim> GetUserClaims();
    }
}
