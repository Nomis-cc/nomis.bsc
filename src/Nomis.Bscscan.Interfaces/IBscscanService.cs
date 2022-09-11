using EthScanNet.Lib;
using Nomis.Bscscan.Interfaces.Models;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;

namespace Nomis.Bscscan.Interfaces
{
    /// <summary>
    /// Bscscan service.
    /// </summary>
    public interface IBscscanService :
        IInfrastructureService
    {
        /// <summary>
        /// Client for interacting with Bscscan API.
        /// </summary>
        public EScanClient Client { get; }

        /// <summary>
        /// Get BSC wallet stats by address.
        /// </summary>
        /// <param name="address">Bsc wallet address.</param>
        /// <returns>Returns <see cref="BscWalletScore"/> result.</returns>
        public Task<Result<BscWalletScore>> GetWalletStatsAsync(string address);
    }
}