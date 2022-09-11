using System.Net;

using EthScanNet.Lib;
using EthScanNet.Lib.Models.EScan;
using Microsoft.Extensions.Options;
using Nethereum.Util;
using Nomis.Blockchain.Abstractions.Enums;
using Nomis.Bscscan.Calculators;
using Nomis.Bscscan.Interfaces;
using Nomis.Bscscan.Interfaces.Models;
using Nomis.Bscscan.Interfaces.Settings;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Exceptions;
using Nomis.Utils.Wrapper;

namespace Nomis.Bscscan
{
    /// <inheritdoc cref="IBscscanService"/>
    internal sealed class BscscanService :
        IBscscanService,
        ITransientService
    {
        private readonly IBscscanClient _client;

        /// <summary>
        /// Initialize <see cref="BscscanService"/>.
        /// </summary>
        /// <param name="settings"><see cref="BscscanSettings"/>.</param>
        /// <param name="client"><see cref="IBscscanClient"/>.</param>
        public BscscanService(
            IOptions<BscscanSettings> settings,
            IBscscanClient client)
        {
            _client = client;
            var network = settings.Value.Network switch
            {
                BlockchainNetwork.BSC => EScanNetwork.BscMainNet,
                _ => throw new InvalidOperationException($"Invalid {nameof(settings.Value.Network)}")
            };
            Client = new(network, settings.Value.ApiKey);
        }

        /// <inheritdoc/>
        public EScanClient Client { get; }

        /// <inheritdoc/>
        public async Task<Result<BscWalletScore>> GetWalletStatsAsync(string address)
        {
            if (!new AddressUtil().IsValidAddressLength(address) || !new AddressUtil().IsValidEthereumAddressHexFormat(address))
            {
                throw new CustomException("Invalid address", statusCode: HttpStatusCode.BadRequest);
            }

            var bscAddress = new EScanAddress(address);
            var balanceWei = (await Client.Accounts.GetBalanceAsync(bscAddress)).Balance;
            var transactions = (await Client.Accounts.GetNormalTransactionsAsync(bscAddress)).Transactions;
            var internalTransactions = (await Client.Accounts.GetInternalTransactionsAsync(bscAddress)).Transactions; // await _client.GetInternalTransactionsAsync(address);
            var tokens = (await Client.Accounts.GetTokenEvents(bscAddress)).TokenTransferEvents;
            var erc20Tokens = (await Client.Accounts.GetERC20TokenEvents(bscAddress)).ERC20TokenTransferEvents;

            var walletStats = new BscStatCalculator(
                    address,
                    balanceWei,
                    transactions,
                    internalTransactions,
                    tokens,
                    erc20Tokens)
                .GetStats();

            return await Result<BscWalletScore>.SuccessAsync(new()
            {
                Stats = walletStats,
                Score = walletStats.GetScore()
            }, "Got BSC wallet score.");
        }
    }
}