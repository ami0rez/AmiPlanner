namespace Amirez.AmiPlanner.Common.Configuration
{
    public class JwtSettings
    {
        public string SecurityKey { get; set; } = "Inv@lys2@22VectisGab@n";
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }
        public double ExpiryInMinutes { get; set; } = 30;
        public double RefreshTokenLifeSpan { get; set; } = 35;
    }
}
