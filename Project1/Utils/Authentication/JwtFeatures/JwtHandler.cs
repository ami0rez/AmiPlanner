using Amirez.AmiPlanner.Common.Configuration;
using Amirez.AmiPlanner.Common.Constants;
using Involys.Common.Logger;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Amirez.AmiPlanner.Utils.Authentication.JwtFeatures
{
    /// <summary>
    /// Manage Jwt Authentication
    /// </summary>
    public class JwtHandler
    {
        protected readonly AppSettings _appSettings;
        protected readonly ILoggerManager _logger;

        public JwtHandler(IOptions<AppSettings> appSettings, ILoggerManager logger)
        {
            _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public SigningCredentials GetSigningCredentials()
        {
            _logger.Info("Getting Sign in Credentials");
            var key = Encoding.UTF8.GetBytes(_appSettings.JwtSettings.SecurityKey);
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        /// <summary>
        /// Get default claims
        /// </summary>
        /// <param name="user"></param>
        /// <param name="admin"></param>
        /// <returns></returns>
        public List<Claim> GetDefaultClaims(IdentityUser<Guid> user)
        {
            _logger.Info("Getting Default Claims: Name, NameIdentifier");
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            return claims;
        }

        /// <summary>
        /// Add Admin Role to list of claims
        /// </summary>
        /// <param name="claims"></param>
        public void AddAdminRoleClaim(List<Claim> claims)
        {
            _logger.Info("Adding Admin Role to list of claims");
            claims.Add(new Claim(ClaimTypes.Role, Constants.AdminRole));
        }

        /// <summary>
        /// Generate JwtSecurityToken
        /// </summary>
        /// <param name="signingCredentials"></param>
        /// <param name="claims"></param>
        /// <returns></returns>
        public JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            _logger.Info("Generating JwtSecurityToken");
            var expiryInMinutes = _appSettings.JwtSettings.ExpiryInMinutes;
            var tokenOptions = new JwtSecurityToken(
                issuer: _appSettings.JwtSettings.ValidIssuer,
                audience: _appSettings.JwtSettings.ValidAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(expiryInMinutes),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }

        /// <summary>
        /// Get Claims from token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token, JwtSettings jwtSettings)
        {
            _logger.Info("Getting Claims from token");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.ValidIssuer,
                ValidAudience = jwtSettings.ValidAudience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(jwtSettings.SecurityKey))
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }
    }
}
