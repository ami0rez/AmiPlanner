using Amirez.Infrastructure.Data.Model.Authentication;
using Amirez.Infrastructure.Repositories.SimpleGneric;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Authentication.Utilisateur
{
    public interface IUtilisateurRepository : ISimpleGenericRepository<UtilisateurDataModel>
    {

        /// <summary>
        /// Deletes a user by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UtilisateurDataModel> DeleteUser(Guid id);

        /// <summary>
        /// Gets user by its id
        /// </summary>
        /// <returns></returns>
        Task<UtilisateurDataModel> GetUserById(Guid id);

        /// <summary>
        /// Gets list of users
        /// </summary>
        /// <returns></returns>
        Task<IQueryable<UtilisateurDataModel>> GetUsers();

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <returns></returns>        
        Task UpdateUser(UtilisateurDataModel user);

        /// <summary>
        /// create a new user
        /// </summary>
        /// <returns></returns>
        Task<IdentityResult> CreateUser(UtilisateurDataModel user);

        /// <summary>
        /// check if the user exists
        /// </summary>
        /// <returns></returns>
        Task<bool> IsUserExisits(Guid id);

        /// <summary>
        /// check if user login exists
        /// </summary>
        /// <returns></returns>
        Task<bool> IsLoginExisits(string login, Guid? excludedId = null);

        /// <summary>
        /// check if user mail exists
        /// </summary>
        /// <returns></returns>
        Task<bool> IsEmailExisits(string email, Guid? excludedId = null);

        /// <summary>
        /// Get user by userName
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns></returns>
        Task<UtilisateurDataModel> GetUserByUserName(string userName);
    }
}
