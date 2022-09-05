using Amirez.AmiPlanner.Controllers.Authentication.Account.Models;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Authentication.Accounts
{
    /// <summary>
    /// Manages Account Operations (Login, ...)
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="query">Authentication query</param>
        /// <returns></returns>
        Task<AuthenticationResponse> Login(AuthenticationQuery query);

        /// <summary>
        /// Logout user
        /// </summary>
        /// <returns></returns>
        Task Logout();

        /// <summary>
        /// Change user's password
        /// </summary>
        /// <param name="query">change password user's query</param>
        /// <returns></returns>
        Task ChangePassword(ChangerMotDePasseQuery query);
    }
}