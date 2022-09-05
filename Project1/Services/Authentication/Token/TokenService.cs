using Amirez.AmipBackend.Common.Constants;
using Amirez.AmiPlanner.Common.Configuration;
using Amirez.AmiPlanner.Common.Constants;
using Amirez.AmiPlanner.Controllers.Authentication.Account.Models;
using Amirez.AmiPlanner.Controllers.Authentication.Tokens.Models;
using Amirez.AmiPlanner.Services.Authentication.Configuration;
using Amirez.AmiPlanner.Utils.Authentication.JwtFeatures;
using Amirez.Infrastructure.Data.Model.Authentication;
using Amirez.Infrastructure.Repositories.Authentication.Token;
using Involys.Common.Exceptions;
using Involys.Common.Logger;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Authentication.Token
{
    /// <summary>
    /// Manage user tokens
    /// </summary>
    public class TokenService : ITokenService
    {
        protected readonly UserManager<UtilisateurDataModel> _userManager;
        protected readonly ITokenRepository _tokenRepository;
        protected readonly JwtHandler _jwtHandler;
        protected readonly IConfigurationService _configurationService;
        protected readonly AppSettings _appSettings;
        protected readonly ILoggerManager _logger;
        public TokenService(
            UserManager<UtilisateurDataModel> userManager,
            JwtHandler jwtHandler,
            ITokenRepository tokenRepository,
            IConfigurationService configurationService,
            IOptions<AppSettings> appSettings,
            ILoggerManager logger)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _jwtHandler = jwtHandler ?? throw new ArgumentNullException(nameof(jwtHandler));
            _tokenRepository = tokenRepository ?? throw new ArgumentNullException(nameof(tokenRepository));
            _configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Refresh user Token
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<AuthenticationResponse> RefreshToken(RefreshTokenQuery query)
        {
            _logger.Info("Trying to refresh token");
            if (query is null)
            {
                _logger.Info("request is null");
                throw new ResponseException(ErrorConstants.BadRefreshTokenRequest);
            }
            string accessToken = query.AccessToken;
            string refreshToken = query.RefreshToken;
            var principal = _jwtHandler.GetPrincipalFromExpiredToken(accessToken, _appSettings.JwtSettings);
            var userIdentifer = _userManager.GetUserId(principal);
            _logger.Info("Refresh token for user : " + userIdentifer);
            if (string.IsNullOrEmpty(userIdentifer))
            {
                _logger.Error("userIdentifer is null : ");
                throw new ResponseException(ErrorConstants.BadRefreshTokenRequest);
            }
            var user = await _userManager.FindByIdAsync(userIdentifer);
            if (user == null)
            {
                _logger.Error("user with the identifier not found");
                throw new ResponseException(ErrorConstants.BadRefreshTokenRequest);
            }
            var userTokenValid = await ValidateUserRefreshToken(user, refreshToken);
            if (!userTokenValid)
            {
                _logger.Error("Refresh token is not valid");
                throw new ResponseException(ErrorConstants.BadRefreshTokenRequest);
            }
            return await GenerateAuthenticationResponse(principal, user);
        }

        /// <summary>
        /// Generate Authentication Response
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        protected async Task<AuthenticationResponse> GenerateAuthenticationResponse(ClaimsPrincipal principal, UtilisateurDataModel user)
        {
            try
            {
                var signingCredentials = _jwtHandler.GetSigningCredentials();
                var newAccessTokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, principal.Claims.ToList());
                var newAccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessTokenOptions);
                var newRefreshToken = await UpdateRefreshToken(user);
                return new AuthenticationResponse
                {
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken
                };
            }
            catch (Exception ex)
            {
                _logger.Error("Error Generating Authentication Response", ex);
                throw new ResponseException(ErrorConstants.ErrorRefreshTokenRequest);
            }
        }


        /// <summary>
        /// Generates new refresh token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> UpdateRefreshToken(UtilisateurDataModel user)
        {
            try
            {
                _logger.Info("Generating new Refresh token for user " + user.Id);
                await RemoveRefreshToken(user);
                var newRefreshToken = await _userManager.GenerateUserTokenAsync(user, Constants.RefreshTokenProvider, Constants.RefreshToken);
                await _userManager.SetAuthenticationTokenAsync(user, Constants.RefreshTokenProvider, Constants.RefreshToken, newRefreshToken);
                return newRefreshToken;
            }
            catch (Exception ex)
            {
                _logger.Error("Error Generating new Refresh token", ex);
                throw;
            }
        }


        /// <summary>
        /// Get refresh token for user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected async Task<string> GetUserRefreshToken(UtilisateurDataModel user)
        {
            try
            {
                _logger.Info("Getting Refresh token for user " + user.Id);
                var newRefreshToken = await _userManager.GetAuthenticationTokenAsync(user, Constants.RefreshTokenProvider, Constants.RefreshToken);
                return newRefreshToken;
            }
            catch (Exception ex)
            {
                _logger.Error("Error Getting Refresh token", ex);
                throw;
            }
        }


        /// <summary>
        /// Verifies if token is valid
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected async Task<bool> ValidateUserRefreshToken(UtilisateurDataModel user, string token)
        {
            try
            {
                _logger.Info("Getting Refresh token for user " + user.Id);
                var tokenValid = await _tokenRepository.ValidateRefreshToken(user, Constants.RefreshTokenProvider, Constants.RefreshToken, token);
                return tokenValid;
            }
            catch (Exception ex)
            {
                _logger.Error("Error Getting Refresh token", ex);
                throw;
            }
        }

        /// <summary>
        /// Revoke Token in current context
        /// </summary>
        /// <returns></returns>
        public async Task RevokeToken()
        {
            var userId = await _configurationService.GetCurrentUserIdAsync();
            if (userId == null)
            {
                _logger.Info("Trying to revoke token while context is empty");
                throw new ResponseException(ErrorConstants.UserNotFound);
            }
            var user = await _userManager.FindByIdAsync(userId.ToString());
            await RemoveRefreshToken(user);
        }


        /// <summary>
        /// Remove new refresh token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        protected async Task RemoveRefreshToken(UtilisateurDataModel user)
        {
            try
            {
                _logger.Info("Remove Refresh token for user " + user.Id);
                await _userManager.RemoveAuthenticationTokenAsync(user, Constants.RefreshTokenProvider, Constants.RefreshToken);
                await _userManager.UpdateSecurityStampAsync(user);
            }
            catch (Exception ex)
            {
                _logger.Error("Error Removing Refresh token", ex);
                throw;
            }
        }
    }
}
