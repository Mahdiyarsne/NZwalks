using Microsoft.AspNetCore.Identity;

namespace NZwalks.API.Repositories.TokenRepository
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> roles);
    }
}
