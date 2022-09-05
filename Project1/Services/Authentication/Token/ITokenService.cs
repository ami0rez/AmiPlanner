using Amirez.AmiPlanner.Controllers.Authentication.Account.Models;
using Amirez.AmiPlanner.Controllers.Authentication.Tokens.Models;
using Amirez.Infrastructure.Data.Model.Authentication;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Authentication.Token
{
    /// <summary>
    /// Manage user tokens
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Refresh user Token
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        Task<AuthenticationResponse> RefreshToken(RefreshTokenQuery query);

        /// <summary>
        /// Generates new refresh token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<string> UpdateRefreshToken(UtilisateurDataModel user);

        /// <summary>
        /// Revoke Token in current context
        /// </summary>
        /// <returns></returns>
        Task RevokeToken();
    }
}