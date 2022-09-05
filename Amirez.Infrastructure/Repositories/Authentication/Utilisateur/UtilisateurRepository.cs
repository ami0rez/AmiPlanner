
using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Authentication;
using Amirez.Infrastructure.Repositories.SimpleGneric;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Authentication.Utilisateur
{
    public class UtilisateurRepository : SimpleGenericRepository<UtilisateurDataModel>, IUtilisateurRepository
    {
        private readonly UserManager<UtilisateurDataModel> _userManager;

        public UtilisateurRepository(DatabaseContext context,
            UserManager<UtilisateurDataModel> userManager
            ) : base(context)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        /// <summary>
        /// Gets list of users
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<IQueryable<UtilisateurDataModel>> GetUsers()
        {
            var users = _context.Users
                .Include(u => u.Role)
                .OrderBy(u => u.Nom);
            return Task.FromResult(users.AsQueryable());
        }

        /// <summary>
        /// Gets list users as options
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<UtilisateurDataModel>> GetUserOptions()
        {
            var users = await _context.Users
                .OrderBy(u => u.UserName)
                .ToListAsync();
            return users;
        }

        /// <summary>
        /// Gets user by its id
        /// </summary>
        /// <returns></returns>
        public async Task<UtilisateurDataModel> GetUserById(Guid id)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        /// <summary>
        /// create a new user
        /// </summary>
        /// <returns></returns>
        public async Task<IdentityResult> CreateUser(UtilisateurDataModel user)
        {
            var result = await _userManager.CreateAsync(user);
            return result;
        }

        /// <summary>
        /// Updates a user
        /// </summary>
        /// <returns></returns>
        public async Task UpdateUser(UtilisateurDataModel user)
        {
            _context.Set<UtilisateurDataModel>().Update(user);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// check if the user exists
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsUserExisits(Guid id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }


        /// <summary>
        /// check if user login exists
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsLoginExisits(string login, Guid? excludedId = null)
        {
            return await _context.Users.AnyAsync(
                u => u.UserName == login
                && (!excludedId.HasValue || u.Id != excludedId.Value));
        }

        /// <summary>
        /// check if user mail exists
        /// </summary>
        /// <returns></returns>
        public async Task<bool> IsEmailExisits(string email, Guid? excludedId = null)
        {
            return await _context.Users.AnyAsync(
                u => u.Email == email
                && (!excludedId.HasValue || u.Id != excludedId.Value));
        }

        /// <summary>
        /// Deletes a user by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UtilisateurDataModel> DeleteUser(Guid id)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(d => d.Id == id);
            await _userManager.DeleteAsync(user);
            return user;
        }

        /// <summary>
        /// Get user by userName
        /// </summary>
        /// <param name="userName">username</param>
        /// <returns></returns>
        public async Task<UtilisateurDataModel> GetUserByUserName(string userName)
        {
            return await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.NormalizedUserName == userName.ToUpper());
        }
    }
}
