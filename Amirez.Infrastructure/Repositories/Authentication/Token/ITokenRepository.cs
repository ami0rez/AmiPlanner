using Amirez.Infrastructure.Data.Model.Authentication;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Authentication.Token
{
    /// <summary>
    /// Token Repository
    /// </summary>
    public interface ITokenRepository
    {

        /// <summary>
        /// Verifies if Refresh Token is valid
        /// </summary>
        /// <returns></returns>
        Task<bool> ValidateRefreshToken(UtilisateurDataModel user, string tokenProvider, string purpos, string refreshToken);
    }
}