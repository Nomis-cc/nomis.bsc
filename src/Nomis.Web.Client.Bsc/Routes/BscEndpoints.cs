using Nomis.Web.Client.Common.Routes;

namespace Nomis.Web.Client.Bsc.Routes
{
    /// <summary>
    /// BSC endpoints.
    /// </summary>
    public class BscEndpoints :
        BaseEndpoints
    {
        /// <summary>
        /// Initialize <see cref="BscEndpoints"/>.
        /// </summary>
        /// <param name="baseUrl">BSC API base URL.</param>
        public BscEndpoints(string baseUrl) 
            : base(baseUrl)
        {
        }

        /// <inheritdoc/>
        public override string Blockchain => "bsc";
    }
}
