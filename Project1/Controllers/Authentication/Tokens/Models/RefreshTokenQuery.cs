namespace Amirez.AmiPlanner.Controllers.Authentication.Tokens.Models
{
    public class RefreshTokenQuery
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
