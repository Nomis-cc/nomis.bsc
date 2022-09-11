using Microsoft.Extensions.Options;
using Nomis.Bscscan.Interfaces.Models;
using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Extensions;
using Nomis.Web.Client.Common.Settings;
using Nomis.Web.Client.Bsc.Routes;

namespace Nomis.Web.Client.Bsc.Managers
{
    /// <inheritdoc cref="IBscManager" />
    public class BscManager :
        IBscManager
    {
        private readonly HttpClient _httpClient;
        private readonly BscEndpoints _endpoints;

        /// <summary>
        /// Initialize <see cref="BscManager"/>.
        /// </summary>
        /// <param name="webApiSettings"><see cref="WebApiSettings"/>.</param>
        public BscManager(
            IOptions<WebApiSettings> webApiSettings)
        {
            _httpClient = new()
            {
                BaseAddress = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)))
            };
            _endpoints = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)));
        }

        /// <inheritdoc />
        public async Task<IResult<BscWalletScore>> GetWalletScoreAsync(string address)
        {
            var response = await _httpClient.GetAsync(_endpoints.GetWalletScore(address));
            return await response.ToResultAsync<BscWalletScore>();
        }
    }
}