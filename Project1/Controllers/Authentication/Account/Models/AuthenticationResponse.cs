using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Controllers.Authentication.Account.Models
{
    public class AuthenticationResponse
    {
        public UserProfileResponse Profile { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenType { get; set; }
        public string RefreshToken { get; set; }
    }
}
