using Nomis.Blockchain.Abstractions.Enums;
using Nomis.Utils.Contracts.Common;

namespace Nomis.Bscscan.Interfaces.Settings
{
    /// <summary>
    /// Bscscan settings.
    /// </summary>
    public class BscscanSettings :
        ISettings
    {
        /// <summary>
        /// API key for bscscan.
        /// </summary>
        public string? ApiKey { get; set; }

        /// <summary>
        /// Blockchain network.
        /// </summary>
        public BlockchainNetwork Network { get; set; } = BlockchainNetwork.BSC;

        /// <summary>
        /// Bscscan API base URL.
        /// </summary>
        public string? ApiBaseUrl { get; set; }
    }
}