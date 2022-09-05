using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Amirez.Infrastructure.Repositories.Authentication.Token
{
    /// <summary>
    /// Token Repository
    /// </summary>
    public class TokenRepository : ITokenRepository
    {
        protected DatabaseContext _context;
        private readonly UserManager<UtilisateurDataModel> _userManager;
        public TokenRepository(DatabaseContext context, UserManager<UtilisateurDataModel> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        /// <summary>
        /// Verifies if Refresh Token is valid
        /// </summary>
        /// <param name="user"></param>
        /// <param name="tokenProvider"></param>
        /// <param name="purpos"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        public async Task<bool> ValidateRefreshToken(UtilisateurDataModel user, string tokenProvider, string purpos, string refreshToken)
        {
            if (user == null || string.IsNullOrEmpty(refreshToken))
            {
                return false;
            }
            if (!await _context.UserTokens.AnyAsync(token =>
            token.Value == refreshToken
            && token.UserId == user.Id
            && token.Name == purpos
            && token.LoginProvider == tokenProvider))
            {

                return false;
            }
            var tokenValid = await _userManager.VerifyUserTokenAsync(user, tokenProvider, purpos, refreshToken);
            return tokenValid;
        }
    }
}
