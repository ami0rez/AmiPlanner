namespace Amirez.AmiPlanner.Common.Constants
{
    public static class Constants
    {
        #region Authentication
        public const string BearerTokenType = "Bearer";
        public const string AdminRole = "Admin";
        public const string RefreshToken = "RefreshToken";
        public const string RefreshTokenProvider = "RefreshTokenProvider";
        #endregion

        #region Specials
        public const string Separator = " | ";
        public const string Space = " ";
        public const string EmptyString = "";
        public const string SingleSlash = "/";
        public const char Slash = '\\';
        public const string DoubleSlash = "\\\\";
        public const string TwoPoints = ":";
        public const string Dash = " - ";
        public const string UnderScore = "_";
        public const string Arobase = "@";
        public const string PercentFormat = "0.00%";
        public const string AmountFormat = "0.00";
        #endregion

        #region Dates
        public const string MinDate1901 = "01/01/1901";
        public const string MinDate = "01/01/0001";
        #endregion
    }
}
