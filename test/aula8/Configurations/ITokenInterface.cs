using System.Security.Claims;

namespace aula8.Configurations
{
    public interface ITokenInterface
    {
        string GenerateAcessToken(IEnumerable<Claim> claims);
        string GenereteRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
