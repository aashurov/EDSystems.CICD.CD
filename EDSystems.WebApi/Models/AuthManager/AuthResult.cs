namespace EDSystems.WebApi.Models.AuthManager
{
    /// <summary>
    ///
    /// </summary>
    public class AuthResult
    {
        /// <summary>
        ///
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string RefreshTokenn { get; set; }

        /// <summary>
        ///
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        ///
        /// </summary>
        public List<string> Message { get; set; }
    }
}