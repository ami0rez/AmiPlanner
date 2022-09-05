using Amirez.AmiPlanner.Controllers.Authentication.Account.Models;
using Amirez.AmiPlanner.Services.Authentication.Accounts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Controllers.Authentication.Account
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        protected readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
        }

        // api/v1/Account/Login
        [HttpPost("Login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] AuthenticationQuery query)
        {
            return Ok(await _accountService.Login(query));
        }

        // api/v1/Account/Logout
        [HttpPost("Logout"), Authorize]
        public async Task<ActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok();
        }


        // api/v1/Account/ChangePassword
        [HttpPost("ChangePassword"), Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ChangePassword(ChangerMotDePasseQuery query)
        {
            await _accountService.ChangePassword(query);
            return Ok();
        }

    }
}
