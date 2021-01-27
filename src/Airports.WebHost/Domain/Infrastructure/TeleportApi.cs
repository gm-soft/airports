using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Airports.WebHost.Domain.Infrastructure
{
    public class TeleportApi : IApi
    {
        public const string CTeleport = "cteleport";

        private readonly IHttpClientFactory _clientFactory;

        public TeleportApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            url.ThrowIfNull(nameof(url));

            HttpResponseMessage response = await Client().SendAsync(GetRequest(url));

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseStream);
            }

            throw new InvalidOperationException(
                $"The Teleport API request failed. Status: {response.StatusCode}");
        }

        private HttpClient Client()
        {
            return _clientFactory.CreateClient(CTeleport);
        }

        private HttpRequestMessage GetRequest(string url)
        {
            return new HttpRequestMessage(HttpMethod.Get, url);
        }
    }
}