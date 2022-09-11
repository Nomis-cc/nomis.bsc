using EthScanNet.Lib.Models.ApiResponses.Accounts.Models;

namespace Nomis.Bscscan.Interfaces
{
    /// <summary>
    /// Bscscan client.
    /// </summary>
    public interface IBscscanClient
    {
        /// <summary>
        /// Get list of internal transactions of the given account.
        /// </summary>
        /// <param name="address">Account address.</param>
        /// <returns>Returns list of internal transactions of the given account.</returns>
        Task<IEnumerable<EScanTransaction>> GetInternalTransactionsAsync(string address);
    }
}