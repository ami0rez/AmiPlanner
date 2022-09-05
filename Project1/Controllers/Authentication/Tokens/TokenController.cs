using Amirez.AmiPlanner.Controllers.Authentication.Tokens.Models;
using Amirez.AmiPlanner.Services.Authentication.Token;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Controllers.Authentication.Tokens
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        //api/v1/Token/Refresh
        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<RefreshTokenResponse>> Refresh(RefreshTokenQuery query)
        {
            return Ok(await _tokenService.RefreshToken(query));
        }
    }
}
