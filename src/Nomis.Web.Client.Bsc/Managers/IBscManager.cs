using Nomis.Bscscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Managers;

namespace Nomis.Web.Client.Bsc.Managers
{
    /// <summary>
    /// BSC manager.
    /// </summary>
    public interface IBscManager :
        IManager
    {
        /// <summary>
        /// Get BSC wallet score.
        /// </summary>
        /// <param name="address">Wallet address.</param>
        /// <returns>Returns result of <see cref="BscWalletScore"/>.</returns>
        Task<IResult<BscWalletScore>> GetWalletScoreAsync(string address);
    }
}