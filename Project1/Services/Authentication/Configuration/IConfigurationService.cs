using Amirez.Infrastructure.Data.Model.Authentication;
using System;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Authentication.Configuration
{
    /// <summary>
    /// User Configuration Service, restores current user info
    /// </summary>
    public interface IConfigurationService
    {
        /// <summary>
        /// Gets the connected user
        /// </summary>
        /// <returns>UserDataModel</returns>
        Task<UtilisateurDataModel> GetCurrentUserAsync();

        /// <summary>
        /// get Id of the current user
        /// </summary>
        /// <returns></returns>
        Task<Guid?> GetCurrentUserIdAsync();

        /// <summary>
        /// check if user is admin 
        /// </summary>
        /// <returns>
        /// true: if user is admin
        /// false: if user is not admin
        /// </returns>
        Task<bool> IsAdminAsync();
    }
}
