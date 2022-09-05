using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Authentication.Configuration
{
    /// <summary>
    /// User Configuration Service, restores current user info
    /// </summary>
    public class ConfigurationService : IConfigurationService
    {
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        private const string JwtUserClaimIdentifier = ClaimTypes.NameIdentifier;

        public ConfigurationService(DatabaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }


        /// <summary>
        /// Gets the connected user
        /// </summary>
        /// <returns>UserDataModel</returns>
        public async Task<UtilisateurDataModel> GetCurrentUserAsync()
        {
            var userId = await GetCurrentUserIdAsync();
            if (!userId.HasValue)
            {
                return null;
            }
            return await _context.Utilisateurs
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        /// <summary>
        /// get Id of the current user
        /// </summary>
        /// <returns></returns>
        public virtual Task<Guid?> GetCurrentUserIdAsync()
        {
            if (_httpContextAccessor.HttpContext != null)
            {
                var userId = _httpContextAccessor.HttpContext.User.FindFirst(JwtUserClaimIdentifier)?.Value;
                if (Guid.TryParse(userId, out var userGuid))
                {
                    Guid? currentUserId = userGuid;
                    return Task.FromResult(currentUserId);
                }
            }
            return Task.FromResult<Guid?>(null);
        }

        /// <summary>
        /// check if user is admin 
        /// </summary>
        /// <returns>
        /// true: if user is super admin
        /// false: if user is not super admin
        /// </returns>
        public async Task<bool> IsAdminAsync()
        {
            var currentUser = await GetCurrentUserAsync();
            var isAdmin = currentUser.Role.RoleType == Roles.Administrateur;
            return isAdmin;
        }

        /// <summary>
        /// Get current user role
        /// </summary>
        /// <returns>
        /// Current user role
        /// </returns>
        public async Task<Roles> GetCurrentUserRole()
        {
            var currentUser = await GetCurrentUserAsync();
            return currentUser.Role.RoleType;
        }
    }
}
