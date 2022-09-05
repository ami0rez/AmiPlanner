
using Amirez.AmipBackend.Common.Constants;
using Amirez.AmiPlanner.Common.Constants;
using Amirez.AmiPlanner.Controllers.Authentication.Account.Models;
using Amirez.AmiPlanner.Services.Authentication.Configuration;
using Amirez.AmiPlanner.Services.Authentication.Token;
using Amirez.AmiPlanner.Utils.Authentication.JwtFeatures;
using Amirez.Infrastructure.Data.Model.Authentication;
using Amirez.Infrastructure.Repositories.Authentication.Utilisateur;
using AutoMapper;
using Involys.Common.Exceptions;
using Involys.Common.Logger;
using Microsoft.AspNetCore.Identity;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Services.Authentication.Accounts
{
    /// <summary>
    /// Manages Account Operations (Login, ...)
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly UserManager<UtilisateurDataModel> _userManager;
        protected readonly ITokenService _tokenService;
        protected readonly IConfigurationService _configurationService;
        private readonly JwtHandler _jwtHandler;
        private readonly IMapper _mapper;
        protected readonly ILoggerManager _logger;
        protected readonly IUtilisateurRepository _userRepository;

        public AccountService(
            UserManager<UtilisateurDataModel> userManager,
            ITokenService tokenService,
            IConfigurationService configurationService,
            JwtHandler jwtHandler,
            ILoggerManager logger,
            IMapper mapper,
            IUtilisateurRepository userRepository)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _configurationService = configurationService ?? throw new ArgumentNullException(nameof(configurationService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _jwtHandler = jwtHandler ?? throw new ArgumentNullException(nameof(jwtHandler));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        /// <summary>
        /// Login user
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<AuthenticationResponse> Login(AuthenticationQuery query)
        {
            _logger.Info("Trying to login for user: " + query.UserName);
            var user = await _userRepository.GetUserByUserName(query.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, query.Password))
            {
                _logger.Info("Invalid Authentication");
                throw new ResponseException(ErrorConstants.InvalidUserOrPassword);
            }
            if (user.Bloque)
            {
                _logger.Info("Could Not login, user authentication succeed but user is blocked");
                throw new ResponseException(ErrorConstants.UserLocked);
            }
            _logger.Info("Authentication is Valid, Generating Authentication Response");
            var signingCredentials = _jwtHandler.GetSigningCredentials();
            var claims = _jwtHandler.GetDefaultClaims(user);
            if (user.Role.RoleType == Roles.Administrateur)
            {
                _jwtHandler.AddAdminRoleClaim(claims);
            }
            var tokenOptions = _jwtHandler.GenerateTokenOptions(signingCredentials, claims);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            var refreshToken = await _tokenService.UpdateRefreshToken(user);
            var userProfile = _mapper.Map<UserProfileResponse>(user);
            var response = new AuthenticationResponse
            {
                Profile = userProfile,
                AccessToken = accessToken,
                AccessTokenType = Constants.BearerTokenType,
                RefreshToken = refreshToken
            };
            return response;
        }

        /// <summary>
        /// Logout user
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task Logout()
        {
            _logger.Info("Trying to logout connected user");
            await _tokenService.RevokeToken();
        }

        /// <summary>
        /// Change user's password
        /// </summary>
        /// <param name="query">change password user's query</param>
        /// <returns></returns>
        public async Task ChangePassword(ChangerMotDePasseQuery query)
        {
            _logger.Info($"Changing password for user with username:{query.Login}");
            await ValidateChangePasswordQuery(query);

            var user = await _userManager.FindByNameAsync(query.Login);

            var passwordValid = await _userManager.CheckPasswordAsync(user, query.OldPassword);
            if (passwordValid)
            {
                var changePasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passwordReset = await _userManager.ResetPasswordAsync(
                    user,
                    changePasswordToken,
                    query.NewPassword);

                if (!passwordReset.Succeeded)
                {
                    foreach (var error in passwordReset.Errors)
                    {
                        if (error.Code == ErrorConstants.PasswordFormatIsWrrong)
                        {
                            _logger.Error($"Error updating user's password: UserId: {user.Id}, Code:{error.Code}, Description: {error.Description}");
                            throw new ResponseException(ErrorConstants.PasswordFormatIsWrrong);
                        }

                    }
                    var errors = string.Join(", ", passwordReset.Errors.Select(error => $"Code:{error.Code}, Description: {error.Description}").ToArray());
                    _logger.Error($"Error creating new user, Reasons:{errors}");
                    throw new ResponseException(ErrorConstants.ErrorChangePassword);
                }
                else
                {
                    _logger.Info($"Password successfully changed");
                }

            }
            else
            {
                _logger.Error($"Current password of user is invalid");
                throw new ResponseException(ErrorConstants.OldPasswordIsWrong);
            }
        }

        /// <summary>
        /// Verifies if change password query is valid
        /// </summary>
        /// <param name="query">change password user's query</param>
        /// <returns></returns>
        protected async Task<bool> ValidateChangePasswordQuery(ChangerMotDePasseQuery query)
        {
            _logger.Info("Checking if the user's query valid");
            var currentUser = await _configurationService.GetCurrentUserAsync();
            if (currentUser.UserName != query.Login)
            {

                _logger.Error("Provided login is different to connected user's login");
                throw new ResponseException(ErrorConstants.ChangePasswordInvalidLogin);
            }
            return true;
        }
    }
}

