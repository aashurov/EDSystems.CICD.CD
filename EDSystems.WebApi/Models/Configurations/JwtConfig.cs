namespace EDSystems.WebApi.Models.Configurations
{
    /// <summary>
    ///
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        ///
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        ///
        /// </summary>
        public TimeSpan ExpiryTimeFrame { get; set; }
    }
}