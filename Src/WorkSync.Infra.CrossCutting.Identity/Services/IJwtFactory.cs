using System.Security.Claims;
using System.Threading.Tasks;

namespace WorkSync.Infra.CrossCutting.Identity.Services;

public interface IJwtFactory
{
    Task<JwtToken> GenerateJwtToken(ClaimsIdentity claimsIdentity);
}
